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
            this.OnKeyPressInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Location = new System.Drawing.Point(131, 147);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(42, 17);
            this.PositionLabel.TabIndex = 8;
            this.PositionLabel.Text = "(0, 0)";
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(153, 215);
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
            this.label1.Location = new System.Drawing.Point(26, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Gaze Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Head Rotation";
            // 
            // HeadRotationLabel
            // 
            this.HeadRotationLabel.AutoSize = true;
            this.HeadRotationLabel.Location = new System.Drawing.Point(131, 177);
            this.HeadRotationLabel.Name = "HeadRotationLabel";
            this.HeadRotationLabel.Size = new System.Drawing.Size(42, 17);
            this.HeadRotationLabel.TabIndex = 12;
            this.HeadRotationLabel.Text = "(0, 0)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Status";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(131, 119);
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
            this.warpBar.Location = new System.Drawing.Point(241, 118);
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
            this.gazeTracker.Location = new System.Drawing.Point(241, 146);
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
            this.label4.Location = new System.Drawing.Point(45, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Movement";
            // 
            // ContinuousButton
            // 
            this.ContinuousButton.AutoSize = true;
            this.ContinuousButton.Location = new System.Drawing.Point(132, 51);
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
            this.OnKeyPressButton.Location = new System.Drawing.Point(132, 78);
            this.OnKeyPressButton.Name = "OnKeyPressButton";
            this.OnKeyPressButton.Size = new System.Drawing.Size(116, 21);
            this.OnKeyPressButton.TabIndex = 24;
            this.OnKeyPressButton.TabStop = true;
            this.OnKeyPressButton.Text = "On Key Press";
            this.OnKeyPressButton.UseVisualStyleBackColor = true;
            this.OnKeyPressButton.Click += new System.EventHandler(this.OnKeyPressButton_Click);
            // 
            // OnKeyPressInput
            // 
            this.OnKeyPressInput.Location = new System.Drawing.Point(256, 78);
            this.OnKeyPressInput.Name = "OnKeyPressInput";
            this.OnKeyPressInput.Size = new System.Drawing.Size(100, 22);
            this.OnKeyPressInput.TabIndex = 25;
            this.OnKeyPressInput.Text = "F3";
            this.OnKeyPressInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyPressInput_KeyDown);
            // 
            // PrecisionGazeMouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 255);
            this.Controls.Add(this.OnKeyPressInput);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PrecisionGazeMouseForm";
            this.Text = "Precision Gaze Mouse";
            this.Load += new System.EventHandler(this.GazeAwareForm_Load);
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
        private System.Windows.Forms.TextBox OnKeyPressInput;
    }
}

