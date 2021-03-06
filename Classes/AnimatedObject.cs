﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceInvaders
{
    public abstract class AnimatedObject
    {
        #region Protected fields
        protected Size size;
        protected double speed, x, y;
        #endregion

        #region Public fields
        public PictureBox Sprite { get; protected set; }
        public double X { get { return x; } }
        public double Y { get { return y; } }
        #endregion

        #region Constructors
        public AnimatedObject() { }
        public AnimatedObject(Size size)
        {
            this.size = size;
        }
        #endregion

        #region methods
        public abstract void InitializeSprite();
        
        public void PositionSprite()
        {
            Sprite.Location = new Point((int)x, (int)y);
        }
        #endregion
    }
}
