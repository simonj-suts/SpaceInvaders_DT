using SpaceInvaders.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class Client : Form
    {
        #region Private fields
        static int tickCount;
        Player player;
        Ammo ammodrop;
        List<Weapon> ammo;
        List<Asteroid> asteroids;
        AsteroidFactory asteroidFactory;
        List<Ammo> ammunition;
        #endregion

        #region Settings
        int tickInterval = 10;
        int tickInterval1 = 100;
        int numberOfPositions = 10;
        int numberOfLives = 3;
        int asteroidSpeed = 30;
        int missleSpeed = 50;
        int ammoSpeed = 40;
        int missleAmmo = 20;
        int laserAmmo = 5;
        Size playerSize = new Size(75, 75);
        Size asteroidSize = new Size(75, 75);
        Size ammoDropSize = new Size(75, 75);
        #endregion

        #region Constructors factory methods
        public Client() { }
        public Client(string userName)
        {
            InitializeComponent();
            ammo = new List<Weapon>();
            asteroids = new List<Asteroid>();
            ammunition = new List<Ammo>();
            
            player = new Player(playerSize, numberOfPositions, numberOfLives, userName);
            player.InitializeSprite();
            asteroidFactory = new AsteroidFactory(asteroidSize, asteroidSpeed, numberOfPositions);

            numberOfLivesLabel.Text = String.Format("Number of lives = {0}", player.Lives);
            scoreLabel.Text = String.Format("Score = {0:D2}", player.Score);
            missleAmmoLabel.Text = String.Format("Missle Ammo = {0}", missleAmmo);
            laserAmmoLabel.Text = String.Format("Laser Ammo = {0}", laserAmmo);

            Controls.Add(player.Sprite);
        }
        #endregion

        #region Core logic
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (player != null)
            {
                player.Reposition(this.Width, this.Height, 1);
                player.PositionSprite();
            }
            if (asteroidFactory != null) 
                asteroidFactory.ScreenW = this.Width;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // move right
            if (timer.Enabled && e.KeyCode == Keys.Right)
            {
                player.MoveRight();
                player.MoveSprite();
            }

            // move left
            if (timer.Enabled && e.KeyCode == Keys.Left)
            {
                player.MoveLeft();
                player.MoveSprite();
            }

            // move up
            if (timer.Enabled && e.KeyCode == Keys.Up)
            {
                player.MoveUp();
                player.MoveSprite();
            }

            // move down
            if (timer.Enabled && e.KeyCode == Keys.Down)
            {
                player.MoveDown();
                player.MoveSprite();
            }

            // select missile
            if (timer.Enabled && e.KeyCode == Keys.D1)
                player.weaponType = WeaponType.missle;

            // select laser
            if (timer.Enabled && e.KeyCode == Keys.D2)
                player.weaponType = WeaponType.laser;

            // shoot
            if (timer.Enabled && e.KeyCode == Keys.Space)
            {
                if (player.weaponType == WeaponType.missle && missleAmmo > 0)
                {
                    Weapon weapon = player.CreateWeapon(missleSpeed, 1);
                    weapon.InitializeSprite();
                    weapon.PositionSprite();
                    ammo.Add(weapon);
                    Controls.Add(weapon.Sprite);
                    missleAmmo--;
                    missleAmmoLabel.Text = String.Format("Missle Ammo = {0}", missleAmmo);
                    laserAmmoLabel.Text = String.Format("Laser Ammo = {0}", laserAmmo);
                }

                else if (player.weaponType == WeaponType.laser && laserAmmo > 0)
                {
                    Weapon weapon = player.CreateWeapon(missleSpeed, 1);
                    weapon.InitializeSprite();
                    weapon.PositionSprite();
                    ammo.Add(weapon);
                    Controls.Add(weapon.Sprite);
                    laserAmmo--;
                    missleAmmoLabel.Text = String.Format("Missle Ammo = {0}", missleAmmo);
                    laserAmmoLabel.Text = String.Format("Laser Ammo = {0}", laserAmmo);
                }
                
            }

            // pause
            if (e.KeyCode == Keys.P)
                timer.Enabled = !timer.Enabled;

            // restart
            if (!timer.Enabled && e.KeyCode == Keys.Enter)
            {

                Controls.Clear();
                asteroids.Clear();
                ammo.Clear();
                
                player.Lives = numberOfLives;
                player.Reposition(this.Width, this.Height,1);
                player.InitializeSprite();
                player.PositionSprite();

                numberOfLivesLabel.Text = String.Format("Number of lives = {0}", player.Lives);
                scoreLabel.Text = String.Format("Score = {0:D2}", player.Score = 0);
                missleAmmoLabel.Text = String.Format("Missle Ammo = {0}", missleAmmo);
                laserAmmoLabel.Text = String.Format("Laser Ammo = {0}", laserAmmo);
                Controls.Add(numberOfLivesLabel);
                Controls.Add(scoreLabel);
                Controls.Add(player.Sprite);
                timer.Start();
            }

            //exit
            if (timer.Enabled && e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (!timer.Enabled && e.KeyCode == Keys.E)
            {
                Scoreboard scr = new Scoreboard();
                scr.updateScoreboard(player);
                scr.updateFile();
                ScoreBoardDisplay scrBoard = new ScoreBoardDisplay(scr);
                scrBoard.Show();
                this.Close();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // create and add asteroid every tickInterval ticks
            CreateAsteroid(asteroids,tickInterval,tickCount);

            // detect asteroid collision with player
            PlayerAsteroidCollision(player);

            // remove ammo that goes out of screen
            RemoveAmmoOutOfScreen(ammo);

            //ammunition drop
            ammunitionDrop();

            ammunitionDropCollision();

            // detect asteroid collision with ammo
            WeaponAsteroidCollision(ammo,asteroids);
            tickCount++;

        }

        private void ammunitionDrop()
        {
            if (tickCount % tickInterval1 == 0)
            {
                ammodrop = new Ammo(ammoDropSize, ammoSpeed, this.Width, this.Height);
                ammodrop.InitializeSprite();
                ammodrop.SetLocation(ammodrop.RandomizeX(), ammodrop.RandomizeY());
                ammodrop.PositionSprite();
                ammunition.Add(ammodrop);
                Controls.Add(ammodrop.Sprite);
            }           
        }

        private void ammunitionDropCollision()
        {
            for (int a = ammunition.Count - 1; a >= 0; a--)
            {
                if (ammunition[a].Sprite.Bounds.IntersectsWith(player.Sprite.Bounds))
                {
                    Controls.Remove(ammunition[a].Sprite);
                    ammunition.RemoveAt(a);
                    missleAmmo += 20;
                    laserAmmo += 5;
                    missleAmmoLabel.Text = String.Format("Missle Ammo = {0}", missleAmmo);
                    laserAmmoLabel.Text = String.Format("Laser Ammo = {0}", laserAmmo);
                }
            }
        }
        
        private void CreateAsteroid(List<Asteroid> asteroids, int tickInterval, int tickCount)
        {
            if (tickCount % tickInterval == 0)
            {
                Asteroid asteroid = asteroidFactory.CreateAsteroid();
                asteroids.Add(asteroid);
                Controls.Add(asteroid.Sprite);
            }
        }

        private void PlayerAsteroidCollision(Player player)
        {
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
                        ammo.Clear();
                        player.Lives--;
                        player.Reposition(this.Width, this.Height, 1);
                        player.InitializeSprite();
                        player.PositionSprite();

                        numberOfLivesLabel.Text = String.Format("Number of lives = {0}", player.Lives);
                        missleAmmoLabel.Text = String.Format("Missle Ammo = {0}", missleAmmo);
                        laserAmmoLabel.Text = String.Format("Laser Ammo = {0}", laserAmmo);
                        Controls.Add(numberOfLivesLabel);
                        Controls.Add(scoreLabel);
                        Controls.Add(missleAmmoLabel);
                        Controls.Add(laserAmmoLabel);
                        Controls.Add(player.Sprite);
                        break;
                    }
                    else
                    {
                        Controls.Clear();
                        numberOfLivesLabel.Text = "Game over, press enter to restart, or 'e' to return to MAIN MENU...";
                        Controls.Add(numberOfLivesLabel);
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
        }

        private  void RemoveAmmoOutOfScreen(List<Weapon> ammo)
        {
            for (int j = ammo.Count - 1; j >= 0; j--)
            {
                ammo[j].Move();
                // remove weapon once out of screen
                if (ammo[j].IsOutOfScreen(this.Height))
                {
                    Controls.Remove(ammo[j].Sprite);
                    ammo.RemoveAt(j);
                }
            }
        }
        
        private void WeaponAsteroidCollision(List<Weapon> ammo, List<Asteroid> asteroids)
        {
            // check if weapon collides with asteroid
            for (int i = ammo.Count - 1; i >= 0; i--)
            {
                // count and accummulate how many asteroids got hit
                for (int j = asteroids.Count - 1; j >= 0; j--)
                {
                    if (j > asteroids.Count - 1 || i > ammo.Count - 1)
                        break;
                    if (asteroids[j].Sprite.Bounds.IntersectsWith(ammo[i].Sprite.Bounds))
                    {
                        if (asteroids[j].healthBar != 1)
                        {
                            asteroids[j].healthBar--;

                        }
                        else
                        {

                            player.Score += asteroids[j].astScore;

                            asteroids[j].Hit = true;
                            
                        }
                        ammo[i].Hit = true;
                    }
                }
                // remove all cummulative asteroids that got hit
                for (int j = asteroids.Count - 1; j >= 0; j--)
                {
                    if (asteroids[j].Hit)
                    {
                        Controls.Remove(asteroids[j].Sprite);
                        asteroids.RemoveAt(j);
                        scoreLabel.Text = String.Format("Score = {0:D2}", ++player.Score);
                    }
                }
                // remove ammo that hit the asteroids
                if (ammo[i].Hit && player.weaponType != WeaponType.laser)
                {
                    Controls.Remove(ammo[i].Sprite);
                    ammo.RemoveAt(i);
                }
            }
        }
        #endregion
        private void Client_Load(object sender, EventArgs e){
            // relatively position Player 1 Number of Lives Label
            numberOfLivesLabel.Location = new Point(1, 2);

            // relatively position Player 1 Score Label
            scoreLabel.Location = new Point(1, Convert.ToInt32((double)this.Height * 0.15));
        }

        private void numberOfLivesLabel_Click(object sender, EventArgs e){}

        private void scoreLabel_Click(object sender, EventArgs e){}

        private void missleAmmorLabel_Click(object sender, EventArgs e){}

        private void laserAmmorLabel_Click(object sender, EventArgs e) { }
    }
}

