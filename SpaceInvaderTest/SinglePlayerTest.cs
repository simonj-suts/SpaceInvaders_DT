using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvaders;
using SpaceInvaders.Classes;
using System;
using System.Collections.Generic;
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

            Weapon miss = p1.CreateWeapon(missleSpeed, 1);
            missleArea = new Rectangle(miss.X, miss.Y, 75, 75);

            bool hit = false;
            Assert.AreEqual(false, hit);
            Assert.AreEqual(0, p1.Score);

            if (missleArea.IntersectsWith(asteroidArea))
            {
                hit = true;
                p1.Score++;
            }
               

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

        [TestMethod]
        public void LaserTest()
        {
            const int screenW = 1920;
            const int screenH = 1080;
            Size playerSize = new Size(75, 75);

            Size asteroidSize = new Size(75, 75);

            Size missleSize = new Size(75, 75);
            Rectangle missleArea;

            int asteroidSpeed = 40;
            int numberOfPositions = 10;
            int numberOfLives = 3;
            string username1 = "Johanna";
            int missleSpeed = 40;

            List<Rectangle> asteroids = new List<Rectangle>();
            List<Asteroid> ars = new List<Asteroid>();

            Player p1 = new Player(playerSize, numberOfPositions, numberOfLives, username1);
            p1.Reposition(screenW, screenH, 1);

            p1.weaponType = WeaponType.laser;

            Weapon miss = p1.CreateWeapon(missleSpeed, 1);
            missleArea = new Rectangle(miss.X, miss.Y, 75, screenH);

            Asteroid ars1 = new Asteroid(asteroidSize, asteroidSpeed);
            ars1.SetLocation((numberOfPositions - 1) * (screenW / numberOfPositions) + asteroidSize.Width / 2, p1.Y);
            Rectangle asteroidArea1 = new Rectangle(ars1.X, ars1.Y, 75, 75);

            Asteroid ars2 = new Asteroid(asteroidSize, asteroidSpeed);
            ars2.SetLocation((numberOfPositions - 1) * (screenW / numberOfPositions) + asteroidSize.Width / 2, 100);
            Rectangle asteroidArea2 = new Rectangle(ars2.X, ars2.Y, 75, 75);

            asteroids.Add(asteroidArea1);
            asteroids.Add(asteroidArea2);
            ars.Add(ars1);
            ars.Add(ars2);

            for (int j = 0; j < asteroids.Count; j++)
            {
                if (asteroids[j].IntersectsWith(missleArea))
                {
                    ars[j].Hit = true;
                }
            }

            int count = 0;

            for (int j = 0; j < asteroids.Count; j++)
            {
                if (ars[j].Hit)
                {
                    count++;
                }
            }

            Assert.AreEqual(2,count);
        }
    }
}
