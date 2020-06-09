using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvaders;
using System.Drawing;
using System.Collections.Generic;

namespace SpaceInvaderTest
{
    [TestClass]
    public class VersusTest
    {
        [TestMethod]
        public void TestPlayerCollision()
        {
            int numberOfPositions = 10;
            int numberOfLives = 3;
            Size playerSize = new Size(75, 75);
            Size missleSize = new Size(15, 45);
            int missleSpeed = 50;

            Player player1 = new Player(playerSize, numberOfPositions, numberOfLives, 1); // create player 1
            Rectangle playerArea = new Rectangle((int)player1.X, (int)player1.Y, 75, 75);

            Player player2 = new Player(playerSize, numberOfPositions, numberOfLives, 3); // create player 2
            Rectangle playerArea2 = new Rectangle((int)player2.X, (int)player2.Y, 75, 75);

            Weapon missle = player1.CreateWeapon(missleSpeed, 1);
            Rectangle missle1Area = new Rectangle((int)missle.X, (int)missle.Y, 75, 75);

            Weapon missle2 = player2.CreateWeapon(missleSpeed, 3);
            Rectangle missle2Area = new Rectangle((int)missle2.X, (int)missle2.Y, 75, 75);

            bool missleHit = false;
            if (missle1Area.IntersectsWith(playerArea))
            {
                missleHit = true;
            }

            Assert.AreEqual(true, missleHit);

            bool missleHit2 = false;
            if (missle2Area.IntersectsWith(playerArea2))
            {
                missleHit2 = true;
            }

            Assert.AreEqual(true, missleHit2);
        }
    }
}
