using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public class Asteroid : AnimatedObject
    {
        #region public fields
        public bool Hit { get; set; }
        public int healthBar;
        public int astScore;
        #endregion

        #region Constructors and factory methods
        public Asteroid(Size size, int speed)
        {
            this.size = size;
            this.speed = speed;
            Hit = false;
            healthBar = SetHealthBar();
            astScore = healthBar;
        }
        #endregion

        #region Public methods
        public override void InitializeSprite()
        {
            if (size.Height > 100)
            {
                Sprite = new PictureBox
                {
                    Size = size,
                    BackColor = Color.Transparent,
                    Image = Properties.Resources.asteroid3,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

            }
            else if (size.Height > 80 && size.Height <= 100)
            {
                Sprite = new PictureBox
                {
                    Size = size,
                    BackColor = Color.Transparent,
                    Image = Properties.Resources.asteroid2,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
            }
            else
            {
                Sprite = new PictureBox
                {
                    Size = size,
                    BackColor = Color.Transparent,
                    Image = Properties.Resources.asteroid,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
            }
            Sprite.BringToFront();
        }

        public int SetHealthBar()
        {
            if (size.Height > 100)
            {
                healthBar = 3;

            }
            else if (size.Height > 80 && size.Height <= 100)
            {
                healthBar = 2;
            }
            else
            {
                healthBar = 1;
            }
            return healthBar;

        }

        public void SetLocation(double x, double y)
        {
            this.x = x - size.Width / 2;
            this.y = y - size.Width / 2;
        }

        public void Move()
        {
            y += speed;
            Sprite.Top += (int)speed;
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
