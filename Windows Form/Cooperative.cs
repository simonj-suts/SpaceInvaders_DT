using SpaceInvaders.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class Cooperative : Client
    {
        #region Private fields
        int tickCount;
        Player player1; // Player 1
        Player player2; // Player 2
        List<Weapon> missles;
        List<Asteroid> asteroids;
        AsteroidFactory asteroidFactory;
        #endregion

        #region Settings
        int tickInterval = 10;
        int numberOfPositions = 10;
        int numberOfLives = 3;
        int asteroidSpeed = 30;
        int missleSpeed = 50;
        Size playerSize = new Size(75, 75);
        Size asteroidSize = new Size(75, 75);
        #endregion

        #region Constructors factory methods
        public Cooperative()
        {
            InitializeComponent();

            missles = new List<Weapon>();
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
            if (timer.Enabled && player1.Lives != 0) // player 1 still alive
            {
                // move right 
                if (e.KeyCode == Keys.Right)
                    player1.MoveRight();
                // move left 
                if (e.KeyCode == Keys.Left)
                    player1.MoveLeft();
                // move up 
                if (e.KeyCode == Keys.Up)
                    player1.MoveUp();
                // move down 
                if (e.KeyCode == Keys.Down)
                    player1.MoveDown();
                // move sprite
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                    player1.MoveSprite();
                // select missile
                if (e.KeyCode == Keys.D8)
                    player1.weaponType = WeaponType.missle;
                // select laser
                if (e.KeyCode == Keys.D9)
                    player1.weaponType = WeaponType.laser;

                // shoot missile
                if (e.KeyCode == Keys.ControlKey)
                {
                    Weapon weapon = player1.CreateWeapon(missleSpeed, 1);
                    weapon.InitializeSprite();
                    weapon.PositionSprite();
                    missles.Add(weapon);
                    Controls.Add(weapon.Sprite);
                }
            }

            if (timer.Enabled && player2.Lives != 0) // player 2 still alive
            {
                // move right 
                if (e.KeyCode == Keys.D)
                    player2.MoveRight();
                // move left 
                if (e.KeyCode == Keys.A)
                    player2.MoveLeft();
                // move up 
                if (e.KeyCode == Keys.W)
                    player2.MoveUp();
                // move down 
                if (e.KeyCode == Keys.S)
                    player2.MoveDown();
                // move sprite
                if (e.KeyCode == Keys.D || e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.W)
                    player2.MoveSprite();
                // select missile
                if (e.KeyCode == Keys.D1)
                    player2.weaponType = WeaponType.missle;
                // select laser
                if (e.KeyCode == Keys.D2)
                    player2.weaponType = WeaponType.laser;
                // shoot missile
                if (e.KeyCode == Keys.F)
                {
                    Weapon weapon = player2.CreateWeapon(missleSpeed, 2);
                    weapon.InitializeSprite();
                    weapon.PositionSprite();
                    missles.Add(weapon);
                    Controls.Add(weapon.Sprite);
                }
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
                player1.PositionSprite();
                player2.Reposition(this.Width, this.Height,2);
                player2.InitializeSprite();
                player2.PositionSprite();

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
            // create asteroid
            CreateAsteroid();

            // asteroid collision with players
            PlayerAsteroidCollision();

            // remove weapon out of screen
            RemoveAmmoOutOfScreen();

            // check if players successfully shoots asteroid
            WeaponAsteroidCollision();

            tickCount++;
        }
        #endregion

        #region Extra Core Logic
        private void CreateAsteroid()
        {
            if (tickCount % tickInterval == 0)
            {
                Asteroid asteroid = asteroidFactory.CreateAsteroid();
                asteroids.Add(asteroid);
                Controls.Add(asteroid.Sprite);
            }
        }

        private void PlayerAsteroidCollision()
        {
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
                    }
                    else
                    {
                        for (int j = asteroids.Count - 1; j >= 0; j--)
                        {
                            Controls.Remove(asteroids[j].Sprite);
                        }
                        //Controls.Remove(numberOfLivesLabel);
                       // Controls.Remove(scoreLabel);
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
                        player2.Reposition(this.Width, this.Height, 2);
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
                        //Controls.Remove(numberOfLivesLabel1);
                        //Controls.Remove(scoreLabel1);
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
        }

        private void RemoveAmmoOutOfScreen()
        {
            for (int j = missles.Count - 1; j >= 0; j--)
            {
                missles[j].Move();
                // remove weapon once out of screen
                if (missles[j].IsOutOfScreen(this.Height))
                {
                    Controls.Remove(missles[j].Sprite);
                    missles.RemoveAt(j);
                }
            }
        }

        private void WeaponAsteroidCollision()
        {
            // check if weapon collides with asteroid
            for (int i = missles.Count - 1; i >= 0; i--)
            {
                // count and accummulate how many asteroids got hit
                for (int j = asteroids.Count - 1; j >= 0; j--)
                {
                    if (j > asteroids.Count - 1 || i > missles.Count - 1)
                        break;
                    if (asteroids[j].Sprite.Bounds.IntersectsWith(missles[i].Sprite.Bounds))
                    {
                        

                        if (asteroids[j].healthBar != 1)
                        {
                            asteroids[j].healthBar--;

                        }
                        else
                        {
                            if (missles[i].PlayerNo == 1)
                            {
                                player1.Score += asteroids[j].astScore;
                            }
                            else { 
                                player2.Score+= asteroids[j].astScore;
                            }
                            asteroids[j].Hit = true;
                            
                        }
                        missles[i].Hit = true;
                        //asteroids[j].Hit = true;

                    }
                }
                // remove all cummulative asteroids that got hit
                for (int j = asteroids.Count - 1; j >= 0; j--)
                {
                    if (asteroids[j].Hit)
                    {
                        Controls.Remove(asteroids[j].Sprite);
                        asteroids.RemoveAt(j);
                        if (missles[i].PlayerNo == 1)
                            scoreLabel.Text = String.Format("Score = {0:D2}", ++player1.Score);
                        else
                            scoreLabel1.Text = String.Format("Score = {0:D2}", ++player2.Score);
                    }
                }
                // remove ammo that hit the asteroids
                if (missles[i].Hit && player1.weaponType != WeaponType.laser && player2.weaponType != WeaponType.laser)
                {
                    Controls.Remove(missles[i].Sprite);
                    missles.RemoveAt(i);
                }
            }
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

            // relatively position Player 2's label
            label2.Location = new Point(1, 2);

            // relatively position Player 2 Number of Lives Label
            numberOfLivesLabel1.Location = new Point(1, Convert.ToInt32((double)this.Height * 0.15));

            // relatively position Player 2 Score Label
            scoreLabel1.Location = new Point(1, Convert.ToInt32((double)this.Height * 0.3));

            // relatively position Player 1's label
            label3.Location = new Point(Convert.ToInt32((double)this.Width * 0.87), 2);

            // relatively position Player 1 Number of Lives Label
            numberOfLivesLabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.87), Convert.ToInt32((double)this.Height * 0.15));

            // relatively position Player 1 Score Label
            scoreLabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.87), Convert.ToInt32((double)this.Height * 0.3));

            
        }
    }
}
