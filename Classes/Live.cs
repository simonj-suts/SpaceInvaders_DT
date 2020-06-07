using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public class Live : AnimatedObject
    {
        public int ScreenW { private get; set; }
        public int ScreenH { private get; set; }

        public Live(Size size, int speed, int width, int height) : base(size)
        {
            this.speed = speed;
            ScreenW = width;
            ScreenH = height;
        }

        public override void InitializeSprite()
        {
            Sprite = new PictureBox
            {
                Tag = "ammo",
                Size = size,
                BackColor = Color.Transparent,
                Image = Properties.Resources.live,
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
    }
}
