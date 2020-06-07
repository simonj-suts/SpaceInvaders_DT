using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public class Ammo : AnimatedObject
    {
        #region Private fields
        //indicates the game mode (1-Single Player, 2- Co-op, 3- Multiplayer)
        public int ScreenW { private get; set; }
        public int ScreenH { private get; set; }
        int ammoNumber;
        #endregion

        #region Public fields
        public int AmmoNumber { get { return ammoNumber; } }

        #endregion

        #region Constructors and factory methods
        public Ammo(Size size, int speed, int width, int height) : base(size)
        {
            this.speed = speed;
            ScreenW = width;
            ScreenH = height;
        }
        #endregion

        #region Public methods
        public override void InitializeSprite()
        {
            Sprite = new PictureBox
            {
                Tag = "ammo",
                Size = size,
                BackColor = Color.Transparent,
                Image = Properties.Resources.ammo,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Sprite.BringToFront();
        }

        public void SetLocation(int x, int y)
        {
            this.x = x - size.Width / 2;
            this.y = y - size.Height / 2;
        }


        public bool IsOutOfScreen(int screenH)
        {
            return y > screenH;
        }

        public bool IsCollision(Rectangle rect)
        {
            return Sprite.Bounds.IntersectsWith(rect);
        }

        public int RandomizeX()
        {
            int interval = ScreenW / 10;
            return new Random().Next(1, 10) * interval + size.Width / 2;
        }

        public int RandomizeY()
        {
            int interval = ScreenH / 10;
            return new Random().Next(1, 10) * interval + size.Height / 2;
        }

        public void Move()
        {
            y += speed;
            Sprite.Top += (int)speed;
        }
        #endregion
    }
}
