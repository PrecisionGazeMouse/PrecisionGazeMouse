using System;
using System.Drawing;
using Tobii.Interaction;

namespace GazePlusMouse.PrecisionPointers
{
    class EyeXPrecisionPointer : PrecisionPointer
    {
        PrecisionPointerMode mode;
        bool started;
        HeadPoseStream headPoseStream;
        bool hasCalibrated;
        Vector3 calibrationPoint;
        Vector3[] samples;
        int sampleIndex;
        int sampleCount;
        Point currentPoint;

        public EyeXPrecisionPointer()
        {
            mode = PrecisionPointerMode.ROTATION;
            samples = new Vector3[5];
            headPoseStream = Program.EyeXHost.Streams.CreateHeadPoseStream();
            if (headPoseStream != null)
            {
                headPoseStream.IsEnabled = true;
                headPoseStream.Next += OnNextHeadPose;
                started = true;
            }
        }

        public PrecisionPointerMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        public override string ToString()
        {
            switch (mode)
            {
                case (PrecisionPointerMode.ROTATION):
                    if (sampleCount < 5)
                        return "No rotation";
                    else
                        return String.Format("({0:f}, {1:f})", currentPoint.X, currentPoint.Y);
                case (PrecisionPointerMode.TRANSLATION):
                    /*
                    if (trans == null)
                        return "";
                    else
                        return String.Format("({0:0}, {1:0})", trans.x, trans.y);*/
                    break;
            }

            return "";
        }

        public Point GetNextPoint(Point warpPoint)
        {
            switch (mode)
            {
                case (PrecisionPointerMode.ROTATION):
                    System.Drawing.Rectangle screenSize = GazePlusMouseForm.GetScreenSize();
                    if (sampleCount >= 5)
                    {
                        currentPoint = calculateSmoothedCalibratedPoint();

                        double basePitch = (warpPoint.Y - screenSize.Height / 2.0) / (screenSize.Height / 2.0) * 50.0;
                        int yOffset = (int)(currentPoint.Y - basePitch);

                        double baseYaw = (warpPoint.X - screenSize.Width / 2.0) / (screenSize.Width / 2.0) * 150.0;
                        int xOffset = (int)(currentPoint.X - baseYaw);

                        warpPoint.Offset(xOffset, yOffset);

                        return warpPoint;
                    }
                    break;
                case (PrecisionPointerMode.TRANSLATION):
                    /*
                    trans = this.getTranslation();
                    if (trans != null)
                    {
                        warpPoint.Offset(trans.x / 4, trans.y / 4);
                        return warpPoint;
                    }*/
                    break;
            }

            return warpPoint;
        }

        public bool IsStarted()
        {
            return started;
        }

        private void OnNextHeadPose(object sender, StreamData<HeadPoseData> headPose)
        {
            if (headPose.Data.HasRotation.HasRotationX)
            {
                sampleCount++;
                sampleIndex++;
                if (sampleIndex >= samples.Length)
                    sampleIndex = 0;
                samples[sampleIndex] = headPose.Data.HeadRotation;
            }
        }

        public Point calculateSmoothedCalibratedPoint()
        {
            if (!hasCalibrated)
            {
                calibrationPoint = samples[sampleIndex];
                hasCalibrated = true;
            }
            
            Point p = new Point(0, 0);
            for (int i = 0; i < samples.Length; i++)
            {
                p.X += (int)((samples[i].Y - calibrationPoint.Y) * -600);
                p.Y += (int)((samples[i].X - calibrationPoint.X) * -1200);
            }
            p.X /= samples.Length;
            p.Y /= samples.Length;

            return p;
        }
    }
}
