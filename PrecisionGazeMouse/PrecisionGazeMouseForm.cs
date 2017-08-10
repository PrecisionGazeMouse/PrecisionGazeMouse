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
        GlobalKeyboardHook _globalKeyboardHook;
        Keys hotKey;

        public PrecisionGazeMouseForm()
        {
            InitializeComponent();
            QuitButton.Select();

            // Set the default mode
            ModeBox.SelectedIndex = 0;
            controller = new MouseController(this);
            controller.setMode((MouseController.Mode)ModeBox.SelectedIndex);
            controller.setMovement(MouseController.Movement.HOTKEY);
            hotKey = Keys.F3;

            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.KeyboardPressed += OnKeyPressed;

            Timer refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Tick += new EventHandler(RefreshScreen);
            refreshTimer.Interval = 33;
            refreshTimer.Start();
        }

        void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            if (e.KeyboardData.VirtualCode == (int)hotKey)
            {
                if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
                {
                    controller.HotKeyDown();
                }
                else if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp)
                {
                    controller.HotKeyUp();
                }

                // don't type the hot key 
                e.Handled = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                _globalKeyboardHook?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void RefreshScreen(Object o, EventArgs e)
        {
            controller.UpdateMouse(Cursor.Position);
            this.Invalidate();
            overlay.Invalidate();
        }

        public void SetMousePosition(Point p)
        {
            Cursor.Position = p;
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
            StatusLabel.Text = controller.GetTrackingStatus();
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
            overlay.ShowIfTracking();
        }

        private void ModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controller == null)
                return;

            System.Windows.Forms.ComboBox box = (System.Windows.Forms.ComboBox)sender;
            switch ((String)box.SelectedItem)
            {
                case "EyeX and TrackIR":
                    controller.setMode(MouseController.Mode.EYEX_AND_TRACKIR);
                    warpBar.Enabled = true;
                    gazeTracker.Enabled = true;
                    overlay.ShowIfTracking();
                    break;
                case "EyeX and SmartNav":
                    controller.setMode(MouseController.Mode.EYEX_AND_SMARTNAV);
                    warpBar.Enabled = true;
                    gazeTracker.Enabled = true;
                    overlay.ShowIfTracking();
                    break;
                case "EyeX Only":
                    controller.setMode(MouseController.Mode.EYEX_ONLY);
                    warpBar.Enabled = true;
                    gazeTracker.Enabled = true;
                    overlay.ShowIfTracking();
                    break;
                case "TrackIR Only":
                    controller.setMode(MouseController.Mode.TRACKIR_ONLY);
                    warpBar.Enabled = false;
                    gazeTracker.Enabled = false;
                    overlay.Hide();
                    break;
                default:
                    break;
            }
        }

        private void warpBar_CheckedChanged(object sender, EventArgs e)
        {
            overlay.ShowWarpBar = warpBar.Checked;
            overlay.ShowIfTracking();
        }

        private void gazeTracker_CheckedChanged(object sender, EventArgs e)
        {
            overlay.ShowGazeTracker = gazeTracker.Checked;
            overlay.ShowIfTracking();
        }

        private void OnKeyPressButton_Click(object sender, EventArgs e)
        {
            ContinuousButton.Checked = false;
            controller.setMovement(MouseController.Movement.HOTKEY);
        }

        private void ContinuousButton_Click(object sender, EventArgs e)
        {
            OnKeyPressButton.Checked = false;
            controller.setMovement(MouseController.Movement.CONTINUOUS);
        }

        private void OnKeyPressInput_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            OnKeyPressInput.Text = e.KeyCode.ToString();
            hotKey = e.KeyCode;
        }
    }
}
