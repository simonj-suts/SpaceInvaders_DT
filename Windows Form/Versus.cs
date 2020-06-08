using SpaceInvaders.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SpaceInvaders
{
    public partial class Versus : Form
    {
        #region Private fields
        int tickCount;
        Player Player1; // Player 1
        Player Player2; // Player 2
        List<Weapon> missles;
        List<Weapon> missles2;
        SoundPlayer winSound = new SoundPlayer(Properties.Resources.victory);
        SoundPlayer bgm = new SoundPlayer(Properties.Resources.bgmusic);
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

            missles = new List<Weapon>();
            missles2 = new List<Weapon>();
            //asteroids = new List<Asteroid>();

            Player1 = new Player(PlayerSize, numberOfPositions, numberOfLives, 1); // create Player 1
            Player1.InitializeSprite();
            Player2 = new Player(PlayerSize, numberOfPositions, numberOfLives, 3); // create Player 2
            Player2.InitializeSprite();

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
            if (Player1 != null)
            {
                Player1.Reposition(this.Width, this.Height, 1);
                Player1.PositionSprite();
            }
            if (Player2 != null)
            {
                Player2.Reposition(this.Width, this.Height, 3);
                Player2.PositionSprite();
            }
        }

        // Controls
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer.Enabled && Player1.Lives != 0) // player 1 still alive
            {
                // move right 
                if (e.KeyCode == Keys.Right)
                    Player1.MoveRight();
                // move left 
                if (e.KeyCode == Keys.Left)
                    Player1.MoveLeft();
                // move up 
                if (e.KeyCode == Keys.Up)
                    Player1.MoveUp();
                // move down 
                if (e.KeyCode == Keys.Down)
                    Player1.MoveDown();
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                    Player1.MoveSprite();
                // select missile
                if (e.KeyCode == Keys.D8)
                    Player1.weaponType = WeaponType.missle;
                // select laser
                if (e.KeyCode == Keys.D9)
                    Player1.weaponType = WeaponType.laser;
                // shoot missile
                if (e.KeyCode == Keys.Space)
                {
                    Weapon Weapon = Player1.CreateWeapon(missleSpeed, 1);
                    Weapon.InitializeSprite();
                    Weapon.PositionSprite();
                    missles.Add(Weapon);
                    Controls.Add(Weapon.Sprite);
                }

                
            }

            if (timer.Enabled && Player2.Lives != 0) // player 2 still alive
            {
                // move right 
                if (e.KeyCode == Keys.D)
                    Player2.MoveRight();
                // move left 
                if (e.KeyCode == Keys.A)
                    Player2.MoveLeft();
                // move up 
                if (e.KeyCode == Keys.W)
                    Player2.MoveUp();
                // move down 
                if (e.KeyCode == Keys.S)
                    Player2.MoveDown();
                // select missile
                if (e.KeyCode == Keys.D1)
                    Player2.weaponType = WeaponType.missle;
                // select laser
                if (e.KeyCode == Keys.D2)
                    Player2.weaponType = WeaponType.laser;
                // move sprite
                if (e.KeyCode == Keys.D || e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.W)
                    Player2.MoveSprite();
                // shoot missile
                if (e.KeyCode == Keys.F)
                {
                    Weapon Weapon = Player2.CreateWeapon(missleSpeed, 3);
                    Weapon.InitializeSprite();
                    Weapon.PositionSprite();
                    missles2.Add(Weapon);
                    Controls.Add(Weapon.Sprite);
                }
            }

            // pause
            if (e.KeyCode == Keys.P)
                timer.Enabled = !timer.Enabled;

            // exit
            if (e.KeyCode == Keys.Escape)
            {
                bgm.Stop();
                this.Close();
            }

            // restart
            if (!timer.Enabled && e.KeyCode == Keys.Enter)
            {
                // clear everything on screen
                Controls.Clear();
                missles.Clear();

                //Replay background music
                winSound.Stop();
                bgm.Play();

                // retrieve new number of lives
                Player1.Lives = numberOfLives;
                Player2.Lives = numberOfLives;

                // reset Player position
                Player1.Reposition(this.Width, this.Height, 1);
                Player1.InitializeSprite();
                Player1.PositionSprite();

                Player2.Reposition(this.Width, this.Height, 3);
                Player2.InitializeSprite();
                Player2.PositionSprite();

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

                // remove Weapon once out of screen
                if (missles[j].IsOutOfScreen(this.Height))
                {
                    Controls.Remove(missles[j].Sprite);
                    missles.RemoveAt(j);
                }
            }

            for (int i = missles2.Count - 1; i >= 0; i--)
            {
                missles2[i].Move();

                // remove Weapon once out of screen
                if (missles2[i].IsOutOfScreen(this.Height))
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
                        Player2.Reposition(this.Width, this.Height, 3);
                        Player2.InitializeSprite();
                        Player2.PositionSprite();

                        numberOfLivesLabel1.Text = String.Format("Lives = {0}", Player2.Lives);
                        Controls.Add(numberOfLivesLabel1);
                        Controls.Add(Player2.Sprite);
                        break;
                    }
                    else
                    {
                        bgm.Stop();
                        this.Close();
                        VersusGameOverScreen g = new VersusGameOverScreen();
                        winSound.Play();
                        g.winner(1);
                        g.Show();
                        Controls.Remove(numberOfLivesLabel);
                        Controls.Remove(numberOfLivesLabel1);
                        Controls.Remove(scoreLabel1);
                        Controls.Remove(Player1.Sprite);
                        Controls.Remove(Player2.Sprite);
                        timer.Enabled = false;
                        break;
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
                        Player1.InitializeSprite();
                        Player1.PositionSprite();

                        numberOfLivesLabel.Text = String.Format("Lives = {0}", Player1.Lives);
                        Controls.Add(numberOfLivesLabel);
                        Controls.Add(Player1.Sprite);
                        break;
                    }
                    else
                    {
                        bgm.Stop();
                        this.Close();
                        VersusGameOverScreen g = new VersusGameOverScreen();
                        g.winner(2);
                        winSound.Play();
                        g.Show();
                        Controls.Remove(numberOfLivesLabel);
                        Controls.Remove(numberOfLivesLabel1);
                        Controls.Remove(scoreLabel1);
                        Controls.Remove(Player1.Sprite);
                        Controls.Remove(Player2.Sprite);
                        timer.Enabled = false;
                        break;
                    }
                }
            }
            tickCount++;
        }
        #endregion

        private void numberOfLivesLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void Versus_Load(object sender, EventArgs e)
        {
            bgm.Play();
            // relatively position Player 2 Number of Lives Label
            numberOfLivesLabel1.Location = new Point(1, 2);

            // relatively position Player 1 Number of Lives Label
            numberOfLivesLabel.Location = new Point(Convert.ToInt32((double)this.Width * 0.87), 2);

        }


        private void Versus_Load_1(object sender, EventArgs e)
        {

        }

        
    }
}
