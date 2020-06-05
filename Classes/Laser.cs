using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders.Classes
{
    public class Laser : Weapon
    {
        #region constructors
        public Laser(Size size, int speed, int playerNo) : base(size, speed, playerNo) { }
        #endregion

        #region methods
        public override void InitializeSprite()
        {
            Sprite = new PictureBox
            {
                Tag = "laser",
                Size = size,
                BackColor = Color.Transparent,
                Image = Properties.Resources.laser, // default weapon
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Sprite.BringToFront();
        }

        public override void SetLocation(int x, int y)
        {
            this.x = x - size.Width / 2;
            if (playerNo == 3)
                this.y = y - size.Height + 5;
            else
                this.y = y - size.Height;
        }

        public override void Move()
        {
            if (playerNo == 3)
            {
                y += 2;
                Sprite.Top += 2;
            }
            else
            {
                y -= 2;
                Sprite.Top -= 2;
            }
        }

        public override bool IsOutOfScreen(int height)
        {
            if (playerNo == 3)
                return y + Sprite.Size.Height > height;
            else
                return y < 0;
        }

        #endregion
    }
}
