using System;
using System.Drawing;
using PrecisionGazeMouse.PrecisionPointers;
using PrecisionGazeMouse.WarpPointers;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
        bool updatedAtLeastOnce;

        public enum Mode
        {
            EYEX_AND_TRACKIR,
            EYEX_AND_SMARTNAV,
            EYEX_ONLY,
            TRACKIR_ONLY
        };
        Mode mode;

        public enum Movement
        {
            CONTINUOUS,
            HOTKEY
        };
        Movement movement;
        bool hotKeyDown = false;
        bool dragging = false;
        DateTime? timeSinceKeyUp;
        Point? lastClick;

        enum TrackingState
        {
            STARTING,
            PAUSED,
            RUNNING,
            ERROR
        };
        TrackingState state;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public MouseController(PrecisionGazeMouseForm form)
        {
            this.form = form;
        }

        public void setMovement(Movement movement)
        {
            this.movement = movement;
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
                    prec = new TrackIRPrecisionPointer(PrecisionPointerMode.ROTATION, .3);
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
        
        public void HotKeyDown()
        {
            if (movement != Movement.HOTKEY || state == TrackingState.ERROR || state == TrackingState.PAUSED)
                return;

            if (!hotKeyDown)
            {
                if (!dragging && timeSinceKeyUp != null && System.DateTime.Now.Subtract(timeSinceKeyUp.Value).TotalMilliseconds < 250)
                {
                    // it's a drag so click down and hold
                    uint X = (uint)lastClick.Value.X;
                    uint Y = (uint)lastClick.Value.Y;
                    mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
                    dragging = true;
                }
                else if(!dragging)
                {
                    warp.RefreshTracking();
                    state = TrackingState.STARTING;
                    updatedAtLeastOnce = false;
                }
            }
            hotKeyDown = true;
        }

        public void HotKeyUp()
        {
            if (movement != Movement.HOTKEY || state == TrackingState.ERROR || state == TrackingState.PAUSED)
                return;

            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;

            if (dragging)
            {
                mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                dragging = false;
            }
            else
            {
                if (timeSinceKeyUp != null && System.DateTime.Now.Subtract(timeSinceKeyUp.Value).TotalMilliseconds < 500)
                {
                    // it's a double click so use the original click position
                    X = (uint)lastClick.Value.X;
                    Y = (uint)lastClick.Value.Y;
                }
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                lastClick = Cursor.Position;
            }

            timeSinceKeyUp = System.DateTime.Now;
            hotKeyDown = false;
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
                    if(movement == Movement.HOTKEY)
                    {
                        if (updatedAtLeastOnce && !hotKeyDown)
                            break;
                    }
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
                    updatedAtLeastOnce = true;
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
            int margin = 5;

            if (p.X < margin)
                p.X = margin;
            if (p.Y < margin)
                p.Y = margin;
            if (p.X >= screenSize.Width - margin)
                p.X = screenSize.Width - margin;
            if (p.Y >= screenSize.Height - margin - 5)
                p.Y = screenSize.Height - margin - 5;

            return p;
        }
    }
}
