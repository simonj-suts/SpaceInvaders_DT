﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders.Windows_Form
{
    public partial class InstructionCoop : Form
    {
        public InstructionCoop()
        {
            InitializeComponent();
        }

        private void InstructionCoop_Load(object sender, EventArgs e)
        {
            
            label1.Location = new Point(Convert.ToInt32((double)this.Width * 0.10), Convert.ToInt32((double)this.Height * 0.05));
            label3.Location = new Point(Convert.ToInt32((double)this.Width * 0.10), Convert.ToInt32((double)this.Height * 0.15));
            


            //labels for asteroids
            label5.Location = new Point(Convert.ToInt32((double)this.Width * 0.10), Convert.ToInt32((double)this.Height * 0.78));
            label6.Location = new Point(Convert.ToInt32((double)this.Width * 0.20), Convert.ToInt32((double)this.Height * 0.78));
            label7.Location = new Point(Convert.ToInt32((double)this.Width * 0.30), Convert.ToInt32((double)this.Height * 0.78));

            pictureBox1.Location = new Point(Convert.ToInt32((double)this.Width * 0.10), Convert.ToInt32((double)this.Height * 0.70));
            pictureBox1.Size = new Size(65, 65);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox2.Location = new Point(Convert.ToInt32((double)this.Width * 0.20), Convert.ToInt32((double)this.Height * 0.70));
            pictureBox2.Size = new Size(65, 65); ;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox3.Location = new Point(Convert.ToInt32((double)this.Width * 0.30), Convert.ToInt32((double)this.Height * 0.70));
            pictureBox3.Size = new Size(65,65);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;



            button1.Location = new Point(Convert.ToInt32((double)this.Width * 0.65), Convert.ToInt32((double)this.Height * 0.65));

            blackBackground.Location = new Point(0, 0);
            blackBackground.Size = new Size(this.Width, this.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cooperative c = new Cooperative();
            c.Show();
            blackBackground.Show();
            c.FormClosing += new FormClosingEventHandler(Close);
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
