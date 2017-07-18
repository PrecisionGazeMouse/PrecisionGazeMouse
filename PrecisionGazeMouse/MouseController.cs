using System;
using System.Drawing;
using PrecisionGazeMouse.PrecisionPointers;
using PrecisionGazeMouse.WarpPointers;
using System.Windows.Forms;

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
        PrecisionGazeMouseForm form;

        public enum Mode
        {
            EYEX_AND_TRACKIR,
            EYEX_AND_SMARTNAV,
            EYEX_ONLY,
            TRACKIR_ONLY
        };
        Mode mode;

        enum TrackingState
        {
            STARTING,
            PAUSED,
            RUNNING,
            ERROR
        };
        TrackingState state;
        
        public MouseController(PrecisionGazeMouseForm form)
        {
            this.form = form;
        }

        public void setMode(Mode mode)
        {
            if (warp != null)
                warp.Dispose();
            if (prec != null)
                prec.Dispose();

            this.mode = mode;
            switch(mode)
            {
                case Mode.EYEX_AND_TRACKIR:
                    warp = new EyeXWarpPointer();
                    prec = new TrackIRPrecisionPointer(PrecisionPointerMode.ROTATION, .25);
                    break;
                case Mode.EYEX_AND_SMARTNAV:
                    warp = new EyeXWarpPointer();
                    prec = new NoPrecisionPointer();
                    state = TrackingState.RUNNING;
                    break;
                case Mode.TRACKIR_ONLY:
                    warp = new NoWarpPointer(getScreenCenter());
                    prec = new TrackIRPrecisionPointer(PrecisionPointerMode.BOTH, .65);
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

        public String GetTrackingStatus()
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

        public void UpdateMouse(Point currentPoint)
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
                    Point warpPoint = warp.GetNextPoint(currentPoint);
                    if (mode == Mode.EYEX_AND_SMARTNAV)
                    {
                        warpPoint = limitToScreenBounds(warpPoint);
                        if (warpPoint != finalPoint)
                        {
                            finalPoint = warpPoint;
                            form.SetMousePosition(finalPoint);
                        }
                    }
                    else
                    {
                        if (PrecisionGazeMouseForm.MousePosition != finalPoint)
                        {
                            state = TrackingState.PAUSED;
                            pauseTime = System.DateTime.Now;
                        }
                        finalPoint = prec.GetNextPoint(warpPoint);
                        finalPoint = limitToScreenBounds(finalPoint);
                        form.SetMousePosition(finalPoint);
                    }
                    break;
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
