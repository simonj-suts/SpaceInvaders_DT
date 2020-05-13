using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class Client : Form
    {
        #region Private fields
        int tickCount;
        Player player;
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
        public Client()
        {
            InitializeComponent();

            missles = new List<Missle>();
            asteroids = new List<Asteroid>();

            player = new Player(playerSize, numberOfPositions, numberOfLives);
            asteroidFactory = new AsteroidFactory(asteroidSize, asteroidSpeed, numberOfPositions);

            numberOfLivesLabel.Text = String.Format("Number of lives = {0}", player.Lives);
            scoreLabel.Text = String.Format("Score = {0:D2}", player.Score);

            Controls.Add(player.Sprite);
        }
        #endregion

        #region Core logic
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (player != null) player.Reposition(this.Width, this.Height);
            if (asteroidFactory != null) asteroidFactory.ScreenW = this.Width;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // move -->
            if (timer.Enabled && e.KeyCode == Keys.Right)
                player.MoveRight();

            // move <--
            if (timer.Enabled && e.KeyCode == Keys.Left) // && e.Modifiers == Keys.Control
                player.MoveLeft();

            // shoot
            if (timer.Enabled && e.KeyCode == Keys.Space)
            {
                Missle missle = player.CreateMissle(missleSize, missleSpeed);
                missles.Add(missle);
                Controls.Add(missle.Sprite);
            }

            // pause
            if (e.KeyCode == Keys.P)
                timer.Enabled = !timer.Enabled;

            // restart
            if (!timer.Enabled && e.KeyCode == Keys.Enter)
            {
                Controls.Clear();
                asteroids.Clear();
                missles.Clear();
                player.Lives = numberOfLives;
                player.Reposition(this.Width, this.Height);

                numberOfLivesLabel.Text = String.Format("Number of lives = {0}", player.Lives);
                scoreLabel.Text = String.Format("Score = {0:D2}", player.Score = 0);
                Controls.Add(numberOfLivesLabel);
                Controls.Add(scoreLabel);
                Controls.Add(player.Sprite);
                timer.Start();
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
                asteroids[i].Move();

                // collision with player
                if (asteroids[i].Sprite.Bounds.IntersectsWith(player.Sprite.Bounds))
                {
                    if (player.Lives > 1)
                    {
                        Controls.Clear();
                        asteroids.Clear();
                        missles.Clear();
                        player.Lives--;
                        player.Reposition(this.Width, this.Height);

                        numberOfLivesLabel.Text = String.Format("Number of lives = {0}", player.Lives);
                        Controls.Add(numberOfLivesLabel);
                        Controls.Add(scoreLabel);
                        Controls.Add(player.Sprite);
                        break;
                    }
                    else
                    {
                        numberOfLivesLabel.Text = "Game over, press enter to restart...";
                        timer.Enabled = false;
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
                if (missles[j].IsOutOfScreen())
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
                        Controls.Remove(missles[j].Sprite);
                        missles.RemoveAt(j);

                        Controls.Remove(asteroids[i].Sprite);
                        asteroids.RemoveAt(i);


                        scoreLabel.Text = String.Format("Score = {0:D2}", ++player.Score);

                    }
                }
            }
            tickCount++;
        }
        #endregion
    }
}
