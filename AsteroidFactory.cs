using System;
using System.Drawing;

namespace SpaceInvaders
{
    class AsteroidFactory
    {
        #region Private fields
        Size size;
        int speed;
        int numberOfPositions;
        #endregion

        #region Public fields
        public int ScreenW { private get; set; }
        #endregion

        #region Constructors and factory methods
        public AsteroidFactory(Size size, int speed, int numberOfPositions)
        {
            this.size = size;
            this.speed = speed;
            this.numberOfPositions = numberOfPositions;
        }

        public Asteroid CreateAsteroid()
        {
            Asteroid asteroid = new Asteroid(size, speed);
            asteroid.SetLocation(RandomizeX(), -100);
            return asteroid;
        }
        #endregion

        #region Helper methods
        // returns a randomized position on x
        // spanning across one of the possible positions
        // based on screen width and asteroid width
        int RandomizeX()
        {
            int interval = ScreenW / numberOfPositions;
            return new Random().Next(1, numberOfPositions) * interval + size.Width / 2;
        }
        #endregion
    }
}
