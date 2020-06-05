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

            List<Weapon> missles = new List<Weapon>();
            List<Weapon> missles2 = new List<Weapon>();

            Player player1 = new Player(playerSize, numberOfPositions, numberOfLives, 1); // create player 1
            player1.Reposition(1920, 1080, 1);
            Rectangle playerArea = new Rectangle(player1.X, player1.Y, 75, 75);

            Player player2 = new Player(playerSize, numberOfPositions, numberOfLives, 3); // create player 2
            player2.Reposition(1920, 1080, 3);
            Rectangle playerArea2 = new Rectangle(player2.X, player2.Y, 75, 75);

            Weapon missle = player1.CreateWeapon(missleSpeed, 1);
            Rectangle missle1Area = new Rectangle(missle.X, missle.Y, 75, 75);
            missles.Add(missle);

            Weapon missle2 = player2.CreateWeapon(missleSpeed, 3);
            Rectangle missle2Area = new Rectangle(missle2.X, missle2.Y, 75, 75);
            missles2.Add(missle2);

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
