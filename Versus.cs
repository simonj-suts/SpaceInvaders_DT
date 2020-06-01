﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class Client : Form
    {
        #region Private fields
        int tickCount;
        Player player1; // Player 1
        Player player2; // Player 2
        List<Missle> missles;
        List<Missle2> missles2;
        #endregion

        #region Settings
        int tickInterval = 5;
        int numberOfPositions = 10;
        int numberOfLives = 3;
        int missleSpeed = 50;
        Size playerSize = new Size(75, 75);
        Size asteroidSize = new Size(75, 75);
        Size missleSize = new Size(15, 45);
        #endregion

        #region Constructors factory methods
        public Client()
        {
            InitializeComponent();

            missles = new List<Missle>();
            missles2 = new List<Missle2>();
            //asteroids = new List<Asteroid>();

            player1 = new Player(playerSize, numberOfPositions, numberOfLives, Properties.Resources.player1); // create player 1
            player2 = new Player(playerSize, numberOfPositions, numberOfLives, Properties.Resources.player2); // create player 2


            numberOfLivesLabel.Text = String.Format("Lives = {0}", player1.Lives);  
            numberOfLivesLabel1.Text = String.Format("Lives = {0}", player2.Lives);           

            Controls.Add(player1.Sprite);
            Controls.Add(player2.Sprite);
        }
        #endregion

        #region Core logic
        // Positions animated objects
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (player1 != null) player1.Reposition(this.Width, this.Height,1);
            if (player2 != null) player2.Reposition2(this.Width, this.Height,2);
        }

        // Controls
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // move player 1--> 
            if (timer.Enabled && e.KeyCode == Keys.Right && player1.Lives != 0)
                player1.MoveRight();

            // move player 1<--
            if (timer.Enabled && e.KeyCode == Keys.Left && player1.Lives != 0) // && e.Modifiers == Keys.Control
                player1.MoveLeft();

            // shoot player 1
            if (timer.Enabled && e.KeyCode == Keys.Space && player1.Lives != 0)
            {
                Missle missle = player1.CreateMissle(missleSize, missleSpeed,1);
                missles.Add(missle);
                Controls.Add(missle.Sprite);
            }

            // move player 2-->
            if (timer.Enabled && e.KeyCode == Keys.D && player2.Lives != 0)
                player2.MoveRight();

            // move player 2<--
            if (timer.Enabled && e.KeyCode == Keys.A && player2.Lives != 0) // && e.Modifiers == Keys.Control
                player2.MoveLeft();

            // shoot player 2
            if (timer.Enabled && e.KeyCode == Keys.F && player2.Lives != 0)
            {
                Missle2 missle2 = player2.CreateMissle2(missleSize, missleSpeed,2);
                missles2.Add(missle2);
                Controls.Add(missle2.Sprite);
            }

            // pause
            if (e.KeyCode == Keys.P)
                timer.Enabled = !timer.Enabled;

            // exit
            if (e.KeyCode == Keys.Escape)
                Application.Exit();

            // restart
            if (!timer.Enabled && e.KeyCode == Keys.Enter)
            {
                // clear everything on screen
                Controls.Clear();
                //asteroids.Clear();
                missles.Clear();
                
                // retrieve new number of lives
                player1.Lives = numberOfLives;
                player2.Lives = numberOfLives;

                // reset player position
                player1.Reposition(this.Width, this.Height,1);
                player2.Reposition2(this.Width, this.Height,2);

                // update number of lives display
                numberOfLivesLabel.Text = String.Format("Lives = {0}", player1.Lives);
                numberOfLivesLabel1.Text = String.Format("Lives = {0}", player2.Lives);

                // re-display
                Controls.Add(numberOfLivesLabel);  // number of lives for player 1
                Controls.Add(numberOfLivesLabel1); // number of lives for player 2
                Controls.Add(player1.Sprite);      // player 1
                Controls.Add(player2.Sprite);      // player 2

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
                if (missles[j].IsOutOfScreen(player2))
                {
                    Controls.Remove(missles[j].Sprite);
                    missles.RemoveAt(j);
                }
            }

            for (int i = missles2.Count - 1; i >= 0; i--)
            {
                missles2[i].Move();

                // remove missle once out of screen
                if (missles2[i].IsOutOfScreen(player1))
                {
                    Controls.Remove(missles2[i].Sprite);
                    missles2.RemoveAt(i);
                }
            }

            

            for (int i = missles.Count - 1; i >= 0; i--)
            {
                if (missles[i].Sprite.Bounds.IntersectsWith(player2.Sprite.Bounds))
                {
                    if (player2.Lives != 0)
                    {

                        Controls.Remove(numberOfLivesLabel1);

                        Controls.Remove(player2.Sprite);

                        player2.Lives--;
                        player2.Reposition2(this.Width, this.Height, 2);

                        numberOfLivesLabel1.Text = String.Format("Lives = {0}", player2.Lives);
                        Controls.Add(numberOfLivesLabel1);
                        Controls.Add(player2.Sprite);
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
                if (missles2[j].Sprite.Bounds.IntersectsWith(player1.Sprite.Bounds))
                {
                    if (player1.Lives != 0)
                    {
                      

                        Controls.Remove(numberOfLivesLabel);      // clear Number of Lives Label              
                        Controls.Remove(player1.Sprite);          // clear Player 1

                        player1.Lives--;                              // reduce Player 1 live
                        player1.Reposition(this.Width, this.Height, 1);  // reposition Player 1

                        numberOfLivesLabel.Text = String.Format("Lives = {0}", player1.Lives);
                        Controls.Add(numberOfLivesLabel);
                        Controls.Add(player1.Sprite);
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

        private void Client_Load(object sender, EventArgs e)
        {
            // relatively position Player 2 Number of Lives Label
            numberOfLivesLabel1.Location = new Point(1, 2);

            // relatively position Player 1 Number of Lives Label
            numberOfLivesLabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.87), 2);

        }
    }
}
