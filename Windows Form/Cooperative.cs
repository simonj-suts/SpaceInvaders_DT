using SpaceInvaders.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using System.Media;

namespace SpaceInvaders
{
    public partial class Cooperative : Client
    {
        #region Private fields
        int tickCount;
        Player player1; // Player 1
        Player player2; // Player 2
        Ammo ammodrop;
        Live extralive;
        List<Weapon> missles;
        List<Asteroid> asteroids;
        List<Ammo> ammunition;
        AsteroidFactory asteroidFactory;
        List<Live> extralives;
        SoundPlayer winSound = new SoundPlayer(Properties.Resources.victory);
        SoundPlayer bgm = new SoundPlayer(Properties.Resources.bgmusic);
        #endregion

        #region Settings
        Timer nukeAnimationTime = new Timer();
        int tickInterval = 10;
        int tickInterval1 = 100;
        int tickInterval2 = 150;
        int numberOfPositions = 10;
        int numberOfLives = 3;
        int asteroidSpeed = 30;
        int missleSpeed = 50;
        int ammoSpeed = 40;
        int extraLiveSpeed = 40;
        int missleAmmo1 = 20;
        int laserAmmo1 = 5;
        int missleAmmo2 = 20;
        int laserAmmo2 = 5;
        Size playerSize = new Size(75, 75);
        Size asteroidSize = new Size(75, 75);
        Size ammoDropSize = new Size(75, 75);
        Size extraLiveSize = new Size(75, 75);
        #endregion

