using System;
using System.Drawing;
using PrecisionGazeMouse.PrecisionPointers;
using PrecisionGazeMouse.WarpPointers;

namespace PrecisionGazeMouse
{
    class MouseController
    {
        WarpPointer warp;
        PrecisionPointer prec;
        Point finalPoint;
        DateTime pauseTime;
        Point lastCursorPosition;
        GazeCalibrator calibrator;

        public enum Mode
        {
            TRACKIR_AND_EYEX,
            EYEX_ONLY,
            TRACKIR_ONLY
        };

        enum TrackingState
        {
            STARTING,
            PAUSED,
            RUNNING,
            ERROR
        };
        TrackingState state;
        
        public MouseController()
        {
        }

        public void setMode(Mode mode)
        {
            if (warp != null)
                warp.Dispose();
            if (prec != null)
                prec.Dispose();

            switch(mode)
            {
                case Mode.TRACKIR_AND_EYEX:
                    warp = new EyeXWarpPointer();
                    prec = new TrackIRPrecisionPointer(.25);
                    break;
                case Mode.TRACKIR_ONLY:
                    warp = new NoWarpPointer(getScreenCenter());
                    prec = new TrackIRPrecisionPointer(.7);
                    break;
                case Mode.EYEX_ONLY:
                    warp = new EyeXWarpPointer();
                    prec = new EyeXPrecisionPointer();
                    break;
            }

            calibrator = new GazeCalibrator(this, warp);

            if (!warp.IsStarted())
                state = TrackingState.ERROR;

            if (!prec.IsStarted())
                state = TrackingState.ERROR;
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
                    if (PrecisionGazeMouseForm.MousePosition != finalPoint)
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

        private Point getScreenCenter()
        {
            Rectangle screenSize = PrecisionGazeMouseForm.GetScreenSize();
            return new Point(screenSize.Width / 2, screenSize.Height / 2);
        }

        private Point limitToScreenBounds(Point p)
        {
            Rectangle screenSize = PrecisionGazeMouseForm.GetScreenSize();

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
