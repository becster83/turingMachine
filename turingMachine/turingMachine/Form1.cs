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

        }

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
            }
        }

        private void btn_run_Click(object sender, EventArgs e)
        {    
            MachineSimulator simulator = new MachineSimulator();
            string FileName = "U:\\playground\\Repos\\turingMachine\\turingMachine\\turingMachine\\transitions.txt";
            string summary = simulator.Run(FileName, 30, this);
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

            createTape(txt_input.Text);

            //disable the contents of the setup
            foreach (Control item in gb_setup.Controls) {
                item.Enabled = false;      
            }            
        }

    }
}

