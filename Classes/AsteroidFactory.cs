using System;
using System.Drawing;
using System.Collections.Generic;

namespace SpaceInvaders
{
    class AsteroidFactory
    {
        #region Private fields
        static int randomNum;
        Size size;
        int speed;
        int numberOfPositions;
        List<int> randNum = new List<int> { 120, 75, 90 };
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
            if (randomNum >= 3 || String.IsNullOrEmpty(randomNum.ToString()))
            {
                randomNum = 0;
            }

            //randomize types of asteroids
            int astPos = randNum[randomNum];
            Asteroid asteroid = new Asteroid(new Size(astPos, astPos), speed);

            asteroid.InitializeSprite();
            asteroid.SetLocation(RandomizeX(), -100);
            asteroid.PositionSprite();
            randomNum++;
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
