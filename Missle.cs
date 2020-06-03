using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public class Missle : AnimatedObject
    {
        #region Private fields
        int playerNo;
        #endregion

        #region Public fields
        public int PlayerNo { get { return playerNo; } }

        #endregion

        #region Constructors and factory methods
        public Missle(Size size, int speed, int playerNo) : base(size)
        {
            this.speed = speed;
            this.playerNo = playerNo;
        }
        #endregion

        #region Public methods
        public override void InitializeSprite()
        {
            Sprite = new PictureBox
            {
                Tag = "missle",
                Size = size,
                BackColor = Color.Transparent,
                Image = Properties.Resources.missle,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Sprite.BringToFront();
        }

        public void SetLocation(int x, int y)
        {
            this.x = x - size.Width / 2;
            this.y = y - size.Height / 2;
        }

        public void Move()
        {
            if (playerNo == 3)
            {
                y += speed;
                Sprite.Top += speed;
            }
            else
            {
                y -= speed;
                Sprite.Top -= speed;
            }
        }

        public bool IsOutOfScreen(int width)
        {
            if (playerNo == 3)
                return y > width;
            else
                return y < 0;
        }
        #endregion
    }
}
