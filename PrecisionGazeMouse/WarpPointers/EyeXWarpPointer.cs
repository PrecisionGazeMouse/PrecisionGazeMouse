using System;
using System.Drawing;
using Tobii.Interaction;

namespace PrecisionGazeMouse.WarpPointers
{
    class EyeXWarpPointer : WarpPointer
    {
        GazePointDataStream stream;
        //FixationDataStream stream;
        Point warpPoint;
        Point[] samples;
        int sampleIndex;
        int sampleCount;
        bool setNewWarp;

        public int Sensitivity { get; set; }

        public EyeXWarpPointer(int sensitivity)
        {
            samples = new Point[5];
            Sensitivity = sensitivity;

            stream = Program.EyeXHost.Streams.CreateGazePointDataStream();
            if (stream != null)
            {
                stream.IsEnabled = true;
                stream.Next += UpdateGazePosition;
            }
        }

        public bool IsStarted()
        {
            EngineStateValue<Tobii.Interaction.Framework.GazeTracking> status = Program.EyeXHost.States.GetGazeTrackingAsync().Result;
            return status.Value == Tobii.Interaction.Framework.GazeTracking.GazeTracked;
        }

        public bool IsWarpReady()
        {
            return sampleCount > samples.Length;
        }

        protected void UpdateGazePosition(object s, StreamData<GazePointData> streamData)
        {
            sampleCount++;
            sampleIndex++;
            if (sampleIndex >= samples.Length)
                sampleIndex = 0;
            samples[sampleIndex] = new Point((int)streamData.Data.X, (int)streamData.Data.Y);
        }

        public Point calculateSmoothedPoint()
        {
            return calculateTrimmedMean();
        }

        private Point calculateMean()
        {
            Point p = new Point(0, 0);
            for (int i = 0; i < samples.Length; i++)
            {
                p.X += samples[i].X;
                p.Y += samples[i].Y;
            }
            p.X /= samples.Length;
            p.Y /= samples.Length;

            return p;
        }

        private Point calculateTrimmedMean()
        {
            Point p = calculateMean();

            // Find the furthest point from the mean
            double maxDist = 0;
            int maxIndex = 0;
            for (int i = 0; i < samples.Length; i++)
            {
                double dist = Math.Pow(samples[i].X - p.X, 2) + Math.Pow(samples[i].Y - p.Y, 2);
                if (dist > maxDist)
                {
                    maxDist = dist;
                    maxIndex = i;
                }
            }

            // Calculate a new mean without the furthest point
            p = new Point(0, 0);
            for (int i = 0; i < samples.Length; i++)
            {
                if (i != maxIndex)
                {
                    p.X += samples[i].X;
                    p.Y += samples[i].Y;
                }
            }
            p.X /= (samples.Length - 1);
            p.Y /= (samples.Length - 1);

            return p;
        }

        private double calculateStdDev()
        {
            Point u = calculateMean();

            double o = 0;
            for (int i = 0; i < samples.Length; i++)
            {
                Point delta = Point.Subtract(samples[i], new System.Drawing.Size(u));
                o += Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2);
            }
            return Math.Sqrt(o / samples.Length);
        }

        public override String ToString()
        {
            return String.Format("({0:0}, {1:0})", samples[sampleIndex].X, samples[sampleIndex].Y);
        }

        public Point GetGazePoint()
        {
            return samples[sampleIndex];
        }

        public int GetSampleCount()
        {
            return sampleCount;
        }

        public Point GetWarpPoint()
        {
            return warpPoint;
        }

        public Point GetNextPoint(Point currentPoint)
        {
            Point smoothedPoint = calculateSmoothedPoint();
            Point delta = Point.Subtract(smoothedPoint, new System.Drawing.Size(warpPoint)); // whenever there is a big change from the past
            double distance = Math.Sqrt(Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2));
            if (!setNewWarp && distance > Sensitivity)
            {
                sampleCount = 0;
                setNewWarp = true;
            }

            if (setNewWarp && IsWarpReady())
            {
                warpPoint = smoothedPoint;
                setNewWarp = false;
            }

            return warpPoint;
        }

        public void Dispose()
        {
            stream.IsEnabled = false;
        }

        public void RefreshTracking()
        {
            sampleCount = 0;
            setNewWarp = true;
        }
    }
}
