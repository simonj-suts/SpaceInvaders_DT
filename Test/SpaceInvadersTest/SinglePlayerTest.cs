using NUnit.Framework;
using SpaceInvaders;
using System.Drawing;
using System.Collections.Generic;
using System.Security.Cryptography;
using System;

namespace SpaceInvadersTest
{
    public class Tests
    {
        [Test]
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
            playerArea = new Rectangle(p1.x,p1.y,75,75);

            Asteroid ars = new Asteroid(asteroidSize, asteroidSpeed);
            ars.SetLocation((numberOfPositions-1) * (1920 / numberOfPositions) + asteroidSize.Width / 2, p1.y);
            asteroidArea = new Rectangle(ars.x, ars.y, 75, 75);

            if (asteroidArea.IntersectsWith(playerArea))
                p1.Lives--;

            Assert.AreEqual(2,p1.Lives);
        }
        //[Test]
        //public void Test1()
        //{
        //    Size playerSize = new Size(75, 75);
        //    Size asteroidSize = new Size(75, 75);
        //    Size missleSize = new Size(15, 45);
        //    int asteroidSpeed = 40;
        //    int missleSpeed = 50;
        //    int numberOfPositions = 10;
        //    int numberOfLives = 3;
        //    string username1 = "Johey";

        //    Player p1 = new Player(playerSize, numberOfPositions, numberOfLives, username1);
        //    p1.Reposition(1920, 1080, 1);

        //    List<Missle> missle1 = new List<Missle>();
        //    missle1.Add(p1.CreateMissle(missleSize, missleSpeed, 1));
        //    // missleX = 1800
        //    // missleY = 908

        //    Asteroid ars = new Asteroid(asteroidSize, asteroidSpeed);
        //    ars.SetLocation(numberOfPositions*(1920/numberOfPositions)+asteroidSize.Width/2, 1080);
        //    // asteroidX = 1883;
        //    // asteroidY = 1043;
        //    //bool hit = false;
        //    //if ()
        //    //{
        //    //    hit = true;
        //    //}

        //    Assert.AreEqual(0, ars.y);
        //}
    }
}