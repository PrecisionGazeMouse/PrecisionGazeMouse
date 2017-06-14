using System;
using System.Drawing;
using Tobii.Interaction;

namespace GazePlusMouse
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
        int warpTreshold;

        public EyeXWarpPointer()
        {
            samples = new Point[10];
            warpTreshold = 200;
            
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
            return sampleCount > 10;
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
            /*
            Point delta = Point.Subtract(currentPoint, new Size(smoothedPoint));
            delta.X = delta.X / 5;
            delta.Y = delta.Y / 5;
            smoothedPoint = Point.Add(smoothedPoint, new Size(delta));

            delta = Point.Subtract(currentPoint, new Size(smoothedPoint));*/

            return calculateMean();
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

        public int GetWarpTreshold()
        {
            /*if (sampleCount < 10)
                return 150;
            double o = calculateStdDev() * 5;
            if (o < 50)
                return 50;
            if (o > 300)
                return 300;
            return (int)o;*/

            return warpTreshold;
        }

        public Point GetWarpPoint()
        {
            return warpPoint;
        }

        public Point GetNextPoint(Point currentPoint)
        {
            Point smoothedPoint = calculateSmoothedPoint();
            //Point delta = Point.Subtract(currentPoint, new Size(smoothedPoint)); // whenever there is a big change from the past
            Point delta = Point.Subtract(smoothedPoint, new System.Drawing.Size(warpPoint)); // whenever there is a big change from the past
            double distance = Math.Sqrt(Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2));
            if (!setNewWarp && distance > GetWarpTreshold())
            {
                sampleCount = 0;
                setNewWarp = true;
            }

            if (setNewWarp && IsWarpReady())
            {
                warpPoint = smoothedPoint;
                setNewWarp = false;
                //SendKeys.Send("{F12}");
            }

            return warpPoint;
        }
    }
}
