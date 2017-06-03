using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing;
using GazePlusMouse.PrecisionPointers;

namespace GazePlusMouse
{
    class MouseController
    {
        WarpPointer warp;
        PrecisionPointer prec;
        Point finalPoint;
        DateTime pauseTime;
        Point lastCursorPosition;
        enum TrackingState
        {
            STARTING,
            PAUSED,
            RUNNING,
            ERROR
        };
        TrackingState state;
        GazeCalibrator calibrator;

        public MouseController()
        {
            warp = new EyeXWarpPointer();
            prec = new TrackIRPrecisionPointer();

            if (!warp.IsStarted())
                state = TrackingState.ERROR;

            if (!prec.IsStarted())
                state = TrackingState.ERROR;

            calibrator = new GazeCalibrator(this, warp);
        }

        public WarpPointer WarpPointer
        {
            get { return warp; }
        }

        public PrecisionPointer PrecisionPointer
        {
            get { return prec; }
        }

        public Point GetFinalPoint()
        {
            return finalPoint;
        }

        public GazeCalibrator GazeCalibrator
        {
            get { return calibrator; }
        }

        public String GetTrackingState()
        {
            switch (state)
            {
                case TrackingState.STARTING:
                    return "Starting";
                case TrackingState.RUNNING:
                    return "Running";
                case TrackingState.PAUSED:
                    return "Paused";
                case TrackingState.ERROR:
                    if (!warp.IsStarted())
                        return "No EyeX connection";
                    if (!prec.IsStarted())
                        return "No TrackIR connection";
                    return "Error";
            }
            return "";
        }

        public Point UpdateMouse(Point currentPoint)
        {
            switch (state)
            {
                case TrackingState.STARTING:
                    if (warp.IsWarpReady())
                    {
                        state = TrackingState.RUNNING;
                        finalPoint = currentPoint;
                    }
                    break;
                case TrackingState.RUNNING:
                    if (GazePlusMouseForm.MousePosition != finalPoint)
                    {
                        state = TrackingState.PAUSED;
                        pauseTime = System.DateTime.Now;
                        return currentPoint;
                    }
                    Point warpPoint = warp.GetNextPoint(currentPoint);
                    finalPoint = prec.GetNextPoint(warpPoint);
                    finalPoint = limitToScreenBounds(finalPoint);
                    return finalPoint;
                case TrackingState.PAUSED:
                    // Keep pausing if the user is still moving the mouse
                    if (lastCursorPosition != currentPoint)
                    {
                        lastCursorPosition = currentPoint;
                        pauseTime = System.DateTime.Now;
                    }
                    if (System.DateTime.Now.CompareTo(pauseTime.AddSeconds(1)) > 0)
                        state = TrackingState.STARTING;
                    break;
                case TrackingState.ERROR:
                    if (warp.IsStarted() && prec.IsStarted())
                        state = TrackingState.STARTING;
                    break;
            }

            return currentPoint;
        }

        private Point limitToScreenBounds(Point p)
        {
            Rectangle screenSize = GazePlusMouseForm.GetScreenSize();

            if (p.X < 0)
                p.X = 0;
            if (p.Y < 0)
                p.Y = 0;
            if (p.X >= screenSize.Width)
                p.X = screenSize.Width - 1;
            if (p.Y >= screenSize.Height)
                p.Y = screenSize.Height - 1;

            return p;
        }
    }
}
