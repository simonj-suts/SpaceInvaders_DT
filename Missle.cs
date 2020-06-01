using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public class Missle
    {
        #region Private fields
        Size size;
        int speed, x, y;
        int playerNo;
        #endregion

        #region Public fields
        public PictureBox Sprite { get; private set; }
        public int PlayerNo { get { return playerNo; } }
        #endregion

        #region Constructors and factory methods
        public Missle(Size size, int speed, int playerNo)
        {
            this.size = size;
            this.speed = speed;
            this.playerNo = playerNo;

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
        #endregion

        #region Public methods
        public void SetLocation(int x, int y)
        {
            this.x = x - size.Width / 2;
            this.y = y - size.Height / 2;
            Sprite.Location = new Point(this.x, this.y);
        }

        public void Move()
        {
            y -= speed;
            Sprite.Top -= speed;
        }

        public bool IsOutOfScreen()
        {
            return y < 0;
        }
        #endregion
    }
}
