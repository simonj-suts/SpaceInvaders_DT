using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class Asteroid
    {
        #region Private fields
        Size size;              // size
        int speed, x, y;        // speed and position
        #endregion

        #region Private fields
        public PictureBox Sprite { get; private set; }
        #endregion

        #region Constructors and factory methods
        public Asteroid(Size size, int speed)
        {
            this.size = size;
            this.speed = speed;

            Sprite = new PictureBox
            {
                Size = size,
                BackColor = Color.Transparent,
                Image = Properties.Resources.asteroid,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Sprite.BringToFront();
        }
        #endregion
        
        #region Public methods
        public void SetLocation(int x, int y)
        {
            this.x = x - size.Width / 2;
            this.y = y - size.Width / 2;
            Sprite.Location = new Point(this.x, this.y);
        }

        public void Move()
        {
            y += speed;
            Sprite.Top += speed;
        }

        public bool IsOutOfScreen(int screenH)
        {
            return y > screenH;
        }

        public bool IsCollision(Rectangle rect)
        {
            return Sprite.Bounds.IntersectsWith(rect);
        } 
        #endregion
    }
}
