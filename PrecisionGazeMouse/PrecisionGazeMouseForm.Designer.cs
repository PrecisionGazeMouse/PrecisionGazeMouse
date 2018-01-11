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
            this.ModeBox = new System.Windows.Forms.ComboBox();
            this.warpBar = new System.Windows.Forms.CheckBox();
            this.gazeTracker = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ContinuousButton = new System.Windows.Forms.RadioButton();
            this.OnKeyPressButton = new System.Windows.Forms.RadioButton();
            this.MovementOnKeyPressInput = new System.Windows.Forms.TextBox();
            this.SensitivityInput = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.ClickOnKey = new System.Windows.Forms.Label();
            this.ClickOnKeyInput = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SensitivityInput)).BeginInit();
            this.SuspendLayout();
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Location = new System.Drawing.Point(129, 250);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(42, 17);
            this.PositionLabel.TabIndex = 8;
            this.PositionLabel.Text = "(0, 0)";
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(151, 318);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(75, 23);
            this.QuitButton.TabIndex = 9;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Gaze Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Head Rotation";
            // 
            // HeadRotationLabel
            // 
            this.HeadRotationLabel.AutoSize = true;
            this.HeadRotationLabel.Location = new System.Drawing.Point(129, 280);
            this.HeadRotationLabel.Name = "HeadRotationLabel";
            this.HeadRotationLabel.Size = new System.Drawing.Size(42, 17);
            this.HeadRotationLabel.TabIndex = 12;
            this.HeadRotationLabel.Text = "(0, 0)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Status";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(129, 222);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(57, 17);
            this.StatusLabel.TabIndex = 14;
            this.StatusLabel.Text = "Starting";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tracker Mode";
            // 
            // ModeBox
            // 
            this.ModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeBox.FormattingEnabled = true;
            this.ModeBox.Items.AddRange(new object[] {
            "EyeX and eViacam",
            "EyeX and TrackIR",
            "EyeX and SmartNav",
            "EyeX Only",
            "TrackIR Only"});
            this.ModeBox.Location = new System.Drawing.Point(132, 17);
            this.ModeBox.Name = "ModeBox";
            this.ModeBox.Size = new System.Drawing.Size(262, 24);
            this.ModeBox.TabIndex = 18;
            this.ModeBox.SelectedIndexChanged += new System.EventHandler(this.ModeBox_SelectedIndexChanged);
            // 
            // warpBar
            // 
            this.warpBar.AutoSize = true;
            this.warpBar.Location = new System.Drawing.Point(239, 221);
            this.warpBar.Name = "warpBar";
            this.warpBar.Size = new System.Drawing.Size(128, 21);
            this.warpBar.TabIndex = 20;
            this.warpBar.Text = "Show Warp Bar";
            this.warpBar.UseVisualStyleBackColor = true;
            this.warpBar.CheckedChanged += new System.EventHandler(this.warpBar_CheckedChanged);
            // 
            // gazeTracker
            // 
            this.gazeTracker.AutoSize = true;
            this.gazeTracker.Location = new System.Drawing.Point(239, 249);
            this.gazeTracker.Name = "gazeTracker";
            this.gazeTracker.Size = new System.Drawing.Size(155, 21);
            this.gazeTracker.TabIndex = 21;
            this.gazeTracker.Text = "Show Gaze Tracker";
            this.gazeTracker.UseVisualStyleBackColor = true;
            this.gazeTracker.CheckedChanged += new System.EventHandler(this.gazeTracker_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Movement";
            // 
            // ContinuousButton
            // 
            this.ContinuousButton.AutoSize = true;
            this.ContinuousButton.Location = new System.Drawing.Point(132, 57);
            this.ContinuousButton.Name = "ContinuousButton";
            this.ContinuousButton.Size = new System.Drawing.Size(100, 21);
            this.ContinuousButton.TabIndex = 23;
            this.ContinuousButton.Text = "Continuous";
            this.ContinuousButton.UseVisualStyleBackColor = true;
            this.ContinuousButton.Click += new System.EventHandler(this.ContinuousButton_Click);
            // 
            // OnKeyPressButton
            // 
            this.OnKeyPressButton.AutoSize = true;
            this.OnKeyPressButton.Checked = true;
            this.OnKeyPressButton.Location = new System.Drawing.Point(132, 84);
            this.OnKeyPressButton.Name = "OnKeyPressButton";
            this.OnKeyPressButton.Size = new System.Drawing.Size(116, 21);
            this.OnKeyPressButton.TabIndex = 24;
            this.OnKeyPressButton.TabStop = true;
            this.OnKeyPressButton.Text = "On Key Press";
            this.OnKeyPressButton.UseVisualStyleBackColor = true;
            this.OnKeyPressButton.Click += new System.EventHandler(this.OnKeyPressButton_Click);
            // 
            // MovementOnKeyPressInput
            // 
            this.MovementOnKeyPressInput.Location = new System.Drawing.Point(256, 84);
            this.MovementOnKeyPressInput.Name = "MovementOnKeyPressInput";
            this.MovementOnKeyPressInput.Size = new System.Drawing.Size(100, 22);
            this.MovementOnKeyPressInput.TabIndex = 25;
            this.MovementOnKeyPressInput.Text = "F3";
            this.MovementOnKeyPressInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MovementOnKeyPressButton_Click);
            // 
            // SensitivityInput
            // 
            this.SensitivityInput.Location = new System.Drawing.Point(126, 163);
            this.SensitivityInput.Maximum = 20;
            this.SensitivityInput.Name = "SensitivityInput";
            this.SensitivityInput.Size = new System.Drawing.Size(268, 56);
            this.SensitivityInput.TabIndex = 26;
            this.SensitivityInput.Value = 5;
            this.SensitivityInput.Scroll += new System.EventHandler(this.SensitivityInput_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "Sensitivity";
            // 
            // ClickOnKey
            // 
            this.ClickOnKey.AutoSize = true;
            this.ClickOnKey.Location = new System.Drawing.Point(29, 124);
            this.ClickOnKey.Name = "ClickOnKey";
            this.ClickOnKey.Size = new System.Drawing.Size(88, 17);
            this.ClickOnKey.TabIndex = 28;
            this.ClickOnKey.Text = "Click On Key";
            // 
            // ClickOnKeyInput
            // 
            this.ClickOnKeyInput.Location = new System.Drawing.Point(132, 124);
            this.ClickOnKeyInput.Name = "ClickOnKeyInput";
            this.ClickOnKeyInput.Size = new System.Drawing.Size(100, 22);
            this.ClickOnKeyInput.TabIndex = 29;
            this.ClickOnKeyInput.Text = "F3";
            this.ClickOnKeyInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnClickKeyPressInput_KeyDown);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Precision Gaze Mouse";
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // PrecisionGazeMouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 357);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PrecisionGazeMouseForm";
            this.Text = "Precision Gaze Mouse";
            this.Load += new System.EventHandler(this.GazeAwareForm_Load);
            this.Shown += new System.EventHandler(this.PrecisionGazeMouseForm_Shown);
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
    }
}

