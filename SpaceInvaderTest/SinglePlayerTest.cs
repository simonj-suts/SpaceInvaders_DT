using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvaders;
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
    }
}
