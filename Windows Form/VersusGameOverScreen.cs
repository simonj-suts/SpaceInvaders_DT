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
    public partial class VersusGameOverScreen : Form
    {
        public VersusGameOverScreen()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            gameoverlabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.36), Convert.ToInt32((double)this.Height * 0.05));
            winnerlabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.43), Convert.ToInt32((double)this.Height * 0.30));
            /*
            winnerlabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.25), Convert.ToInt32((double)this.Height * 0.20));
            loserlabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.70), Convert.ToInt32((double)this.Height * 0.20));
            */
            button1.Location = new Point(Convert.ToInt32((double)this.Width * 0.40), Convert.ToInt32((double)this.Height * 0.75));
            button2.Location = new Point(Convert.ToInt32((double)this.Width * 0.40), Convert.ToInt32((double)this.Height * 0.85));

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Versus v = new Versus();
            v.Show();
            this.Close();
        }

        public void playerPictureBox(int i)
        {
            if (i == 1)
            {
                PictureBox player1 = new PictureBox();
                player1.Width = 3000;
                player1.Height = 3000;
                Bitmap image = new Bitmap(Properties.Resources.player1);
                player1.Image = image;
                Controls.Add(player1);
                player1.Location = new Point(Convert.ToInt32((double)this.Width * 0.60), Convert.ToInt32((double)this.Height * 0.65));
                player1.BringToFront();
                button1.BringToFront();
                button2.BringToFront();
            }
            else
            {
                PictureBox player2 = new PictureBox();
                player2.Width = 3000;
                player2.Height = 3000;
                Bitmap image2 = new Bitmap(Properties.Resources.playervs2);
                player2.Image = image2;
                Controls.Add(player2);
                player2.Location = new Point(Convert.ToInt32((double)this.Width * 0.60), Convert.ToInt32((double)this.Height * 0.65));
                player2.BringToFront();
                button1.BringToFront();
                button2.BringToFront();
            }
        }


        public void winner(int i)
        {
            if (i == 1)
            {
                winnerlabel.Text = string.Format("Winner Player 1!");
                //loserlabel.Text = string.Format("Loser\nPlayer 2");

                playerPictureBox(1);

            }
            else
            {
                winnerlabel.Text = string.Format("Winner Player 2!");
                //loserlabel.Text = string.Format("Loser\nPlayer 1");

                playerPictureBox(2);
            }
        }
    }
}
