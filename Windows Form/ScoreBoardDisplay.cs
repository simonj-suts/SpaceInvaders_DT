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
    public partial class ScoreBoardDisplay : Form
    {
        public List<Player> scoreboardPlyr = new List<Player>(); 
        public ScoreBoardDisplay(Scoreboard aScoreBoard)
        {
            InitializeComponent();
            foreach (Player p in aScoreBoard.players) {
                scoreboardPlyr.Add(p);
            }

            /*if (aScoreBoard.players.Count >= 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    label2.Text += String.Format("\n{0,-10}\t{1,10}", scoreboardPlyr[i].Name, scoreboardPlyr[i].Score);

                }
            }
            else { 
                  foreach
            }*/
            int i = 0;
            foreach (Player p in aScoreBoard.players)
            {
                
                label2.Text += String.Format("\n{0,-10}\t{1,10}", scoreboardPlyr[i].Name, scoreboardPlyr[i].Score);
                if (i++ >= 5) break;
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            
        }

        private void ScoreBoardDisplay_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(Convert.ToInt32((double)this.Width * 0.35), Convert.ToInt32((double)this.Height * 0.15));
            label2.Location = new Point(Convert.ToInt32((double)this.Width * 0.43), Convert.ToInt32((double)this.Height * 0.35));
            button1.Location = new Point(Convert.ToInt32((double)this.Width * 0.40), Convert.ToInt32((double)this.Height * 0.75));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
