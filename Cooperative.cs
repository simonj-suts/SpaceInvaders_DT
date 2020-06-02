using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class Cooperative : Form
    {
        #region Private fields
        int tickCount;
        Player player1; // Player 1
        Player player2; // Player 2
        List<Missle> missles;
        List<Asteroid> asteroids;
        AsteroidFactory asteroidFactory;
        #endregion

        #region Settings
        int tickInterval = 5;
        int numberOfPositions = 10;
        int numberOfLives = 3;
        int asteroidSpeed = 40;
        int missleSpeed = 50;
        Size playerSize = new Size(75, 75);
        Size asteroidSize = new Size(75, 75);
        Size missleSize = new Size(15, 45);
        #endregion

        #region Constructors factory methods
        public Cooperative()
        {
            InitializeComponent();

            missles = new List<Missle>();
            asteroids = new List<Asteroid>();

            player1 = new Player(playerSize, numberOfPositions, numberOfLives, 1); // create player 1
            player1.InitializeSprite();
            player2 = new Player(playerSize, numberOfPositions, numberOfLives, 2); // create player 2
            player2.InitializeSprite();

            asteroidFactory = new AsteroidFactory(asteroidSize, asteroidSpeed, numberOfPositions);

            numberOfLivesLabel.Text = String.Format("Lives = {0}", player1.Lives);
            scoreLabel.Text = String.Format("Score = {0:D2}", player1.Score);
            

            numberOfLivesLabel1.Text = String.Format("Lives = {0}", player2.Lives);
            scoreLabel1.Text = String.Format("Score = {0:D2}", player2.Score);
            

            Controls.Add(player1.Sprite);
            Controls.Add(player2.Sprite);
        }
        #endregion

        #region Core logic
        // Positions animated objects
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (player1 != null)
            {
                player1.Reposition(this.Width, this.Height, 1);
                player1.PositionSprite();
            }
            if (player2 != null)
            {
                player2.Reposition(this.Width, this.Height, 2);
                player2.PositionSprite();
            }
            if (asteroidFactory != null) asteroidFactory.ScreenW = this.Width;
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
                missle.InitializeSprite();
                missle.PositionSprite();
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
                Missle missle = player2.CreateMissle(missleSize, missleSpeed,2);
                missle.InitializeSprite();
                missle.PositionSprite();
                missles.Add(missle);
                Controls.Add(missle.Sprite);
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
                asteroids.Clear();
                missles.Clear();
                
                // retrieve new number of lives
                player1.Lives = numberOfLives;
                player2.Lives = numberOfLives;

                // reset player position
                player1.Reposition(this.Width, this.Height,1);
                player1.InitializeSprite();
                player2.Reposition(this.Width, this.Height,2);
                player2.InitializeSprite();

                // update number of lives display
                numberOfLivesLabel.Text = String.Format("Lives = {0}", player1.Lives);
                numberOfLivesLabel1.Text = String.Format("Lives = {0}", player2.Lives);

                // reset score
                scoreLabel.Text = String.Format("Score = {0:D2}", player1.Score = 0);
                scoreLabel1.Text = String.Format("Score = {0:D2}", player2.Score = 0);

                // re-display
                Controls.Add(numberOfLivesLabel);  // number of lives for player 1
                Controls.Add(numberOfLivesLabel1); // number of lives for player 2
                Controls.Add(scoreLabel);          // score label for player 1
                Controls.Add(scoreLabel1);         // score label for player 2
                Controls.Add(player1.Sprite);      // player 1
                Controls.Add(player2.Sprite);      // player 2

                timer.Start(); // restart timer
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            // create and add asteroid every tickInterval ticks
            if (tickCount % tickInterval == 0)
            {
                Asteroid asteroid = asteroidFactory.CreateAsteroid();
                asteroids.Add(asteroid);
                Controls.Add(asteroid.Sprite);
            }

            // asteroids
            for (int i = asteroids.Count - 1; i >= 0; i--)
            {
                // both players died
                if (player1.Lives == 0 && player2.Lives == 0)
                {
                    numberOfLivesLabel1.Text = "Game over, press enter to restart...";
                    Controls.Add(numberOfLivesLabel1);
                    timer.Enabled = false;
                    break;
                }

                asteroids[i].Move();

                // collision with player 1
                if (asteroids[i].Sprite.Bounds.IntersectsWith(player1.Sprite.Bounds) && player1.Lives != 0)
                {
                    if (player1.Lives > 1)
                    {
                        // clear objects on screen
                        for (int j = asteroids.Count - 1; j >= 0; j--)
                        {
                            Controls.Remove(asteroids[j].Sprite); // clear all asteroids images
                        }
                        Controls.Remove(numberOfLivesLabel);      // clear Number of Lives Label
                        Controls.Remove(scoreLabel);              // clear Score label
                        Controls.Remove(player1.Sprite);          // clear Player 1
                        asteroids.Clear();                        // clear asteroid objects

                        player1.Lives--;                              // reduce Player 1 live
                        player1.Reposition(this.Width, this.Height, 1);  // reposition Player 1
                        player1.PositionSprite();

                        numberOfLivesLabel.Text = String.Format("Lives = {0}", player1.Lives);
                        Controls.Add(numberOfLivesLabel);
                        Controls.Add(scoreLabel);
                        Controls.Add(player1.Sprite);
                        break;
                    } else
                    {
                        for (int j = asteroids.Count - 1; j >= 0; j--)
                        {
                            Controls.Remove(asteroids[j].Sprite);
                        }
                        Controls.Remove(numberOfLivesLabel);
                        Controls.Remove(scoreLabel);
                        Controls.Remove(player1.Sprite);
                        asteroids.Clear();
                        player1.Lives--;
                        break;
                    }
                }

                // collision with player 2
                if (asteroids[i].Sprite.Bounds.IntersectsWith(player2.Sprite.Bounds) && player2.Lives != 0)
                {
                    if (player2.Lives > 1)
                    {
                        for (int j = asteroids.Count - 1; j >= 0; j--)
                        {
                            Controls.Remove(asteroids[j].Sprite);
                        }
                        Controls.Remove(numberOfLivesLabel1);
                        Controls.Remove(scoreLabel1);
                        Controls.Remove(player2.Sprite);
                        asteroids.Clear();

                        player2.Lives--;
                        player2.Reposition(this.Width, this.Height,2);
                        player2.PositionSprite();

                        numberOfLivesLabel1.Text = String.Format("Lives = {0}", player2.Lives);
                        Controls.Add(numberOfLivesLabel1);
                        Controls.Add(scoreLabel1);
                        Controls.Add(player2.Sprite);
                        break;
                    }
                    else
                    {
                        for (int j = asteroids.Count - 1; j >= 0; j--)
                        {
                            Controls.Remove(asteroids[j].Sprite);
                        }
                        Controls.Remove(numberOfLivesLabel1);
                        Controls.Remove(scoreLabel1);
                        Controls.Remove(player2.Sprite);
                        asteroids.Clear();
                        player2.Lives--;
                        break;
                    }
                } 
                
                

                // remove asteroids once out of screen
                if (asteroids[i].IsOutOfScreen(this.Height))
                {
                    Controls.Remove(asteroids[i].Sprite);
                    asteroids.RemoveAt(i);
                }
            }

            // missles
            for (int j = missles.Count - 1; j >= 0; j--)
            {
                missles[j].Move();

                // remove missle once out of screen
                if (missles[j].IsOutOfScreen(this.Width))
                {
                    Controls.Remove(missles[j].Sprite);
                    missles.RemoveAt(j);
                }
            }

            // check if missle collides with asteroid
            for (int i = asteroids.Count - 1; i >= 0; i--)
            {
                for (int j = missles.Count - 1; j >= 0; j--)
                {
                    if (i > asteroids.Count - 1 || j > missles.Count - 1)
                        break;

                    if (asteroids[i].Sprite.Bounds.IntersectsWith(missles[j].Sprite.Bounds))
                    {
                        if (missles[j].PlayerNo == 1)
                            scoreLabel.Text = String.Format("Score = {0:D2}", ++player1.Score);
                        else
                            scoreLabel1.Text = String.Format("Score = {0:D2}", ++player2.Score);

                        Controls.Remove(missles[j].Sprite);
                        missles.RemoveAt(j);

                        Controls.Remove(asteroids[i].Sprite);
                        asteroids.RemoveAt(i);
                    }
                }
            }
            tickCount++;
        }
        #endregion

        private void scoreLabel_Click(object sender, EventArgs e)
        {

        }

        private void numberOfLivesLabel_Click(object sender, EventArgs e)
        {
            //
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // relatively position Player 2 Number of Lives Label
            numberOfLivesLabel1.Location = new Point(1, 2);

            // relatively position Player 2 Score Label
            scoreLabel1.Location = new Point(1, Convert.ToInt32((double)this.Height * 0.15));

            // relatively position Player 1 Number of Lives Label
            numberOfLivesLabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.87), 2);

            // relatively position Player 1 Score Label
            scoreLabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.87), Convert.ToInt32((double)this.Height * 0.15));
        }
    }
}
