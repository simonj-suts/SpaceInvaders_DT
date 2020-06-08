using SpaceInvaders.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace SpaceInvaders
{
    public partial class Client : Form
    {
        #region Private fields
        static int tickCount;
        Player player;
        Ammo ammodrop;
        Live extralive;
        List<Weapon> ammo;
        List<Asteroid> asteroids;
        AsteroidFactory asteroidFactory;
        List<Ammo> ammunition;
        List<Live> extralives;
        SoundPlayer winSound = new SoundPlayer(Properties.Resources.victory);
        SoundPlayer bgm = new SoundPlayer(Properties.Resources.bgmusic);
        #endregion

        #region Settings
        Timer nukeAnimationTime = new Timer();
        bool nuke = false;
        int tickInterval = 10;
        int tickInterval1 = 100;
        int tickInterval2 = 150;
        int numberOfPositions = 10;
        int numberOfLives = 3;
        int asteroidSpeed = 30;
        int missleSpeed = 50;
        int ammoSpeed = 40;
        int extraLiveSpeed = 40;
        int missleAmmo = 20;
        int laserAmmo = 5;
        Size playerSize = new Size(75, 75);
        Size asteroidSize = new Size(75, 75);
        Size ammoDropSize = new Size(75, 75);
        Size extraLiveSize = new Size(75, 75);
        #endregion

        #region Constructors factory methods
        public Client() { }
        public Client(string userName)
        {
            InitializeComponent();
            ammo = new List<Weapon>();
            asteroids = new List<Asteroid>();
            ammunition = new List<Ammo>();
            extralives = new List<Live>();

            player = new Player(playerSize, numberOfPositions, numberOfLives, userName);
            player.InitializeSprite();
            asteroidFactory = new AsteroidFactory(asteroidSize, asteroidSpeed, numberOfPositions);

            numberOfLivesLabel.Text = String.Format("x {0}", player.Lives);
            scoreLabel.Text = String.Format("SCORE : {0:D2}", player.Score);
            missleAmmoLabel.Text = Convert.ToString(missleAmmo);
            laserAmmoLabel.Text = Convert.ToString(laserAmmo);

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
            if (timer.Enabled && player.Lives != 0)
            {
                // move right
                if (e.KeyCode == Keys.Right)
                {
                    player.MoveRight();
                    player.MoveSprite();
                }

                // move left
                if ( e.KeyCode == Keys.Left)
                {
                    player.MoveLeft();
                    player.MoveSprite();
                }

                // move up
                if (e.KeyCode == Keys.Up)
                {
                    player.MoveUp();
                    player.MoveSprite();
                }

                // move down
                if (e.KeyCode == Keys.Down)
                {
                    player.MoveDown();
                    player.MoveSprite();
                }

                // select missile
                if ( e.KeyCode == Keys.D1)
                {
                    player.weaponType = WeaponType.missle;
                    laserImg.BorderStyle = BorderStyle.None;
                    nukeImg.BorderStyle = BorderStyle.None;
                    missleImg.BorderStyle = BorderStyle.Fixed3D;
                }

                // select laser
                if (e.KeyCode == Keys.D2)
                {
                    player.weaponType = WeaponType.laser;
                    laserImg.BorderStyle = BorderStyle.Fixed3D;
                    nukeImg.BorderStyle = BorderStyle.None;
                    missleImg.BorderStyle = BorderStyle.None;
                }


                // select nuke
                if ( e.KeyCode == Keys.D3 && nuke)
                {
                    player.weaponType = WeaponType.nuke;
                    laserImg.BorderStyle = BorderStyle.None;
                    missleImg.BorderStyle = BorderStyle.None;
                    nukeImg.BorderStyle = BorderStyle.Fixed3D;
                }

                // shoot
                if (e.KeyCode == Keys.Space)
                {
                    if (player.weaponType == WeaponType.missle && missleAmmo > 0)
                    {
                        Weapon weapon = player.CreateWeapon(missleSpeed, 1);
                        weapon.InitializeSprite();
                        weapon.PositionSprite();
                        ammo.Add(weapon);
                        Controls.Add(weapon.Sprite);
                        missleAmmo--;
                    }

                    else if (player.weaponType == WeaponType.laser && laserAmmo > 0)
                    {
                        Weapon weapon = player.CreateWeapon(missleSpeed, 1);
                        weapon.InitializeSprite();
                        weapon.PositionSprite();
                        ammo.Add(weapon);
                        Controls.Add(weapon.Sprite);
                        laserAmmo--;
                    }

                    else if (player.weaponType == WeaponType.nuke)
                    {
                        timer.Enabled = !timer.Enabled; // stop time
                        BackColor = Color.White; // simulate explosion

                        // fade out effect after explosion
                        nukeAnimationTime.Tick += new EventHandler(fadeOut);
                        nukeAnimationTime.Start();

                        // reset energy
                        player.Energy = 0;

                        int total = 0;
                        for (int i = 0; i < asteroids.Count; i++) // remove all asteroids
                        {
                            total += asteroids[i].astScore;
                            Controls.Remove(asteroids[i].Sprite);
                        }
                        asteroids.Clear();
                        nuke = false;
                        nukeImg.Hide();
                        player.weaponType = WeaponType.missle; // set to default weapon
                        laserImg.BorderStyle = BorderStyle.None;
                        nukeImg.BorderStyle = BorderStyle.None;
                        missleImg.BorderStyle = BorderStyle.Fixed3D;
                    }
                    missleAmmoLabel.Text = Convert.ToString(missleAmmo);
                    laserAmmoLabel.Text = Convert.ToString(laserAmmo);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    bgm.Stop();
                    this.Close();
                    return;
                }
            }
            // pause
            if (e.KeyCode == Keys.P)
                timer.Enabled = !timer.Enabled;

            // restart
            if (!timer.Enabled && e.KeyCode == Keys.Enter)
            {
                //Clear screen
                Controls.Clear();
                asteroids.Clear();
                ammo.Clear();

                //Replay background music
                winSound.Stop();
                bgm.Play();

                // reset player lives and position
                player.Lives = numberOfLives;
                player.Reposition(this.Width, this.Height, 1);
                player.InitializeSprite();
                player.PositionSprite();

                numberOfLivesLabel.Text = String.Format("x {0}", player.Lives);
                scoreLabel.Text = String.Format("SCORE : {0:D2}", player.Score);
                missleAmmoLabel.Text = Convert.ToString(missleAmmo);
                laserAmmoLabel.Text = Convert.ToString(laserAmmo);
                Control[] controls = new Control[] { numberOfLivesLabel, scoreLabel, laserAmmoLabel, missleAmmoLabel, missleAmmoLabel, nukeImg, laserImg, missleImg, liveImg, player.Sprite };
                Controls.AddRange(controls);
                timer.Start();
            }

            

            //exit and view scoreboard
            if (e.KeyCode == Keys.Escape)
            {
                bgm.Stop();
                winSound.Stop();
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
            CreateAsteroid(asteroids, tickInterval, tickCount);

            // detect asteroid collision with player
            PlayerAsteroidCollision(player);

            // remove ammo that goes out of screen
            RemoveAmmoOutOfScreen(ammo);

            //ammunition drop
            ammunitionDrop();

            //detect player receive ammo
            ammunitionDropCollision();

            // extra lives
            extralivesDrop();

            //detect player receive extra live
            extralivesCollision();

            // detect asteroid collision with ammo
            WeaponAsteroidCollision(ammo, asteroids);

            if (player.Energy == 10)
            {
                nuke = true;
                nukeImg.Show();
            }
            tickCount++;

        }

        private void ammunitionDrop()
        {
            if (tickCount % tickInterval1 == 0)
            {
                Random rand = new Random();
                ammodrop = new Ammo(ammoDropSize, ammoSpeed, this.Width, this.Height);
                ammodrop.InitializeSprite();
                ammodrop.SetLocation(ammodrop.RandomizeX(), ammodrop.RandomizeY());
                ammodrop.RandomMove();
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
                    missleAmmoLabel.Text = Convert.ToString(missleAmmo);
                    laserAmmoLabel.Text = Convert.ToString(laserAmmo);
                }
            }
        }

        private void extralivesDrop()
        {
            if (tickCount % tickInterval2 == 0)
            {
                extralive = new Live(extraLiveSize, extraLiveSpeed, this.Width, this.Height);
                extralive.InitializeSprite();
                extralive.SetLocation(extralive.RandomizeX(), -100);
                extralive.PositionSprite();
                extralives.Add(extralive);
                Controls.Add(extralive.Sprite);
            }
        }

        private void extralivesCollision()
        {
            for (int v = extralives.Count - 1; v >= 0; v--)
            {
                extralives[v].Move();

                if (extralives[v].Sprite.Bounds.IntersectsWith(player.Sprite.Bounds))
                {
                    Controls.Remove(extralives[v].Sprite);
                    extralives.RemoveAt(v);
                    player.Lives++;
                    numberOfLivesLabel.Text = String.Format("x {0}", player.Lives);
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

                        numberOfLivesLabel.Text = String.Format("x {0}", player.Lives);
                        missleAmmoLabel.Text = Convert.ToString(missleAmmo);
                        laserAmmoLabel.Text = Convert.ToString(laserAmmo);
                        Control[] controls = new Control[] { numberOfLivesLabel, scoreLabel, laserAmmoLabel, missleAmmoLabel, missleAmmoLabel, nukeImg, laserImg, missleImg, liveImg, player.Sprite };
                        Controls.AddRange(controls);
                        break;
                    }
                    else
                    {
                        bgm.Stop();
                        Controls.Clear();
                        winSound.Play();
                        numberOfLivesLabel2.Text = "Game over, press enter to RESTART, Esc to return to MAIN MENU...";
                        numberOfLivesLabel2.Location = new Point(Convert.ToInt32((double)this.Width * 0.30), Convert.ToInt32((double)this.Height * 0.45));
                        Controls.Add(numberOfLivesLabel2);
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

        private void RemoveAmmoOutOfScreen(List<Weapon> ammo)
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
                        scoreLabel.Text = String.Format("SCORE : {0:D2}", ++player.Score);
                        ++player.Energy;
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
        private void Client_Load(object sender, EventArgs e)
        {

            bgm.Play();
            // relatively position Player 1 Number of Lives Label
            numberOfLivesLabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.8), Convert.ToInt32((double)this.Height * 0.94));
            liveImg.Location = new Point(Convert.ToInt32((double)this.Width * 0.75), Convert.ToInt32((double)this.Height * 0.92));
            // relatively position Player 1 Score Label
            scoreLabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.87), Convert.ToInt32((double)this.Height * 0.01));

            // relatively position Player 1 laser ammo
            laserAmmoLabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.91), Convert.ToInt32((double)this.Height * 0.965));

            // relatively position Player 1 missile ammo
            missleAmmoLabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.96), Convert.ToInt32((double)this.Height * 0.965));

            // relatively position Nuke Image
            nukeImg.Location = new Point(Convert.ToInt32((double)this.Width * 0.84), Convert.ToInt32((double)this.Height * 0.92));

            // relatively position Laser Image
            laserImg.Location = new Point(Convert.ToInt32((double)this.Width * 0.89), Convert.ToInt32((double)this.Height * 0.92));

            // relatively position Missile Image
            missleImg.Location = new Point(Convert.ToInt32((double)this.Width * 0.94), Convert.ToInt32((double)this.Height * 0.92));
        }

        private void fadeOut(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                nukeAnimationTime.Stop();
                BackColor = Color.Black;
                Opacity = 1;
                timer.Enabled = !timer.Enabled;
            }
            Opacity -= 0.05;
        }

        private void numberOfLivesLabel_Click(object sender, EventArgs e) { }

        private void scoreLabel_Click(object sender, EventArgs e) { }

        private void missleAmmorLabel_Click(object sender, EventArgs e) { }

        private void laserAmmorLabel_Click(object sender, EventArgs e) { }
    }
}

