namespace PrecisionGazeMouse
{
    partial class PrecisionGazeMouseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrecisionGazeMouseForm));
            this.PositionLabel = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HeadRotationLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ClickOnKey = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.PauseOnKey = new System.Windows.Forms.Label();
            this.PauseOnKeyInput = new System.Windows.Forms.TextBox();
            this.ClickOnKeyInput = new System.Windows.Forms.TextBox();
            this.SensitivityInput = new System.Windows.Forms.TrackBar();
            this.MovementOnKeyPressInput = new System.Windows.Forms.TextBox();
            this.OnKeyPressButton = new System.Windows.Forms.RadioButton();
            this.ContinuousButton = new System.Windows.Forms.RadioButton();
            this.gazeTracker = new System.Windows.Forms.CheckBox();
            this.warpBar = new System.Windows.Forms.CheckBox();
            this.ModeBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.SensitivityInput)).BeginInit();
            this.SuspendLayout();
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Location = new System.Drawing.Point(97, 233);
            this.PositionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(31, 13);
            this.PositionLabel.TabIndex = 8;
            this.PositionLabel.Text = "(0, 0)";
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(113, 287);
            this.QuitButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(56, 19);
            this.QuitButton.TabIndex = 10;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 233);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Gaze Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 257);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Head Rotation";
            // 
            // HeadRotationLabel
            // 
            this.HeadRotationLabel.AutoSize = true;
            this.HeadRotationLabel.Location = new System.Drawing.Point(97, 257);
            this.HeadRotationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HeadRotationLabel.Name = "HeadRotationLabel";
            this.HeadRotationLabel.Size = new System.Drawing.Size(31, 13);
            this.HeadRotationLabel.TabIndex = 12;
            this.HeadRotationLabel.Text = "(0, 0)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 209);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Status";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(97, 209);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(43, 13);
            this.StatusLabel.TabIndex = 14;
            this.StatusLabel.Text = "Starting";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tracker Mode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Movement";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 169);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Sensitivity";
            // 
            // ClickOnKey
            // 
            this.ClickOnKey.AutoSize = true;
            this.ClickOnKey.Location = new System.Drawing.Point(25, 103);
            this.ClickOnKey.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ClickOnKey.Name = "ClickOnKey";
            this.ClickOnKey.Size = new System.Drawing.Size(68, 13);
            this.ClickOnKey.TabIndex = 28;
            this.ClickOnKey.Text = "Click On Key";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Precision Gaze Mouse";
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // PauseOnKey
            // 
            this.PauseOnKey.AutoSize = true;
            this.PauseOnKey.Location = new System.Drawing.Point(19, 133);
            this.PauseOnKey.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PauseOnKey.Name = "PauseOnKey";
            this.PauseOnKey.Size = new System.Drawing.Size(75, 13);
            this.PauseOnKey.TabIndex = 30;
            this.PauseOnKey.Text = "Pause On Key";
            // 
            // PauseOnKeyInput
            // 
            this.PauseOnKeyInput.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PrecisionGazeMouse.Properties.Settings.Default, "PauseOnKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PauseOnKeyInput.Location = new System.Drawing.Point(97, 131);
            this.PauseOnKeyInput.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PauseOnKeyInput.Name = "PauseOnKeyInput";
            this.PauseOnKeyInput.Size = new System.Drawing.Size(77, 20);
            this.PauseOnKeyInput.TabIndex = 6;
            this.PauseOnKeyInput.Text = global::PrecisionGazeMouse.Properties.Settings.Default.PauseOnKey;
            this.PauseOnKeyInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PauseOnKeyInput_KeyDown);
            // 
            // ClickOnKeyInput
            // 
            this.ClickOnKeyInput.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PrecisionGazeMouse.Properties.Settings.Default, "ClickOnKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ClickOnKeyInput.Location = new System.Drawing.Point(99, 101);
            this.ClickOnKeyInput.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ClickOnKeyInput.Name = "ClickOnKeyInput";
            this.ClickOnKeyInput.Size = new System.Drawing.Size(76, 20);
            this.ClickOnKeyInput.TabIndex = 5;
            this.ClickOnKeyInput.Text = global::PrecisionGazeMouse.Properties.Settings.Default.ClickOnKey;
            this.ClickOnKeyInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnClickKeyPressInput_KeyDown);
            // 
            // SensitivityInput
            // 
            this.SensitivityInput.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::PrecisionGazeMouse.Properties.Settings.Default, "Sensitivity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SensitivityInput.Location = new System.Drawing.Point(95, 162);
            this.SensitivityInput.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SensitivityInput.Maximum = 20;
            this.SensitivityInput.Name = "SensitivityInput";
            this.SensitivityInput.Size = new System.Drawing.Size(201, 45);
            this.SensitivityInput.TabIndex = 7;
            this.SensitivityInput.Value = global::PrecisionGazeMouse.Properties.Settings.Default.Sensitivity;
            this.SensitivityInput.Scroll += new System.EventHandler(this.SensitivityInput_Scroll);
            // 
            // MovementOnKeyPressInput
            // 
            this.MovementOnKeyPressInput.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PrecisionGazeMouse.Properties.Settings.Default, "MovementKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MovementOnKeyPressInput.Location = new System.Drawing.Point(192, 68);
            this.MovementOnKeyPressInput.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MovementOnKeyPressInput.Name = "MovementOnKeyPressInput";
            this.MovementOnKeyPressInput.Size = new System.Drawing.Size(76, 20);
            this.MovementOnKeyPressInput.TabIndex = 4;
            this.MovementOnKeyPressInput.Text = global::PrecisionGazeMouse.Properties.Settings.Default.MovementKey;
            this.MovementOnKeyPressInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MovementOnKeyPressButton_Click);
            // 
            // OnKeyPressButton
            // 
            this.OnKeyPressButton.AutoSize = true;
            this.OnKeyPressButton.Checked = global::PrecisionGazeMouse.Properties.Settings.Default.OnKeyPressMovement;
            this.OnKeyPressButton.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrecisionGazeMouse.Properties.Settings.Default, "OnKeyPressMovement", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.OnKeyPressButton.Location = new System.Drawing.Point(99, 68);
            this.OnKeyPressButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.OnKeyPressButton.Name = "OnKeyPressButton";
            this.OnKeyPressButton.Size = new System.Drawing.Size(89, 17);
            this.OnKeyPressButton.TabIndex = 3;
            this.OnKeyPressButton.TabStop = true;
            this.OnKeyPressButton.Text = "On Key Press";
            this.OnKeyPressButton.UseVisualStyleBackColor = true;
            this.OnKeyPressButton.Click += new System.EventHandler(this.OnKeyPressButton_Click);
            // 
            // ContinuousButton
            // 
            this.ContinuousButton.AutoSize = true;
            this.ContinuousButton.Checked = global::PrecisionGazeMouse.Properties.Settings.Default.ContinuousMovement;
            this.ContinuousButton.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrecisionGazeMouse.Properties.Settings.Default, "ContinuousMovement", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ContinuousButton.Location = new System.Drawing.Point(99, 46);
            this.ContinuousButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ContinuousButton.Name = "ContinuousButton";
            this.ContinuousButton.Size = new System.Drawing.Size(78, 17);
            this.ContinuousButton.TabIndex = 2;
            this.ContinuousButton.Text = "Continuous";
            this.ContinuousButton.UseVisualStyleBackColor = true;
            this.ContinuousButton.Click += new System.EventHandler(this.ContinuousButton_Click);
            // 
            // gazeTracker
            // 
            this.gazeTracker.AutoSize = true;
            this.gazeTracker.Checked = global::PrecisionGazeMouse.Properties.Settings.Default.ShowGazeTracker;
            this.gazeTracker.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrecisionGazeMouse.Properties.Settings.Default, "ShowGazeTracker", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gazeTracker.Location = new System.Drawing.Point(179, 231);
            this.gazeTracker.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gazeTracker.Name = "gazeTracker";
            this.gazeTracker.Size = new System.Drawing.Size(121, 17);
            this.gazeTracker.TabIndex = 9;
            this.gazeTracker.Text = "Show Gaze Tracker";
            this.gazeTracker.UseVisualStyleBackColor = true;
            this.gazeTracker.CheckedChanged += new System.EventHandler(this.gazeTracker_CheckedChanged);
            // 
            // warpBar
            // 
            this.warpBar.AutoSize = true;
            this.warpBar.Checked = global::PrecisionGazeMouse.Properties.Settings.Default.ShowWarpBar;
            this.warpBar.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PrecisionGazeMouse.Properties.Settings.Default, "ShowWarpBar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.warpBar.Location = new System.Drawing.Point(179, 209);
            this.warpBar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.warpBar.Name = "warpBar";
            this.warpBar.Size = new System.Drawing.Size(101, 17);
            this.warpBar.TabIndex = 8;
            this.warpBar.Text = "Show Warp Bar";
            this.warpBar.UseVisualStyleBackColor = true;
            this.warpBar.CheckedChanged += new System.EventHandler(this.warpBar_CheckedChanged);
            // 
            // ModeBox
            // 
            this.ModeBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PrecisionGazeMouse.Properties.Settings.Default, "TrackerMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeBox.FormattingEnabled = true;
            this.ModeBox.Items.AddRange(new object[] {
            "EyeX and eViacam",
            "EyeX and TrackIR",
            "EyeX and SmartNav",
            "EyeX Only",
            "TrackIR Only",
            "eViacam Only"});
            this.ModeBox.Location = new System.Drawing.Point(99, 14);
            this.ModeBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ModeBox.Name = "ModeBox";
            this.ModeBox.Size = new System.Drawing.Size(197, 21);
            this.ModeBox.TabIndex = 1;
            this.ModeBox.Text = global::PrecisionGazeMouse.Properties.Settings.Default.TrackerMode;
            this.ModeBox.SelectedIndexChanged += new System.EventHandler(this.ModeBox_SelectedIndexChanged);
            // 
            // PrecisionGazeMouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 322);
            this.Controls.Add(this.PauseOnKeyInput);
            this.Controls.Add(this.PauseOnKey);
            this.Controls.Add(this.ClickOnKeyInput);
            this.Controls.Add(this.ClickOnKey);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SensitivityInput);
            this.Controls.Add(this.MovementOnKeyPressInput);
            this.Controls.Add(this.OnKeyPressButton);
            this.Controls.Add(this.ContinuousButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gazeTracker);
            this.Controls.Add(this.warpBar);
            this.Controls.Add(this.ModeBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HeadRotationLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.PositionLabel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrecisionGazeMouseForm";
            this.Text = "Precision Gaze Mouse v1.14";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrecisionGazeMouseForm_FormClosing);
            this.Resize += new System.EventHandler(this.PrecisionGazeMouseForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.SensitivityInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label HeadRotationLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ModeBox;
        private System.Windows.Forms.CheckBox warpBar;
        private System.Windows.Forms.CheckBox gazeTracker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton ContinuousButton;
        private System.Windows.Forms.RadioButton OnKeyPressButton;
        private System.Windows.Forms.TextBox MovementOnKeyPressInput;
        private System.Windows.Forms.TrackBar SensitivityInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label ClickOnKey;
        private System.Windows.Forms.TextBox ClickOnKeyInput;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TextBox PauseOnKeyInput;
        private System.Windows.Forms.Label PauseOnKey;
    }
}

