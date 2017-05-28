using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Gma.System.MouseKeyHook;
using System.IO;

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

        public GazeCalibrator(MouseController controller, WarpPointer warp)
        {
            this.controller = controller;
            this.warp = warp;
            events = new List<Event>();

            mouseGlobalHook = Hook.GlobalEvents();
            mouseGlobalHook.MouseDownExt += GlobalHookMouseDownExt;
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
