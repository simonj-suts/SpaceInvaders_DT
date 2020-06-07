using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using SpaceInvaders.Classes;
using System.Runtime.InteropServices;
using System;

namespace SpaceInvaders
{
    public class Player : AnimatedObject
    {
        #region Private fields
        double intervalX;
        double intervalY;
        double screenW, screenH;
        double numberOfPositions;
        double SpritePosition;
        int _energy;
        int _lives;
        #endregion

        #region Public fields
        public int Lives
        {
            get { return _lives; }
            set { _lives = Math.Min(value, 3); }
        }
        public int Score { get; set; }
        public bool Nuke { get; set; }
        public int Energy
        {
            get { return _energy; }
            set { _energy = Math.Min(value, 10); }
        }
        public string Name { get; set; }
        public WeaponType weaponType { get; set; }
        public int playerNo { get; set; }
        #endregion

        #region Constructors and factory methods
        public Player(Size size, int numberOfPositions, int numberOfLives, int aPlayerNo) : base(size)
        {
            Lives = numberOfLives;
            this.numberOfPositions = numberOfPositions;
            playerNo = aPlayerNo;
            weaponType = WeaponType.missle;
            _energy = 0;
            Nuke = false;
        }

        public Player(Size size, int numberOfPositions, int numberOfLives, string userName) : base(size)
        {
            Name = userName;
            Lives = numberOfLives;
            this.numberOfPositions = numberOfPositions;
            playerNo = 1;
            weaponType = WeaponType.missle;
            _energy = 0;
        }

        public Player(string name, int scores)
        {
            Lives = 3;
            this.size = new Size(75, 75);
            this.numberOfPositions = 10;
            this.Name = name;
            this.Score = scores;
        }

        #endregion

        #region Public methods
        public override void InitializeSprite()
        {
            Image img;
            if (playerNo == 1)
            {
                img = Properties.Resources.player1;
            }
            else if (playerNo == 2)
            {
                img = Properties.Resources.player2;
            }
            else
            {
                img = Properties.Resources.playervs2;
            }

            Sprite = new PictureBox
            {
                Tag = "player",
                Size = size,
                BackColor = Color.Transparent,
                Image = img,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            Sprite.BringToFront();
        }

        public void Reposition(double screenW, double screenH, int playerNo)
        {
            this.screenW = screenW;
            this.screenH = screenH;

            this.intervalX = screenW / numberOfPositions;
            this.intervalY = screenH / numberOfPositions;
            this.speed = intervalX;

            this.x = screenW - intervalX;
            this.y = screenH - intervalY * 2;
            if (playerNo == 2)
            {
                this.x -= speed * 8;
            }
            if (playerNo == 3)
            {
                this.x -= speed * 8;
                this.y -= intervalY * 8;
            }
        }

        public void MoveSprite()
        {
            switch (SpritePosition)
            {
                case 1:
                    Sprite.Left -= (int)speed;
                    break;
                case 2:
                    Sprite.Left += (int)speed;
                    break;
                case 3:
                    Sprite.Top -= (int)intervalY;
                    break;
                case 4:
                    Sprite.Top += (int)intervalY;
                    break;
            }
            SpritePosition = 0;
        }

        public void MoveLeft()
        {
            if (x <= speed) return;
            x -= speed;
            SpritePosition = 1;
        }

        public void MoveRight()
        {
            if (x >= this.screenW - intervalX) return;
            x += speed;
            SpritePosition = 2;
        }

        public void MoveUp()
        {
            if (y <= intervalY) return;
            y -= intervalY;
            SpritePosition = 3;
        }

        public void MoveDown()
        {
            if (y + intervalY >= this.screenH - intervalY) return;
            y += intervalY;
            SpritePosition = 4;
        }

        public Weapon CreateWeapon(int speed, int playerNo)
        {
            Weapon weapon;
            Size weaponsize;
            double weaponPosY = y;
            switch (weaponType)
            {
                case WeaponType.laser:
                    if (playerNo == 3)
                    {
                        weaponsize = new Size(15, (int)(screenH - this.Y - 5));
                        weaponPosY = screenH - 10;
                    }
                    else
                    {
                        weaponsize = new Size(15, (int)(screenH - (screenH - this.y)));
                        weaponPosY += 2;
                    }
                    weapon = new Laser(weaponsize, speed, playerNo);
                    break;
                default:
                    weaponsize = new Size(15, 45);
                    weapon = new Missile(weaponsize, speed, playerNo);
                    break;
            }
            weapon.SetLocation((int)(x + this.size.Width / 2), (int)weaponPosY);
            return weapon;
        }
        #endregion
    }
}
