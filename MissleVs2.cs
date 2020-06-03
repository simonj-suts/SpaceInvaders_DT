using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public class MissleVs2
    {
        #region Private fields
        Size size;
        int speed, x, y;
        int playerNo;
        #endregion

        #region Public fields
        public PictureBox Sprite { get; private set; }
        #endregion

        #region Constructors and factory methods
        public MissleVs2(Size size, int speed)
        {
            this.size = size;
            this.speed = speed;


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
            y += speed;
            Sprite.Top += speed;
        }


        public bool IsOutOfScreen(Player player)
        {
            return y > player.Y;
        }


        #endregion
    }

}
