namespace Eligor
{
    partial class Progress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Progress));
            this.Cancel = new System.Windows.Forms.Button();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.SeedLabel = new System.Windows.Forms.Label();
            this.ResultsLabel = new System.Windows.Forms.Label();
            this.ResultsCount = new System.Windows.Forms.Label();
            this.SeedCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(156, 30);
            this.Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(54, 25);
            this.Cancel.TabIndex = 10;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(12, 12);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(198, 10);
            this.ProgressBar1.Step = 1;
            this.ProgressBar1.TabIndex = 9;
            // 
            // SeedLabel
            // 
            this.SeedLabel.AutoSize = true;
            this.SeedLabel.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeedLabel.Location = new System.Drawing.Point(33, 44);
            this.SeedLabel.Name = "SeedLabel";
            this.SeedLabel.Size = new System.Drawing.Size(42, 14);
            this.SeedLabel.TabIndex = 13;
            this.SeedLabel.Text = "Seed:";
            // 
            // ResultsLabel
            // 
            this.ResultsLabel.AutoSize = true;
            this.ResultsLabel.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultsLabel.Location = new System.Drawing.Point(12, 30);
            this.ResultsLabel.Name = "ResultsLabel";
            this.ResultsLabel.Size = new System.Drawing.Size(63, 14);
            this.ResultsLabel.TabIndex = 15;
            this.ResultsLabel.Text = "Results:";
            // 
            // ResultsCount
            // 
            this.ResultsCount.AutoSize = true;
            this.ResultsCount.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultsCount.Location = new System.Drawing.Point(78, 30);
            this.ResultsCount.Name = "ResultsCount";
            this.ResultsCount.Size = new System.Drawing.Size(14, 14);
            this.ResultsCount.TabIndex = 16;
            this.ResultsCount.Text = "0";
            // 
            // SeedCount
            // 
            this.SeedCount.AutoSize = true;
            this.SeedCount.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeedCount.Location = new System.Drawing.Point(78, 44);
            this.SeedCount.Name = "SeedCount";
            this.SeedCount.Size = new System.Drawing.Size(63, 14);
            this.SeedCount.TabIndex = 17;
            this.SeedCount.Text = "00000000";
            // 
            // Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 65);
            this.ControlBox = false;
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.SeedCount);
            this.Controls.Add(this.ResultsCount);
            this.Controls.Add(this.ResultsLabel);
            this.Controls.Add(this.SeedLabel);
            this.Controls.Add(this.ProgressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(238, 104);
            this.MinimumSize = new System.Drawing.Size(238, 104);
            this.Name = "Progress";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Eligor";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.Progress_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ProgressBar ProgressBar1;
        public System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label SeedLabel;
        private System.Windows.Forms.Label ResultsLabel;
        public System.Windows.Forms.Label ResultsCount;
        public System.Windows.Forms.Label SeedCount;
    }
}