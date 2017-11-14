namespace WindowsFormsApp1
{
    partial class Form1
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
            this.Tape2 = new System.Windows.Forms.FlowLayoutPanel();
            this.Tape1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // Tape2
            // 
            this.Tape2.Location = new System.Drawing.Point(21, 128);
            this.Tape2.Name = "Tape2";
            this.Tape2.Size = new System.Drawing.Size(852, 94);
            this.Tape2.TabIndex = 2;
            // 
            // Tape1
            // 
            this.Tape1.Location = new System.Drawing.Point(21, 25);
            this.Tape1.Name = "Tape1";
            this.Tape1.Size = new System.Drawing.Size(852, 86);
            this.Tape1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 392);
            this.Controls.Add(this.Tape1);
            this.Controls.Add(this.Tape2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Tape2;
        private System.Windows.Forms.FlowLayoutPanel Tape1;
    }
}

