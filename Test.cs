using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnit.Framework;

namespace SpaceInvaders
{
    [TestFixture()]
    public class Test : Form
    {
        [Test()]
        public void TestPlayerCollision()
        {
            int numberOfPositions = 10;
            int numberOfLives = 3;
            Size playerSize = new Size(75, 75);
            Size missleSize = new Size(15, 45);
            int missleSpeed = 50;

            List<Missle> missles = new List<Missle>();
            List<Missle2> missles2 = new List<Missle2>();

            Player player1 = new Player(playerSize, numberOfPositions, numberOfLives, Properties.Resources.player1); // create player 1
            Player player2 = new Player(playerSize, numberOfPositions, numberOfLives, Properties.Resources.player2); // create player 2

            Controls.Add(player1.Sprite);
            Controls.Add(player2.Sprite);

            Missle missle = player1.CreateMissle(missleSize, missleSpeed, 1);
            missles.Add(missle);
            Controls.Add(missle.Sprite);

            Missle2 missle2 = player2.CreateMissle2(missleSize, missleSpeed, 1);
            missles2.Add(missle2);
            Controls.Add(missle.Sprite);

            bool missleHit = false;
            for (int i = missles.Count - 1; i >= 0; i--)
            {
                if (missles[i].Sprite.Bounds.IntersectsWith(player2.Sprite.Bounds))
                {
                    missleHit = true;
                }
            }
            Assert.AreEqual(true, missleHit);

            bool missleHit2 = false;
            for (int i = missles2.Count - 1; i >= 0; i--)
            {
                if (missles2[i].Sprite.Bounds.IntersectsWith(player1.Sprite.Bounds))
                {
                    missleHit2 = true;
                }
            }
            Assert.AreEqual(true, missleHit2);
        }
    }
}
