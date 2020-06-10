using SpaceInvaders.Windows_Form;
using System;
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
    public partial class InstructionSinglePlayer : Form
    {
        string username;
        public InstructionSinglePlayer(string userName)
        {
            InitializeComponent();
            username = userName;
        }

        private void InstructionSinglePlayer_Load(object sender, EventArgs e)
        {

            label1.Location = new Point(Convert.ToInt32((double)this.Width * 0.15), Convert.ToInt32((double)this.Height * 0.10));
            label6.Location = new Point(Convert.ToInt32((double)this.Width * 0.15), Convert.ToInt32((double)this.Height * 0.20));
            
            
            //labels for asteroids
            label4.Location = new Point(Convert.ToInt32((double)this.Width * 0.15), Convert.ToInt32((double)this.Height * 0.73));
            label5.Location = new Point(Convert.ToInt32((double)this.Width * 0.25), Convert.ToInt32((double)this.Height * 0.73));
            label7.Location = new Point(Convert.ToInt32((double)this.Width * 0.35), Convert.ToInt32((double)this.Height * 0.73));

            pictureBox1.Location = new Point(Convert.ToInt32((double)this.Width * 0.15), Convert.ToInt32((double)this.Height * 0.65));
            pictureBox1.Size = new Size(65, 65);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox2.Location = new Point(Convert.ToInt32((double)this.Width * 0.25), Convert.ToInt32((double)this.Height * 0.65));
            pictureBox2.Size =  new Size(65, 65); ;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox3.Location = new Point(Convert.ToInt32((double)this.Width * 0.35), Convert.ToInt32((double)this.Height * 0.65));
            pictureBox3.Size = new Size(65, 65);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;


            

            button1.Location = new Point(Convert.ToInt32((double)this.Width * 0.65), Convert.ToInt32((double)this.Height * 0.65));

            blackBackground.Location = new Point(0, 0);
            blackBackground.Size = new Size(this.Width,this.Height);        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client c = new Client(username);
            c.Show();
            blackBackground.Show();
            c.FormClosing += new FormClosingEventHandler(Close);
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
