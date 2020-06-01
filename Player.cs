using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SpaceInvaders
{
    class Player
    {
        #region Private fields
        Size size;
        int interval;
        int speed, x, y;
        int screenW, screenH;
        int numberOfPositions;
        #endregion

        #region Public fields
        public PictureBox Sprite { get; private set; }
        public int Lives { get; set; }
        public int Score { get; set; }
        #endregion

        #region Constructors and factory methods
        public Player(Size size, int numberOfPositions, int numberOfLives, Image image)
        {
            Lives = numberOfLives;
            this.size = size;
            this.numberOfPositions = numberOfPositions;

            // initialize sprite
            Sprite = new PictureBox
            {
                Tag = "player",
                Size = size,
                BackColor = Color.Transparent,
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Sprite.BringToFront();
        }
        #endregion
        
        #region Public methods
        public void Reposition(int screenW, int screenH, int playerNo)
        {
            this.screenW = screenW;
            this.screenH = screenH;

            this.interval = screenW / numberOfPositions;
            this.speed = interval;

            if (playerNo == 1)
                this.x = screenW - 450;
            else
                this.x = speed;
            this.y = screenH - 150;

            Sprite.Location = new Point(x, y);
        }

        public void Reposition2(int screenW, int screenH, int playerNo)
        {
            this.screenW = screenW;
            this.screenH = screenH;

            this.interval = screenW / numberOfPositions;
            this.speed = interval;

            if (playerNo == 2)
                this.x = screenW - 450;
            else
                this.x = speed;
            this.y = screenH - 800;

            Sprite.Location = new Point(x, y);
        }

        public int playerCoordinateY
        {
            get { return y; }
            set { y = value; }
        }

        public void MoveLeft()
        {
            if (x <= speed) return;

            x -= speed;
            Sprite.Left -= speed;
        }

        public void MoveRight()
        {
            if (x >= this.screenW-150) return;

            x += speed;
            Sprite.Left += speed;
        }

        public Missle CreateMissle(Size size, int speed, int playerNo)
        {
            Missle missle = new Missle(size, speed, playerNo);
            missle.SetLocation(x + this.size.Width / 2, y);
            return missle;
        } 

        public Missle2 CreateMissle2(Size size, int speed, int playerNo)
        {
            Missle2 missle = new Missle2(size, speed, playerNo);
            missle.SetLocation(x + this.size.Width / 2, y);
            return missle;
        }
        #endregion

    }
}
