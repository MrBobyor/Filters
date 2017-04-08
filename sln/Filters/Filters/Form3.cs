using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Filters
{
    public partial class Form3 : Form
    {
        static public int[,] mask = new int[3,3];
        static public bool marker = false;

        public Form3()
        {
            Filters main = this.Owner as Filters;
            InitializeComponent();
            
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    mask[i, j] = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Violet;
            mask[0, 0] = 1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Violet;
            mask[0, 1] = 1;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Violet;
            mask[0, 2] = 1;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Violet;
            mask[1, 0] = 1;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.Violet;
            mask[1, 1] = 1;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Violet;
            mask[1, 2] = 1;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Violet;
            mask[2, 0] = 1;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.Violet;
            mask[2, 1] = 1;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.Violet;
            mask[2, 2] = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            marker = true;
            this.Close();
        }
    }
}
