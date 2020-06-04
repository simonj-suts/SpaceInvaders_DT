using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvaders;
using System;
using System.Drawing;

namespace SpaceInvaderTest
{
    [TestClass]
    public class SinglePlayerTest
    {
        [TestMethod]
        public void PlayerLifeTest()
        {
            Size playerSize = new Size(75, 75);
            Rectangle playerArea;

            Size asteroidSize = new Size(75, 75);
            Rectangle asteroidArea;

            int asteroidSpeed = 40;
            int numberOfPositions = 10;
            int numberOfLives = 3;
            string username1 = "Johanna";

            Player p1 = new Player(playerSize, numberOfPositions, numberOfLives, username1);
            p1.Reposition(1920, 1080, 1);
            playerArea = new Rectangle(p1.X, p1.Y, 75, 75);

            Asteroid ars = new Asteroid(asteroidSize, asteroidSpeed);
            ars.SetLocation((numberOfPositions - 1) * (1920 / numberOfPositions) + asteroidSize.Width / 2, p1.Y);
            asteroidArea = new Rectangle(ars.X, ars.Y, 75, 75);

            Assert.AreEqual(3, p1.Lives);

            if (asteroidArea.IntersectsWith(playerArea))
                p1.Lives--;

            Assert.AreEqual(2, p1.Lives);
        }

        [TestMethod]
        public void MissileHitsAsteroidTest()
        {
            Size playerSize = new Size(75, 75);
            

            Size asteroidSize = new Size(75, 75);
            Rectangle asteroidArea;

            Size missleSize = new Size(75, 75);
            Rectangle missleArea;

            int asteroidSpeed = 40;
            int numberOfPositions = 10;
            int numberOfLives = 3;
            string username1 = "Johanna";

            int missleSpeed = 40;


            Player p1 = new Player(playerSize, numberOfPositions, numberOfLives, username1);
            p1.Reposition(1920, 1080, 1);

            Asteroid ars = new Asteroid(asteroidSize, asteroidSpeed);
            ars.SetLocation((numberOfPositions - 1) * (1920 / numberOfPositions) + asteroidSize.Width / 2, p1.Y);
            asteroidArea = new Rectangle(ars.X, ars.Y, 75, 75);

            Missle miss = p1.CreateMissle(missleSize, missleSpeed, 1);
            missleArea = new Rectangle(miss.X, miss.Y, 75, 75);

            bool hit = false;
            Assert.AreEqual(false, hit);
            Assert.AreEqual(0, p1.Score);

            if (missleArea.IntersectsWith(asteroidArea))
                hit = true;
                p1.Score++;

           Assert.AreEqual(true, hit);
           Assert.AreEqual(1, p1.Score);
        }

        [TestMethod]
        public void TestMovement()
        {
            Size playerSize = new Size(75, 75);
            int numberOfPositions = 10;
            int numberOfLives = 3;
            string username1 = "Johanna";


            Player p1 = new Player(playerSize, numberOfPositions, numberOfLives, username1);
            p1.Reposition(1920, 1080, 1);

            int initialPositionY = p1.Y;
            int initialPositionX = p1.X;

            Assert.AreEqual(initialPositionY, p1.Y);
            Assert.AreEqual(initialPositionX, p1.X);

            p1.MoveUp();
            Assert.AreEqual(initialPositionY - (1080/numberOfPositions), p1.Y);

            p1.MoveDown();
            Assert.AreEqual(initialPositionY, p1.Y);

            p1.MoveLeft();
            Assert.AreEqual(initialPositionX - (1920 / numberOfPositions), p1.X);

            p1.MoveRight();
            Assert.AreEqual(initialPositionX, p1.X);
        }
    }
}
