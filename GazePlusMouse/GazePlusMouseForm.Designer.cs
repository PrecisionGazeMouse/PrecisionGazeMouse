namespace GazePlusMouse
{
    partial class GazePlusMouseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PositionLabel = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HeadRotationLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StateLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SamplesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Location = new System.Drawing.Point(143, 48);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(42, 17);
            this.PositionLabel.TabIndex = 8;
            this.PositionLabel.Text = "(0, 0)";
            this.PositionLabel.Click += new System.EventHandler(this.PositionLabel_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(64, 147);
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
            this.label1.Location = new System.Drawing.Point(21, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Gaze Position";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Head Rotation";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // HeadRotationLabel
            // 
            this.HeadRotationLabel.AutoSize = true;
            this.HeadRotationLabel.Location = new System.Drawing.Point(143, 77);
            this.HeadRotationLabel.Name = "HeadRotationLabel";
            this.HeadRotationLabel.Size = new System.Drawing.Size(42, 17);
            this.HeadRotationLabel.TabIndex = 12;
            this.HeadRotationLabel.Text = "(0, 0)";
            this.HeadRotationLabel.Click += new System.EventHandler(this.HeadRotationLabel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "State";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Location = new System.Drawing.Point(143, 21);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(57, 17);
            this.StateLabel.TabIndex = 14;
            this.StateLabel.Text = "Starting";
            this.StateLabel.Click += new System.EventHandler(this.StateLabel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Samples";
            // 
            // SamplesLabel
            // 
            this.SamplesLabel.AutoSize = true;
            this.SamplesLabel.Location = new System.Drawing.Point(143, 106);
            this.SamplesLabel.Name = "SamplesLabel";
            this.SamplesLabel.Size = new System.Drawing.Size(16, 17);
            this.SamplesLabel.TabIndex = 16;
            this.SamplesLabel.Text = "0";
            // 
            // GazePlusMouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.SamplesLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HeadRotationLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.PositionLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GazePlusMouseForm";
            this.Text = "GazePlusMouse";
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
        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label SamplesLabel;
    }
}

