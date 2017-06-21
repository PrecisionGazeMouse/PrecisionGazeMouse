//-----------------------------------------------------------------------
// Copyright 2014 Tobii Technology AB. All rights reserved.
//-----------------------------------------------------------------------

using System.Windows.Forms;
using System;
using System.Drawing;
using System.Reflection;
using System.Collections.Generic;

namespace PrecisionGazeMouse
{
    public partial class PrecisionGazeMouseForm : Form
    {
        MouseController controller;
        OverlayForm overlay;

        public PrecisionGazeMouseForm()
        {
            InitializeComponent();
            QuitButton.Select();

            // Set the default mode
            ModeBox.SelectedIndex = 0;
            controller = new MouseController();
            controller.setMode((MouseController.Mode)ModeBox.SelectedIndex);

            Timer myTimer = new System.Windows.Forms.Timer();
            myTimer.Tick += new EventHandler(RefreshScreen);
            myTimer.Interval = 33;
            myTimer.Start();
        }

        private void RefreshScreen(Object o, EventArgs e)
        {
            Cursor.Position = controller.UpdateMouse(Cursor.Position);
            this.Invalidate();
            overlay.Invalidate();
        }

        public static Rectangle GetScreenSize()
        {
            return Screen.PrimaryScreen.Bounds;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Update Labels
            PositionLabel.Text = controller.WarpPointer.ToString();
            HeadRotationLabel.Text = controller.PrecisionPointer.ToString();
            StateLabel.Text = controller.GetTrackingState();
            SamplesLabel.Text = controller.WarpPointer.GetSampleCount().ToString();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GazeAwareForm_Load(object sender, EventArgs e)
        {
            overlay = new OverlayForm(controller);
            overlay.ShowWarpBar = warpBar.Checked;
            overlay.ShowGazeTracker = gazeTracker.Checked;
            overlay.Show();
        }

        private void ModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controller == null)
                return;

            System.Windows.Forms.ComboBox box = (System.Windows.Forms.ComboBox)sender;
            switch ((String)box.SelectedItem)
            {
                case "EyeX and TrackIR":
                    controller.setMode(MouseController.Mode.TRACKIR_AND_EYEX);
                    break;
                case "EyeX Only":
                    controller.setMode(MouseController.Mode.EYEX_ONLY);
                    break;
                case "TrackIR Only":
                    controller.setMode(MouseController.Mode.TRACKIR_ONLY);
                    break;
                default:
                    break;
            }
        }

        private void warpBar_CheckedChanged(object sender, EventArgs e)
        {
            overlay.ShowWarpBar = warpBar.Checked;
        }

        private void gazeTracker_CheckedChanged(object sender, EventArgs e)
        {
            overlay.ShowGazeTracker = gazeTracker.Checked;
        }
    }
}
