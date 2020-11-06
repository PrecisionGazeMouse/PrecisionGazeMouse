using System;
using System.Drawing;
using Tobii.Interaction;

namespace PrecisionGazeMouse.PrecisionPointers
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
        int sensitivity;

        // the baseline of the sensitive slider in the UI
        const int BASELINE_SENSITIVITY = 5;

        // the number of pixels that a typical person rotates their head when looking at the screen edges
        const double EDGE_Y_ROTATION = 50;
        const double EDGE_X_ROTATION = 150;

        public EyeXPrecisionPointer(int sensitivity)
        {
            mode = PrecisionPointerMode.ROTATION;
            samples = new Vector3[5]; // store 5 samples
            this.sensitivity = sensitivity;
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

        public int Sensitivity
        {
            get { return sensitivity; }
            set { sensitivity = value; }
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
                    System.Drawing.Rectangle screenSize = PrecisionGazeMouseForm.GetScreenSize();
                    if (sampleCount >= 5)
                    {
                        currentPoint = calculateSmoothedCalibratedPoint();

                        // When a person looks to the edge of the screen, they rotate their head slightly. It'd be annoying if 
                        // the pointer was always offset down when we looked down, for example. So we need to correct for it.
                        // Assuming a neutral head position is the middle of the screen, and the edge rotation is the number of 
                        // pixels of head rotation we'd get when looking at the edge of the screen, calculate the ratio we expect 
                        // at the given warp point.
                        double basePitch = (warpPoint.Y - screenSize.Height / 2.0) / (screenSize.Height / 2.0) * EDGE_Y_ROTATION;

                        // subtract the pixels due to looking at the warp point, and scale the offset by the sensitivity setting
                        int yOffset = (int)((currentPoint.Y - basePitch) * sensitivity / BASELINE_SENSITIVITY);

                        double baseYaw = (warpPoint.X - screenSize.Width / 2.0) / (screenSize.Width / 2.0) * EDGE_X_ROTATION;
                        int xOffset = (int)((currentPoint.X - baseYaw) * sensitivity / BASELINE_SENSITIVITY);

                        warpPoint.Offset(xOffset, yOffset);

                        return warpPoint;
                    }
                    break;
                case (PrecisionPointerMode.TRANSLATION):
                    /*
                    // Disabled because its hard to translate my head up/down when setting in a chair
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

        // Rmove some of the noise from the EyeX by averaging the last few samples. Also subtract the baseline 
        // rotation, since we want the mouse to start moving from the initial head rotation.
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
                // Calculate the change in head rotation, then scale it so we get a noticeable movement
                // Also, it feels more natural to rotate left/right than up/down so scale the latter more
                p.X += (int)((samples[i].Y - calibrationPoint.Y) * -600);
                p.Y += (int)((samples[i].X - calibrationPoint.X) * -1200);
            }
            p.X /= samples.Length;
            p.Y /= samples.Length;

            return p;
        }

        public void Dispose()
        {
            headPoseStream.IsEnabled = false;
        }
    }
}
