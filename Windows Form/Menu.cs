﻿using SpaceInvaders.Windows_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class Menu : Form
    {
        
        public Menu()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SinglePlayerMenu s1 = new SinglePlayerMenu();
            
            s1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            InstructionMultiplayer mode2 = new InstructionMultiplayer();
            mode2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            InstructionCoop mode3 = new InstructionCoop();
            mode3.Show();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HideBlackBackground(object sender, EventArgs e)
        {
           // blackbackground.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //blackbackground.Location = new Point(0, 0);
            //blackbackground.Size = new Size(this.Width, this.Height);

            label1.Location = new Point(Convert.ToInt32((double)this.Width * 0.20), Convert.ToInt32((double)this.Height * 0.15));
            
            button1.Location = new Point(Convert.ToInt32((double)this.Width * 0.45), Convert.ToInt32((double)this.Height * 0.35));
            button1.Size = new Size(200,50);

            button2.Location = new Point(Convert.ToInt32((double)this.Width * 0.45), Convert.ToInt32((double)this.Height * 0.45));
            button2.Size = new Size(200, 50);

            button3.Location = new Point(Convert.ToInt32((double)this.Width * 0.45), Convert.ToInt32((double)this.Height * 0.55));
            button3.Size = new Size(200, 50);

            button4.Location = new Point(Convert.ToInt32((double)this.Width * 0.45), Convert.ToInt32((double)this.Height * 0.65));
            button4.Size = new Size(200, 50);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
