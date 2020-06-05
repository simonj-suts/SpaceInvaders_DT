using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public abstract class Weapon : AnimatedObject
    {
        #region Private fields
        //indicates the game mode (1-Single Player, 2- Co-op, 3- Multiplayer)
        protected int playerNo;
        #endregion

        #region Public fields
        public int PlayerNo { get { return playerNo; } }
        public bool Hit { get; set; }
        #endregion

        #region Constructors and factory methods
        public Weapon(Size size, int speed, int playerNo) : base(size)
        {
            this.speed = speed;
            this.playerNo = playerNo;
            Hit = false;
        }
        #endregion

        #region Public methods
        public override void InitializeSprite()
        {
            Sprite = new PictureBox
            {
                Size = size,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Sprite.BringToFront();
        }

        public virtual void SetLocation(int x, int y)
        {
            this.x = x - size.Width / 2;
            this.y = y - size.Height / 2;
        }

        public virtual void Move()
        {
            if (playerNo == 3)
            {
                y += speed;
                Sprite.Top += speed;
            }
            else
            {
                y -= speed;
                Sprite.Top -=speed;
            }
        }

        public virtual bool IsOutOfScreen(int height)
        {
            if (playerNo == 3)
                return y > height;
            else
                return y < 0;
        }
        #endregion
    }
}
