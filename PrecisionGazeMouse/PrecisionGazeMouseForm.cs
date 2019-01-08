//-----------------------------------------------------------------------
// Copyright 2014 Tobii Technology AB. All rights reserved.
//-----------------------------------------------------------------------

using System.Windows.Forms;
using System;
using System.Drawing;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Input;

namespace PrecisionGazeMouse
{
    public partial class PrecisionGazeMouseForm : Form
    {
        MouseController controller;
        OverlayForm overlay;
        GlobalKeyboardHook _globalKeyboardHook;
        Keys movementHotKey;
        Keys clickHotKey;
        Keys pauseHotKey;
        Keys eViacamKey;
        bool isKeyDown;

        public PrecisionGazeMouseForm()
        {
            InitializeComponent();
            QuitButton.Select();

            // Set the default mode
            ModeBox.SelectedIndex = 0;
            controller = new MouseController(this);
            controller.setMode(MouseController.Mode.EYEX_AND_EVIACAM);
            controller.setMovement(MouseController.Movement.HOTKEY);
            controller.Sensitivity = SensitivityInput.Value;
            movementHotKey = (Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.MovementKey);
            clickHotKey = (Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.ClickOnKey);
            pauseHotKey = (Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.PauseOnKey);
            eViacamKey = (Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.eViacamKey);

            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.KeyboardPressed += OnKeyPressed;

            overlay = new OverlayForm(controller);
            overlay.ShowWarpBar = warpBar.Checked;
            overlay.ShowGazeTracker = gazeTracker.Checked;
            overlay.ShowIfTracking();

            Timer refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Tick += new EventHandler(RefreshScreen);
            refreshTimer.Interval = 33;
            refreshTimer.Start();
        }

        public bool IsKeyDown()
        {
            return Keyboard.IsKeyDown((Key)eViacamKey) || Keyboard.IsKeyDown((Key)movementHotKey));
        }

        void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            Keys key = (Keys)e.KeyboardData.VirtualCode;
            if (key == movementHotKey || key == clickHotKey || key == pauseHotKey)
            {
                if (key == movementHotKey)
                {
                    if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
                    {
                        if (ClickOnKeyInput.Focused)
                        {
                            ClickOnKeyInput.Text = key.ToString();
                            clickHotKey = key;
                        }
                        controller.MovementHotKeyDown();
                    }
                    else if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp)
                    {
                        controller.MovementHotKeyUp();
                    }

                    // don't type the hot key 
                    e.Handled = true;
                }

                // Can use the same hotkey for movement and clicking
                if (key == clickHotKey)
                {
                    if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
                    {
                        if (MovementOnKeyPressInput.Focused)
                        {
                            MovementOnKeyPressInput.Text = key.ToString();
                            movementHotKey = key;
                        }
                        controller.ClickHotKeyDown();
                    }
                    else if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp)
                    {
                        controller.ClickHotKeyUp();
                    }

                    // don't type the hot key 
                    e.Handled = true;
                }

                if (key == pauseHotKey)
                {
                    if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
                    {
                        if (MovementOnKeyPressInput.Focused)
                        {
                            PauseOnKeyInput.Text = key.ToString();
                            pauseHotKey = key;
                        }
                        controller.PauseHotKeyDown();
                    }

                    // don't type the hot key 
                    e.Handled = true;
                }
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

        private void eViacamPrompt(bool enabled)
        {
            string message;
            if(enabled)
                message = "If you are using eViacam, press OK when it's enabled. Otherwise, click Cancel.";
            else
                message = "If you are using eViacam, press OK when it's running but disabled. Otherwise, click Cancel.";

            string caption = "Check eViacam";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            MessageBox.Show(this, message, caption, buttons);
        }

        private void ModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controller == null)
                return;

            System.Windows.Forms.ComboBox box = (System.Windows.Forms.ComboBox)sender;
            switch ((String)box.SelectedItem)
            {
                case "EyeX and eViacam":
                    controller.setMode(MouseController.Mode.EYEX_AND_EVIACAM);
                    warpBar.Enabled = true;
                    gazeTracker.Enabled = true;
                    overlay.ShowIfTracking();
                    eViacamPrompt(ContinuousButton.Checked);
                    break;
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
                case "eViacam Only":
                    controller.setMode(MouseController.Mode.EVIACAM_ONLY);
                    warpBar.Enabled = true;
                    gazeTracker.Enabled = true;
                    overlay.ShowIfTracking();
                    eViacamPrompt(ContinuousButton.Checked);
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

            if (ModeBox.SelectedItem.ToString() == "EyeX and eViacam")
                eViacamPrompt(false);
        }

        private void ContinuousButton_Click(object sender, EventArgs e)
        {
            OnKeyPressButton.Checked = false;
            controller.setMovement(MouseController.Movement.CONTINUOUS);

            if(ModeBox.SelectedItem.ToString() == "EyeX and eViacam")
                eViacamPrompt(true);
        }

        private void OnClickKeyPressInput_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            if (e.KeyCode.Equals(Keys.Escape) || e.KeyCode.Equals(Keys.Back))
            {
                ClickOnKeyInput.Text = "";
                clickHotKey = 0;
            }
            else
            {
                ClickOnKeyInput.Text = e.KeyCode.ToString();
                clickHotKey = e.KeyCode;
            }
        }

        private void MovementOnKeyPressButton_Click(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            MovementOnKeyPressInput.Text = e.KeyCode.ToString();
            movementHotKey = e.KeyCode;
        }

        private void SensitivityInput_Scroll(object sender, EventArgs e)
        {
            controller.Sensitivity = SensitivityInput.Value;
        }

        private void PrecisionGazeMouseForm_Shown(object sender, EventArgs e)
        {
            eViacamPrompt(false);
        }

        private void PrecisionGazeMouseForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void PauseOnKeyInput_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            if (e.KeyCode.Equals(Keys.Escape) || e.KeyCode.Equals(Keys.Back))
            {
                PauseOnKeyInput.Text = "";
                pauseHotKey = 0;
            }
            else
            {
                PauseOnKeyInput.Text = e.KeyCode.ToString();
                pauseHotKey = e.KeyCode;
            }
        }

        private void PrecisionGazeMouseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.TrackerMode = ModeBox.Text;
            Properties.Settings.Default.ContinuousMovement = ContinuousButton.Checked;
            Properties.Settings.Default.OnKeyPressMovement = OnKeyPressButton.Checked;
            Properties.Settings.Default.MovementKey = MovementOnKeyPressInput.Text;
            Properties.Settings.Default.ClickOnKey = ClickOnKeyInput.Text;
            Properties.Settings.Default.PauseOnKey = PauseOnKeyInput.Text;
            Properties.Settings.Default.Sensitivity = SensitivityInput.Value;
            Properties.Settings.Default.ShowWarpBar = warpBar.Checked;
            Properties.Settings.Default.ShowGazeTracker = gazeTracker.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
