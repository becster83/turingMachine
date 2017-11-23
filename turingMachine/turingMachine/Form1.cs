using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TuringMachine
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (Control ctrl in gb_setup.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    tb.TextChanged += new EventHandler(tb_TextChanged);
                }
            }

        }

        /// Enable the setup buttom only if the 2 textboxes are not empty
        void tb_TextChanged(object sender, EventArgs e)
        {
            btn_transitions.Enabled = !string.IsNullOrWhiteSpace(txt_textfile.Text) && !string.IsNullOrWhiteSpace(txt_input.Text);
        }

        /// draws the tape according to the input
        /// <param name="input"></param>
        private void createTape(string input)
        {
            int isize = 35;
            int slots = input.Length;

            Label[] label = new Label[slots];

            for (int i = 0; i < label.Length; i++)
            {
                label[i] = new Label();
                label[i].AutoSize = false;
                label[i].BorderStyle = BorderStyle.FixedSingle;
                label[i].BackColor = Color.LightGray;
                label[i].Size = new Size(isize, isize);
                label[i].TextAlign = ContentAlignment.MiddleCenter;
                label[i].Font = new Font(label[i].Font.Name, 18F);
                label[i].Name = "n" + i;
                label[i].Text = input.Substring(i);
                Tape1.Controls.Add(label[i]);

                label[i].Click += new EventHandler(label_clickas);
            }
        }

        //starting position on tape is selected
        void label_clickas(object sender, EventArgs e)
        {
             Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                clickedLabel.BackColor = Color.Red;

                /*
                foreach (Control item in gb_setup.Controls)
                {
                    item.Enabled = false;
                }
                */

                // foreach (var lbl in Controls.OfType<Label>())
                /*
                foreach (Control c in Tape1.Controls)
                {
                    if (c is UserControl1)
                    {
                        ((UserControl1)c).IsSelected = false;
                    }
                }
                */  
            }


         }

        private void btn_run_Click(object sender, EventArgs e)
        {    
            MachineSimulator simulator = new MachineSimulator();
            string summary = simulator.Run(txt_textfile.Text.Trim(), 500, this);
        }

        public void setlabel(int index, char write)
        {
            Label myLabel = Tape1.Controls.Find("n" + index, false).FirstOrDefault() as Label;

            if (myLabel != null)
            {
                myLabel.BackColor = Color.LightGray;
                myLabel.Text = write.ToString();
            }

        }

        public char getlabel(int index)
        {
            Label myLabel = Tape1.Controls.Find("n" + index, false).FirstOrDefault() as Label;

            if (myLabel != null)
            {
                myLabel.BackColor = Color.Blue;
                return myLabel.Text.First();
            }

            return '-';
        }

        private void btn_transitions_Click(object sender, EventArgs e)
        {
            
            createTape(txt_input.Text.Trim());

            //disable the contents of the setup
            foreach (Control item in gb_setup.Controls) {
                item.Enabled = false;               
            }

            //setup is complete so can now run the machine.
            btn_run.Visible = true;
        }

        private void btn_getTrans_Click(object sender, EventArgs e)
        {
            if (openTrans.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_textfile.Text = openTrans.FileName;
            }
        }

    }
}

