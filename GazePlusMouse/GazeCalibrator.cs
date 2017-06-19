using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gma.System.MouseKeyHook;
using System.IO;
using GazePlusMouse.WarpPointers;

namespace GazePlusMouse
{
    public struct Event
    {
        public System.DateTime time;
        public Point location;
        public Point delta;
    }

    class GazeCalibrator
    {
        IKeyboardMouseEvents mouseGlobalHook;
        WarpPointer warp;
        MouseController controller;
        List<Event> events;
        bool saveCalibration = false;

        public GazeCalibrator(MouseController controller, WarpPointer warp)
        {
            this.controller = controller;
            this.warp = warp;
            events = new List<Event>();

            if (saveCalibration)
            {
                mouseGlobalHook = Hook.GlobalEvents();
                mouseGlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            }
        }

        public List<Event> GetEvents()
        {
            return events;
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            if (controller.GetTrackingState() == "Running")
            {
                Point curr = new Point(e.X, e.Y);
                Point gaze = warp.calculateSmoothedPoint();
                Point d = Point.Subtract(gaze, new Size(curr));

                Event evt = new Event() { time = System.DateTime.Now, location = curr, delta = d };
                events.Add(evt);
                
                var csv = new StringBuilder();
                var newLine = string.Format("{0},{1},{2},{3},{4}", System.DateTime.Now, curr.X, curr.Y, d.X, d.Y);
                csv.AppendLine(newLine);
                File.AppendAllText("CalibrationData.csv", csv.ToString());
            }
        }
    }
}
