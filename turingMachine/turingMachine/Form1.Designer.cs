namespace TuringMachine
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
            this.Tape1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_transitions = new System.Windows.Forms.Button();
            this.txt_input = new System.Windows.Forms.TextBox();
            this.lbl_input = new System.Windows.Forms.Label();
            this.gb_setup = new System.Windows.Forms.GroupBox();
            this.lbl_value = new System.Windows.Forms.Label();
            this.gb_setup.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tape1
            // 
            this.Tape1.Location = new System.Drawing.Point(21, 122);
            this.Tape1.Name = "Tape1";
            this.Tape1.Size = new System.Drawing.Size(852, 86);
            this.Tape1.TabIndex = 3;
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(1150, 151);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 23);
            this.btn_run.TabIndex = 4;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_transitions
            // 
            this.btn_transitions.Location = new System.Drawing.Point(242, 28);
            this.btn_transitions.Name = "btn_transitions";
            this.btn_transitions.Size = new System.Drawing.Size(75, 23);
            this.btn_transitions.TabIndex = 5;
            this.btn_transitions.Text = "Setup";
            this.btn_transitions.UseVisualStyleBackColor = true;
            this.btn_transitions.Click += new System.EventHandler(this.btn_transitions_Click);
            // 
            // txt_input
            // 
            this.txt_input.Location = new System.Drawing.Point(95, 25);
            this.txt_input.MaxLength = 10;
            this.txt_input.Name = "txt_input";
            this.txt_input.Size = new System.Drawing.Size(100, 20);
            this.txt_input.TabIndex = 6;
            // 
            // lbl_input
            // 
            this.lbl_input.AllowDrop = true;
            this.lbl_input.AutoSize = true;
            this.lbl_input.Location = new System.Drawing.Point(15, 28);
            this.lbl_input.Name = "lbl_input";
            this.lbl_input.Size = new System.Drawing.Size(59, 13);
            this.lbl_input.TabIndex = 7;
            this.lbl_input.Text = "Tape Input";
            // 
            // gb_setup
            // 
            this.gb_setup.Controls.Add(this.lbl_input);
            this.gb_setup.Controls.Add(this.btn_transitions);
            this.gb_setup.Controls.Add(this.txt_input);
            this.gb_setup.Location = new System.Drawing.Point(21, 12);
            this.gb_setup.Name = "gb_setup";
            this.gb_setup.Size = new System.Drawing.Size(471, 100);
            this.gb_setup.TabIndex = 8;
            this.gb_setup.TabStop = false;
            this.gb_setup.Text = "Setup";
            // 
            // lbl_value
            // 
            this.lbl_value.AutoSize = true;
            this.lbl_value.Location = new System.Drawing.Point(1071, 264);
            this.lbl_value.Name = "lbl_value";
            this.lbl_value.Size = new System.Drawing.Size(0, 13);
            this.lbl_value.TabIndex = 9;
            this.lbl_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 392);
            this.Controls.Add(this.lbl_value);
            this.Controls.Add(this.gb_setup);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.Tape1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gb_setup.ResumeLayout(false);
            this.gb_setup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel Tape1;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Button btn_transitions;
        private System.Windows.Forms.TextBox txt_input;
        private System.Windows.Forms.Label lbl_input;
        private System.Windows.Forms.GroupBox gb_setup;
        private System.Windows.Forms.Label lbl_value;
    }
}

