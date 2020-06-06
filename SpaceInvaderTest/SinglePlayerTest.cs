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
            playerArea = new Rectangle((int)p1.X, (int)p1.Y, 75, 75);

            Asteroid ars = new Asteroid(asteroidSize, asteroidSpeed);
            ars.SetLocation((numberOfPositions - 1) * (1920 / numberOfPositions) + asteroidSize.Width / 2, p1.Y);
            asteroidArea = new Rectangle((int)ars.X, (int)ars.Y, 75, 75);

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
            asteroidArea = new Rectangle((int)ars.X, (int)ars.Y, 75, 75);

            Weapon miss = p1.CreateWeapon(missleSpeed, 1);
            missleArea = new Rectangle((int)miss.X, (int)miss.Y, 75, 75);

            bool hit = false;
            Assert.AreEqual(false, hit);
            Assert.AreEqual(0, p1.Score);

            if (missleArea.IntersectsWith(asteroidArea))
            {
                hit = true;
               
            }
               

           Assert.AreEqual(true, hit);
          
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

            int initialPositionY = (int)p1.Y;
            int initialPositionX = (int)p1.X;

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
            missleArea = new Rectangle((int)miss.X, (int)miss.Y, 75, screenH);

            Asteroid ars1 = new Asteroid(asteroidSize, asteroidSpeed);
            ars1.SetLocation((numberOfPositions - 1) * (screenW / numberOfPositions) + asteroidSize.Width / 2, p1.Y);
            Rectangle asteroidArea1 = new Rectangle((int)ars1.X, (int)ars1.Y, 75, 75);

            Asteroid ars2 = new Asteroid(asteroidSize, asteroidSpeed);
            ars2.SetLocation((numberOfPositions - 1) * (screenW / numberOfPositions) + asteroidSize.Width / 2, 100);
            Rectangle asteroidArea2 = new Rectangle((int)ars2.X, (int)ars2.Y, 75, 75);

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

        [TestMethod]
        public void TestScoreEarned() {
            Size playerSize = new Size(75, 75);


            Size asteroidSize1 = new Size(75, 75);
            Rectangle asteroidArea1;

            Size asteroidSize2 = new Size(90, 90);
            Rectangle asteroidArea2;

            Size asteroidSize3 = new Size(110, 110);
            Rectangle asteroidArea3;

            Size missleSize = new Size(75, 75);
            Rectangle missleArea;
            Rectangle missleArea2;  
            Rectangle missleArea3;

            int asteroidSpeed = 40;
            int numberOfPositions = 10;
            int numberOfLives = 3;
            string username1 = "Johanna";

            int missleSpeed = 40;


            Player p1 = new Player(playerSize, numberOfPositions, numberOfLives, username1);
            p1.Reposition(1920, 1080, 1);

            Asteroid ars = new Asteroid(asteroidSize1, asteroidSpeed);
            ars.SetLocation((numberOfPositions - 1) * (1920 / numberOfPositions) + asteroidSize1.Width / 2, p1.Y);
            asteroidArea1 = new Rectangle((int)ars.X, (int)ars.Y, 75, 75);

            Asteroid ars2 = new Asteroid(asteroidSize2, asteroidSpeed);
            ars2.SetLocation((numberOfPositions - 1) * (1920 / numberOfPositions) + asteroidSize2.Width / 2, p1.Y);
            asteroidArea2 = new Rectangle((int)ars2.X, (int)ars2.Y, 75, 75);

            Asteroid ars3 = new Asteroid(asteroidSize3, asteroidSpeed);
            ars3.SetLocation((numberOfPositions - 1) * (1920 / numberOfPositions) + asteroidSize3.Width / 2, p1.Y);
            asteroidArea3 = new Rectangle((int)ars3.X, (int)ars3.Y, 75, 75);

            Weapon miss = p1.CreateWeapon(missleSpeed, 1);
            missleArea = new Rectangle((int)miss.X, (int)miss.Y, 75, 75);

            missleArea2 = new Rectangle((int)ars2.X, (int)ars2.Y, 75, 75);

            missleArea3 = new Rectangle((int)ars3.X, (int)ars3.Y, 75, 75);



            bool hit = false;
            Assert.AreEqual(false, hit);
            Assert.AreEqual(0, p1.Score);

            if (missleArea.IntersectsWith(asteroidArea1))
            {
        
                p1.Score+= ars.healthBar;
            }
            Assert.AreEqual(1, p1.Score);
            if (missleArea2.IntersectsWith(asteroidArea2))
            {

                p1.Score += ars2.healthBar;
            }
            Assert.AreEqual(3, p1.Score);
            if (missleArea3.IntersectsWith(asteroidArea3))
            {

                p1.Score += ars3.healthBar;
            }
            Assert.AreEqual(6, p1.Score);

            

        }
    }
}
