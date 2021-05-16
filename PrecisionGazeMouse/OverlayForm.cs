using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrecisionGazeMouse
{
    partial class OverlayForm : Form
    {
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_SHOWWINDOW = 0x0040;
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        const int BAR_LENGTH = 25;
        const int BAR_DIST_BELOW = 40;
        const int BAR_HEIGHT = 2;
        const int BAR_OFFSETX = 12;

        MouseController controller;
        bool gazeTracker;
        bool warpBar;

        public OverlayForm(MouseController controller)
        {
            InitializeComponent();
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, (SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW));

            this.controller = controller;
        }

        public bool ShowWarpBar
        {
            get { return warpBar; }
            set { warpBar = value; }
        }

        public bool ShowGazeTracker
        {
            get { return gazeTracker; }
            set { gazeTracker = value; }
        }

        public void ShowIfTracking()
        {
            if (gazeTracker || warpBar)
                Show();
            else
                Hide();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Point p;
            Rectangle rec;

            // Skip if no warp to paint
            int threshold = controller.WarpPointer.Sensitivity;
            if (threshold == 0)
                return;

            if (gazeTracker)
            {
                // Warp threshold
                p = controller.WarpPointer.GetWarpPoint();
                rec = new Rectangle(p.X - threshold, p.Y - threshold, threshold * 2, threshold * 2);
                e.Graphics.DrawEllipse(Pens.Gray, rec);

                // Gaze point
                p = controller.WarpPointer.GetGazePoint();
                rec = new Rectangle(p.X - 5, p.Y - 5, 10, 10);
                e.Graphics.FillEllipse(Brushes.Gray, rec);
            }

            if (warpBar)
            {
                Point delta = Point.Subtract(controller.WarpPointer.GetGazePoint(), new Size(controller.WarpPointer.GetWarpPoint()));
                double ratio = Math.Sqrt(Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2)) / threshold;
                if (ratio > 1)
                    ratio = 1;

                // draw warp bar
                p = controller.GetFinalPoint();
                rec = new Rectangle(p.X + BAR_OFFSETX - BAR_LENGTH / 2, p.Y + BAR_DIST_BELOW, (int)(BAR_LENGTH * ratio), BAR_HEIGHT);
                e.Graphics.FillRectangle(Brushes.Blue, rec);
                rec = new Rectangle(p.X + BAR_OFFSETX - BAR_LENGTH / 2 + (int)(BAR_LENGTH * ratio), p.Y + BAR_DIST_BELOW, BAR_LENGTH - (int)(BAR_LENGTH * ratio), BAR_HEIGHT);
                e.Graphics.FillRectangle(Brushes.LightGray, rec);
            }

            // data points for calibration
            List<Event> events = controller.GazeCalibrator.GetEvents();
            foreach (Event evt in events)
            {
                p = evt.location;
                rec = new Rectangle(p.X - 5, p.Y - 5, 10, 10);
                e.Graphics.FillRectangle(Brushes.Blue, rec);
                e.Graphics.DrawLine(Pens.Blue, p, Point.Add(p, new Size(evt.delta)));
            }
        }
    }
}
