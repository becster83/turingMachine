using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            createTape();
            createTape2();

        }

        private void createTape()
        {
            int n = 3;
            int lSize = 35;

            Label[] label = new Label[n];

            for (int i = 0; i < label.Length; i++)
            {
                label[i] = new Label();
                label[i].AutoSize = false;
                label[i].BorderStyle = BorderStyle.FixedSingle;
                label[i].Size = new Size(lSize, lSize);
                label[i].TextAlign = ContentAlignment.MiddleCenter;
                label[i].Font = new Font(label[i].Font.Name, 18F);
                label[i].Name = "n" + i;
                label[i].Text = "" + i;
                Tape1.Controls.Add(label[i]);

                label[i].Click += new EventHandler(label_clickas);
            }
        }

        private void createTape2()
        {
            int n = 3;
            int lSize = 35;

            TextBox[] slots = new TextBox[n];

            for (int i = 0; i < slots.Length; i++)
            {
                slots[i] = new TextBox();
                slots[i].Size = new Size(lSize, lSize);
                slots[i].TextAlign = HorizontalAlignment.Center;
                slots[i].Font = new Font(slots[i].Font.Name, 18F);
                slots[i].Name = "n" + i;
                slots[i].MaxLength = 1;
                slots[i].Text = "" + i;
                Tape2.Controls.Add(slots[i]);

                slots[i].Click += new EventHandler(slots_clickas);
            }
        }

        void label_clickas(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                clickedLabel.BackColor = Color.Red;
            }
        }

        void slots_clickas(object sender, EventArgs e)
        {
            TextBox clickedSlot = sender as TextBox;

            if (clickedSlot != null)
            {
                clickedSlot.BackColor = Color.Red;
            }
        }

    }
}

