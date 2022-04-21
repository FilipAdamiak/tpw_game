using NUnit.Framework;
using Logic;
using System.Numerics;

namespace LogicTest
{
    public class Tests
    {

        [Test]
        public void BallContructorTest()
        {
            Vector2 v = new Vector2(1, 2);
            int radius = 5;
            Ball ball = new Ball(v, radius);

            Assert.AreEqual(radius, ball.Radius);
            Assert.AreEqual(v, ball.Position);

        }

        [Test]
        public void PositionChangedTest()
        {
            Ball ball = new Ball();
            ball.Velocity = new Vector2(1, 2);
            ball.Position = new Vector2(Board._boardWidth, Board._boardHeight);
            ball.ChangePosition();
            Assert.AreNotEqual(Board._boardWidth, ball.Velocity.X);
            Assert.AreNotEqual(Board._boardHeight, ball.Velocity.Y);
        }

        [Test]
        public void BallVelocityTest()
        {
            Ball ball = new Ball();
            ball.Velocity = new Vector2(1, 2);
            Assert.AreEqual(1, ball.Velocity.X);
            Assert.AreEqual(2, ball.Velocity.Y);
        }
    }
}