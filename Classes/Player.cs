using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SpaceInvaders
{
    public class Player : AnimatedObject
    {
        #region Private fields
        int intervalX;
        int intervalY;
        int screenW, screenH;
        int numberOfPositions;
        int playerNo;
        int SpritePosition;
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

            this.intervalX = screenW / numberOfPositions;
            this.intervalY = screenH / numberOfPositions;
            this.speed = intervalX;

            if (playerNo == 1)
            {
                this.x = screenW - intervalX;
                this.y = screenH - intervalY;
            }
            else if (playerNo == 2)
            {
                this.x = speed;
                this.y = screenH - intervalY;
            }
            else if (playerNo == 3)
            {
                this.x = speed;
                this.y = intervalY;
            }
        }

        public void MoveSprite()
        {
            switch (SpritePosition)
            {
                case 1:
                    Sprite.Left -= speed;
                    break;
                case 2:
                    Sprite.Left += speed;
                    break;
                case 3:
                    Sprite.Top -= intervalY;
                    break;
                case 4:
                    Sprite.Top += intervalY;
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
            if (y >= this.screenH - intervalY) return;
            y += intervalY;
            SpritePosition = 4;
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
