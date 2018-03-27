namespace Eligor
{
    partial class Spread
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Spread));
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.Button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar1.Location = new System.Drawing.Point(489, 322);
            this.ProgressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(237, 28);
            this.ProgressBar1.Step = 1;
            this.ProgressBar1.TabIndex = 3;
            this.ProgressBar1.Value = 100;
            // 
            // Button2
            // 
            this.Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button2.Enabled = false;
            this.Button2.Location = new System.Drawing.Point(408, 324);
            this.Button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 25);
            this.Button2.TabIndex = 4;
            this.Button2.Text = "STOP";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 329);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pokémon XD Spread Finder. Created by Tekka.";
            // 
            // BackgroundWorker1
            // 
            this.BackgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBox1.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBox1.Location = new System.Drawing.Point(12, 12);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.ReadOnly = true;
            this.RichTextBox1.Size = new System.Drawing.Size(715, 305);
            this.RichTextBox1.TabIndex = 6;
            this.RichTextBox1.Text = "";
            this.RichTextBox1.WordWrap = false;
            // 
            // Spread
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 358);
            this.Controls.Add(this.RichTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.Button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Spread";
            this.Text = "Eligor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Spread_FormClosing);
            this.Shown += new System.EventHandler(this.Spread_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker BackgroundWorker1;
        private System.Windows.Forms.RichTextBox RichTextBox1;
    }
}

