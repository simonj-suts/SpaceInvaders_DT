using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SpaceInvaders
{
    public class Player : AnimatedObject
    {
        #region Private fields
        int interval;
        int screenW, screenH;
        int numberOfPositions;
        int playerNo;
        #endregion

        #region Public fields
        public int Lives { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
        #endregion

        #region Constructors and factory methods
        public Player(Size size, int numberOfPositions, int numberOfLives, int aPlayerNo) : base(size)
        {
            Lives = numberOfLives;
            this.numberOfPositions = numberOfPositions;
            playerNo = aPlayerNo;
        }

        public Player(Size size, int numberOfPositions, int numberOfLives, string userName) : base(size)
        {
            Name = userName;
            Lives = numberOfLives;
            this.numberOfPositions = numberOfPositions;
            playerNo = 1;
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
            } else
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

        public void Reposition(int screenW, int screenH, int playerNo)
        {
            this.screenW = screenW;
            this.screenH = screenH;

            this.interval = screenW / numberOfPositions;
            this.speed = interval;

            if (playerNo == 1)
            {
                this.x = screenW - interval;
                this.y = screenH - 150;
            }
            else if (playerNo == 2)
            {
                this.x = speed;
                this.y = screenH - 150;
            }
            else if (playerNo == 3)
            {
                this.x = speed;
                this.y = screenH - 800;
            }
        }

        public void MoveLeft()
        {
            if (x <= speed) return;

            x -= speed;
            Sprite.Left -= speed;
        }

        public void MoveRight()
        {
            if (x >= this.screenW - 150) return;

            x += speed;
            Sprite.Left += speed;
        }

        public Missle CreateMissle(Size size, int speed, int playerNo)
        {
            Missle missle = new Missle(size, speed, playerNo);
            missle.SetLocation(x + this.size.Width / 2, y);
            return missle;
        }
        #endregion
    }
}
