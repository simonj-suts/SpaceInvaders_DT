using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class Versus : Form
    {
        #region Private fields
        int tickCount;
        Player Player1; // Player 1
        Player Player2; // Player 2
        List<Missle> missles;
        List<MissleVs2> missles2;
        #endregion

        #region Settings
        int tickInterval = 5;
        int numberOfPositions = 10;
        int numberOfLives = 3;
        int missleSpeed = 50;
        Size PlayerSize = new Size(75, 75);
        Size asteroidSize = new Size(75, 75);
        Size missleSize = new Size(15, 45);
        #endregion

        #region Constructors factory methods
        public Versus()
        {
            InitializeComponent();

            missles = new List<Missle>();
            missles2 = new List<MissleVs2>();
            //asteroids = new List<Asteroid>();

            Player1 = new Player(PlayerSize, numberOfPositions, numberOfLives, Properties.Resources.player1); // create Player 1
            Player2 = new Player(PlayerSize, numberOfPositions, numberOfLives, Properties.Resources.playervs2); // create Player 2


            numberOfLivesLabel.Text = String.Format("Lives = {0}", Player1.Lives);  
            numberOfLivesLabel1.Text = String.Format("Lives = {0}", Player2.Lives);           

            Controls.Add(Player1.Sprite);
            Controls.Add(Player2.Sprite);
        }
        #endregion

        #region Core logic
        // Positions animated objects
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Player1 != null) Player1.Reposition(this.Width, this.Height, 1);
            if (Player2 != null) Player2.Reposition2(this.Width, this.Height, 2);
        }

        // Controls
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // move Player 1--> 
            if (timer.Enabled && e.KeyCode == Keys.Right && Player1.Lives != 0)
                Player1.MoveRight();

            // move Player 1<--
            if (timer.Enabled && e.KeyCode == Keys.Left && Player1.Lives != 0) // && e.Modifiers == Keys.Control
                Player1.MoveLeft();

            // shoot Player 1
            if (timer.Enabled && e.KeyCode == Keys.Space && Player1.Lives != 0)
            {
                Missle missle = Player1.CreateMissle(missleSize, missleSpeed, 1);
                missles.Add(missle);
                Controls.Add(missle.Sprite);
            }

            // move Player 2-->
            if (timer.Enabled && e.KeyCode == Keys.D && Player2.Lives != 0)
                Player2.MoveRight();

            // move Player 2<--
            if (timer.Enabled && e.KeyCode == Keys.A && Player2.Lives != 0) // && e.Modifiers == Keys.Control
                Player2.MoveLeft();

            // shoot Player 2
            if (timer.Enabled && e.KeyCode == Keys.F && Player2.Lives != 0)
            {
                MissleVs2 missle2 = Player2.CreateMissle2(missleSize, missleSpeed);
                missles2.Add(missle2);
                Controls.Add(missle2.Sprite);
            }

            // pause
            if (e.KeyCode == Keys.P)
                timer.Enabled = !timer.Enabled;

            // exit
            if (e.KeyCode == Keys.Escape)
                this.Close();

            // restart
            if (!timer.Enabled && e.KeyCode == Keys.Enter)
            {
                // clear everything on screen
                Controls.Clear();
                //asteroids.Clear();
                missles.Clear();
                
                // retrieve new number of lives
                Player1.Lives = numberOfLives;
                Player2.Lives = numberOfLives;

                // reset Player position
                Player1.Reposition(this.Width, this.Height, 1);
                Player2.Reposition2(this.Width, this.Height, 2);

                // update number of lives display
                numberOfLivesLabel.Text = String.Format("Lives = {0}", Player1.Lives);
                numberOfLivesLabel1.Text = String.Format("Lives = {0}", Player2.Lives);

                // re-display
                Controls.Add(numberOfLivesLabel);  // number of lives for Player 1
                Controls.Add(numberOfLivesLabel1); // number of lives for Player 2
                Controls.Add(Player1.Sprite);      // Player 1
                Controls.Add(Player2.Sprite);      // Player 2

                timer.Start(); // restart timer
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // missles
            for (int j = missles.Count - 1; j >= 0; j--)
            {
                missles[j].Move();

                // remove missle once out of screen
                if (missles[j].IsOutOfScreen())
                {
                    Controls.Remove(missles[j].Sprite);
                    missles.RemoveAt(j);
                }
            }

            for (int i = missles2.Count - 1; i >= 0; i--)
            {
                missles2[i].Move();

                // remove missle once out of screen
                if (missles2[i].IsOutOfScreen(Player1))
                {
                    Controls.Remove(missles2[i].Sprite);
                    missles2.RemoveAt(i);
                }
            }

            

            for (int i = missles.Count - 1; i >= 0; i--)
            {
                if (missles[i].Sprite.Bounds.IntersectsWith(Player2.Sprite.Bounds))
                {
                    if (Player2.Lives != 0)
                    {

                        Controls.Remove(numberOfLivesLabel1);

                        Controls.Remove(Player2.Sprite);

                        Player2.Lives--;
                        Player2.Reposition2(this.Width, this.Height, 2);

                        numberOfLivesLabel1.Text = String.Format("Lives = {0}", Player2.Lives);
                        Controls.Add(numberOfLivesLabel1);
                        Controls.Add(Player2.Sprite);
                        break;
                    }
                    else
                    {
                        //gameover screen
                        //to be added
                    }                 
                }
            }

            for (int j = missles2.Count - 1; j >= 0; j--)
            {
                if (missles2[j].Sprite.Bounds.IntersectsWith(Player1.Sprite.Bounds))
                {
                    if (Player1.Lives != 0)
                    {
                      

                        Controls.Remove(numberOfLivesLabel);      // clear Number of Lives Label              
                        Controls.Remove(Player1.Sprite);          // clear Player 1

                        Player1.Lives--;                              // reduce Player 1 live
                        Player1.Reposition(this.Width, this.Height, 1);  // reposition Player 1

                        numberOfLivesLabel.Text = String.Format("Lives = {0}", Player1.Lives);
                        Controls.Add(numberOfLivesLabel);
                        Controls.Add(Player1.Sprite);
                        break;
                    }
                    else
                    {
                        //gameover screen
                        //to be added
                    }
                }
            }
            tickCount++;
        }
        #endregion
        


        private void numberOfLivesLabel_Click(object sender, EventArgs e)
        {
            //
        }

        private void Versus_Load(object sender, EventArgs e)
        {
            // relatively position Player 2 Number of Lives Label
            numberOfLivesLabel1.Location = new Point(1, 2);

            // relatively position Player 1 Number of Lives Label
            numberOfLivesLabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.87), 2);

        }
    }
}
