using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders.Classes
{
    public class Missile : Weapon
    {

        #region constructors
        public Missile(Size size, int speed, int playerNo) : base(size, speed, playerNo){}
        #endregion

        #region methods
        public override void InitializeSprite()
        {
            Sprite = new PictureBox
            {
                Tag = "missile",
                Size = size,
                BackColor = Color.Transparent,
                Image = Properties.Resources.missle, // default weapon
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Sprite.BringToFront();
        }

        public override void SetLocation(int x, int y)
        {
            base.SetLocation(x, y);
            if (playerNo == 3)
                this.y = y + 20;
        }
        #endregion
    }
}