        #region Constructors factory methods
        public Cooperative()
        {
            InitializeComponent();

            missles = new List<Weapon>();
            asteroids = new List<Asteroid>();
            ammunition = new List<Ammo>();
            extralives = new List<Live>();

            player1 = new Player(playerSize, numberOfPositions, numberOfLives, 1); // create player 1
            player1.InitializeSprite();
            player2 = new Player(playerSize, numberOfPositions, numberOfLives, 2); // create player 2
            player2.InitializeSprite();

            asteroidFactory = new AsteroidFactory(asteroidSize, asteroidSpeed, numberOfPositions);

            numberOfLivesLabel.Text = String.Format("x {0}", player1.Lives);
            scoreLabel.Text = String.Format("SCORE : {0:D2}", player1.Score);
            missleAmmoLabel1.Text = Convert.ToString(missleAmmo1);
            laserAmmoLabel1.Text = Convert.ToString(laserAmmo1);


            numberOfLivesLabel1.Text = String.Format("x {0}", player2.Lives);
            scoreLabel1.Text = String.Format("SCORE : {0:D2}", player2.Score);
            missleAmmoLabel2.Text = Convert.ToString(missleAmmo2);
            laserAmmoLabel2.Text = Convert.ToString(laserAmmo2);


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
                if (timer.Enabled && e.KeyCode == Keys.D8)
                {
                    player1.weaponType = WeaponType.missle;
                    laser1.BorderStyle = BorderStyle.None;
                    nuke1.BorderStyle = BorderStyle.None;
                    missle1.BorderStyle = BorderStyle.Fixed3D;
                }

                // select laser
                if (timer.Enabled && e.KeyCode == Keys.D9)
                {
                    player1.weaponType = WeaponType.laser;
                    laser1.BorderStyle = BorderStyle.Fixed3D;
                    nuke1.BorderStyle = BorderStyle.None;
                    missle1.BorderStyle = BorderStyle.None;
                }


                // select nuke
                if (timer.Enabled && e.KeyCode == Keys.D0 && player1.Nuke)
                {
                    player1.weaponType = WeaponType.nuke;
                    laser1.BorderStyle = BorderStyle.None;
                    missle1.BorderStyle = BorderStyle.None;
                    nuke1.BorderStyle = BorderStyle.Fixed3D;
                }

                // shoot missile
                if (e.KeyCode == Keys.Space)
                {
                    if (player1.weaponType == WeaponType.missle && missleAmmo1 > 0)
                    {
                        Weapon weapon = player1.CreateWeapon(missleSpeed, 1);
                        weapon.InitializeSprite();
                        weapon.PositionSprite();
                        missles.Add(weapon);
                        Controls.Add(weapon.Sprite);
                        missleAmmo1--;
                    }
                    else if (player1.weaponType == WeaponType.laser && laserAmmo1 > 0)
                    {
                        Weapon weapon = player1.CreateWeapon(missleSpeed, 1);
                        weapon.InitializeSprite();
                        weapon.PositionSprite();
                        missles.Add(weapon);
                        Controls.Add(weapon.Sprite);
                        laserAmmo1--;
                    }
                    else if (player1.weaponType == WeaponType.nuke)
                    {
                        timer.Enabled = !timer.Enabled; // stop time
                        BackColor = Color.White; // simulate explosion

                        // fade out effect after explosion
                        nukeAnimationTime.Tick += new EventHandler(fadeOut);
                        nukeAnimationTime.Start();

                        // reset energy
                        player1.Energy = 0;

                        int total = 0;
                        for (int i = 0; i < asteroids.Count; i++) // remove all asteroids
                        {
                            total += asteroids[i].astScore;
                            Controls.Remove(asteroids[i].Sprite);
                        }
                        asteroids.Clear();
                        player1.Nuke = false;
                        nuke1.Hide();
                        player1.weaponType = WeaponType.missle; // set to default weapon
                        player1.Score += total;
                        laser1.BorderStyle = BorderStyle.None;
                        nuke1.BorderStyle = BorderStyle.None;
                        missle1.BorderStyle = BorderStyle.Fixed3D;
                    }
                    missleAmmoLabel1.Text = Convert.ToString(missleAmmo1);
                    laserAmmoLabel1.Text = Convert.ToString(laserAmmo1);
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
                if (timer.Enabled && e.KeyCode == Keys.D1)
                {
                    player2.weaponType = WeaponType.missle;
                    laser2.BorderStyle = BorderStyle.None;
                    nuke2.BorderStyle = BorderStyle.None;
                    missle2.BorderStyle = BorderStyle.Fixed3D;
                }

                // select laser
                if (timer.Enabled && e.KeyCode == Keys.D2)
                {
                    player2.weaponType = WeaponType.laser;
                    laser2.BorderStyle = BorderStyle.Fixed3D;
                    nuke2.BorderStyle = BorderStyle.None;
                    missle2.BorderStyle = BorderStyle.None;
                }


                // select nuke
                if (timer.Enabled && e.KeyCode == Keys.D3 && player2.Nuke)
                {
                    player2.weaponType = WeaponType.nuke;
                    laser2.BorderStyle = BorderStyle.None;
                    missle2.BorderStyle = BorderStyle.None;
                    nuke2.BorderStyle = BorderStyle.Fixed3D;
                }

                // shoot missile
                if (e.KeyCode == Keys.F)
                {
                    if (player2.weaponType == WeaponType.missle && missleAmmo2 > 0)
                    {
                        Weapon weapon = player2.CreateWeapon(missleSpeed, 2);
                        weapon.InitializeSprite();
                        weapon.PositionSprite();
                        missles.Add(weapon);
                        Controls.Add(weapon.Sprite);
                        missleAmmo2--;
                    }

                    else if (player2.weaponType == WeaponType.laser && laserAmmo2 > 0)
                    {
                        Weapon weapon = player2.CreateWeapon(missleSpeed, 2);
                        weapon.InitializeSprite();
                        weapon.PositionSprite();
                        missles.Add(weapon);
                        Controls.Add(weapon.Sprite);
                        laserAmmo2--;
                    }

                    else if (player2.weaponType == WeaponType.nuke)
                    {
                        timer.Enabled = !timer.Enabled; // stop time
                        BackColor = Color.White; // simulate explosion

                        // fade out effect after explosion
                        nukeAnimationTime.Tick += new EventHandler(fadeOut);
                        nukeAnimationTime.Start();

                        // reset energy
                        player2.Energy = 0;

                        int total = 0;
                        for (int i = 0; i < asteroids.Count; i++) // remove all asteroids
                        {
                            total += asteroids[i].astScore;
                            Controls.Remove(asteroids[i].Sprite);
                        }
                        asteroids.Clear();
                        player2.Nuke = false;
                        nuke2.Hide();
                        player2.weaponType = WeaponType.missle; // set to default weapon
                        laser2.BorderStyle = BorderStyle.None;
                        nuke2.BorderStyle = BorderStyle.None;
                        missle2.BorderStyle = BorderStyle.Fixed3D;
                    }
                    missleAmmoLabel2.Text = Convert.ToString(missleAmmo2);
                    laserAmmoLabel2.Text = Convert.ToString(laserAmmo2);

                }
            }


            // pause
            if (e.KeyCode == Keys.P)
                timer.Enabled = !timer.Enabled;



            // exit
            if (e.KeyCode == Keys.Escape)
            {

                this.Close();
                bgm.Stop();
            }


            // restart
            if (!timer.Enabled && e.KeyCode == Keys.Enter)
            {
                numberOfLivesLabel1.Location = new Point(Convert.ToInt32((double)this.Width * 0.05), Convert.ToInt32((double)this.Height * 0.07));

                // clear everything on screen
                Controls.Clear();
                asteroids.Clear();
                missles.Clear();

                //Replay background music
                winSound.Stop();
                bgm.Play();

                // retrieve new number of lives
                player1.Lives = numberOfLives;
                player2.Lives = numberOfLives;

                // reset player position
                player1.Reposition(this.Width, this.Height, 1);
                player1.InitializeSprite();
                player1.PositionSprite();
                player2.Reposition(this.Width, this.Height, 2);
                player2.InitializeSprite();
                player2.PositionSprite();

                // update number of lives display
                numberOfLivesLabel.Text = String.Format("x {0}", player1.Lives);
                numberOfLivesLabel1.Text = String.Format("x {0}", player2.Lives);

                // reset score
                scoreLabel.Text = String.Format("SCORE : {0:D2}", player1.Score = 0);
                scoreLabel1.Text = String.Format("SCORE : {0:D2}", player2.Score = 0);

                //reset ammo 
                missleAmmoLabel1.Text = Convert.ToString(missleAmmo1 = 20);
                laserAmmoLabel1.Text = Convert.ToString(laserAmmo1 = 5);
                missleAmmoLabel2.Text = Convert.ToString(missleAmmo2 = 20);
                laserAmmoLabel2.Text = Convert.ToString(laserAmmo2 = 5);


                #region re-display
                Controls.Add(numberOfLivesLabel);  // number of lives for player 1
                Controls.Add(numberOfLivesLabel1); // number of lives for player 2
                Controls.Add(scoreLabel);          // score label for player 1
                Controls.Add(scoreLabel1);         // score label for player 2
                Controls.Add(player1.Sprite);      // player 1
                Controls.Add(player2.Sprite);      // player 2
                Controls.Add(missleAmmoLabel1);
                Controls.Add(laserAmmoLabel1);
                Controls.Add(missleAmmoLabel2);
                Controls.Add(laserAmmoLabel2);
                Controls.Add(live1);
                Controls.Add(live2);
                Controls.Add(missle1);
                Controls.Add(missle2);
                Controls.Add(laser1);
                Controls.Add(laser2);
                Controls.Add(nuke1);
                Controls.Add(nuke2);
                Controls.Add(label2);
                Controls.Add(label3);
                #endregion


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

            ammunitionDrop();

            ammunitionDropCollision();

            extralivesDrop();

            extralivesCollision();

            // check if players successfully shoots asteroid
            WeaponAsteroidCollision();


            if (player2.Energy == 10)
            {
                player2.Nuke = true;
                nuke2.Visible = true;
            }

            if (player1.Energy == 10)
            {
                player1.Nuke = true;
                nuke1.Visible = true;
            }


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

        private void ammunitionDrop()
        {
            if (tickCount % tickInterval1 == 0)
            {
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
                if (ammunition[a].Sprite.Bounds.IntersectsWith(player1.Sprite.Bounds))
                {
                    Controls.Remove(ammunition[a].Sprite);
                    ammunition.RemoveAt(a);
                    missleAmmoLabel1.Text = Convert.ToString(missleAmmo1 += 20);
                    laserAmmoLabel1.Text = Convert.ToString(laserAmmo1 += 5);
                }

                else if (ammunition[a].Sprite.Bounds.IntersectsWith(player2.Sprite.Bounds))
                {
                    Controls.Remove(ammunition[a].Sprite);
                    ammunition.RemoveAt(a);
                    missleAmmoLabel2.Text = Convert.ToString(missleAmmo2 += 20);
                    laserAmmoLabel2.Text = Convert.ToString(laserAmmo2 += 5);
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

                if (extralives[v].Sprite.Bounds.IntersectsWith(player1.Sprite.Bounds))
                {
                    Controls.Remove(extralives[v].Sprite);
                    extralives.RemoveAt(v);
                    player1.Lives++;
                    numberOfLivesLabel.Text = String.Format("x {0}", player1.Lives);
                }

                else if (extralives[v].Sprite.Bounds.IntersectsWith(player2.Sprite.Bounds))
                {
                    Controls.Remove(extralives[v].Sprite);
                    extralives.RemoveAt(v);
                    player2.Lives++;
                    numberOfLivesLabel1.Text = String.Format("x {0}", player2.Lives);
                }
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
                    bgm.Stop();
                    Controls.Clear();
                    winSound.Play();
                    numberOfLivesLabel1.Text = String.Format("GAME OVER\nTOTAL SCORE : {0}\n\npress Esc to return to MAIN MENU\n\nOR press ENTER to restart...", player2.Score + player1.Score);
                    numberOfLivesLabel1.Location = new Point(Convert.ToInt32((double)this.Width * 0.4), Convert.ToInt32((double)this.Height * 0.4));

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

                        numberOfLivesLabel.Text = String.Format("x {0}", player1.Lives);
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

                        numberOfLivesLabel1.Text = String.Format("x {0}", player2.Lives);
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
                                player1.Energy += asteroids[j].astScore;
                            }
                            else
                            {
                                player2.Score += asteroids[j].astScore;
                                player2.Energy += asteroids[j].astScore;
                            }
                            asteroids[j].Hit = true;
                        }
                        missles[i].Hit = true;
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
                            scoreLabel.Text = String.Format("SCORE : {0:D2}", ++player1.Score);
                        else
                            scoreLabel1.Text = String.Format("SCORE : {0:D2}", ++player2.Score);
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

        #region extra methods
        private void scoreLabel_Click(object sender, EventArgs e) { }

        private void numberOfLivesLabel_Click(object sender, EventArgs e) { }

        private void missleAmmorLabel1_Click(object sender, EventArgs e) { }

        private void laserAmmorLabel1_Click(object sender, EventArgs e) { }
        private void missleAmmorLabel2_Click(object sender, EventArgs e) { }

        private void laserAmmorLabel2_Click(object sender, EventArgs e) { }
        #endregion

        private void Client_Load(object sender, EventArgs e)
        {
            // PLAYER 2
            label2.Location = new Point(1, 2);
            numberOfLivesLabel1.Location = new Point(Convert.ToInt32((double)this.Width * 0.05), Convert.ToInt32((double)this.Height * 0.07));
            live2.Location = new Point(Convert.ToInt32((double)this.Width * 0.01), Convert.ToInt32((double)this.Height * 0.07));
            scoreLabel1.Location = new Point(1, Convert.ToInt32((double)this.Height * 0.15));
            missleAmmoLabel2.Location = new Point(Convert.ToInt32((double)this.Width * 0.03), Convert.ToInt32((double)this.Height * 0.965));
            laserAmmoLabel2.Location = new Point(Convert.ToInt32((double)this.Width * 0.08), Convert.ToInt32((double)this.Height * 0.965));
            nuke2.Location = new Point(Convert.ToInt32((double)this.Width * 0.11), Convert.ToInt32((double)this.Height * 0.92));
            laser2.Location = new Point(Convert.ToInt32((double)this.Width * 0.06), Convert.ToInt32((double)this.Height * 0.92));
            missle2.Location = new Point(Convert.ToInt32((double)this.Width * 0.01), Convert.ToInt32((double)this.Height * 0.92));

            // PLAYER 1
            label3.Location = new Point(Convert.ToInt32((double)this.Width * 0.895), 2);
            numberOfLivesLabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.94), Convert.ToInt32((double)this.Height * 0.07));
            live1.Location = new Point(Convert.ToInt32((double)this.Width * 0.9), Convert.ToInt32((double)this.Height * 0.07));
            scoreLabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.895), Convert.ToInt32((double)this.Height * 0.15));
            missleAmmoLabel1.Location = new Point(Convert.ToInt32((double)this.Width * 0.96), Convert.ToInt32((double)this.Height * 0.965));
            laserAmmoLabel1.Location = new Point(Convert.ToInt32((double)this.Width * 0.91), Convert.ToInt32((double)this.Height * 0.965));
            missle1.Location = new Point(Convert.ToInt32((double)this.Width * 0.94), Convert.ToInt32((double)this.Height * 0.92));
            laser1.Location = new Point(Convert.ToInt32((double)this.Width * 0.89), Convert.ToInt32((double)this.Height * 0.92));
            nuke1.Location = new Point(Convert.ToInt32((double)this.Width * 0.84), Convert.ToInt32((double)this.Height * 0.92));

            //Background music
            bgm.Play();

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
    }
}
