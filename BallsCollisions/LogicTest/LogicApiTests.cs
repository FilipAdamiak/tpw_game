using Logic;
using System.Numerics;
using NUnit.Framework;

namespace LogicTest
{
    public class BallTests
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

    public class LogicApiTests
    {
        readonly LogicApi logicApi = LogicApi.CreateApi();
        static int _width = 750;
        static int _height = 400;

        [Test]
        public void LogicApiConstructorTest()
        {
            Assert.AreEqual(_width, logicApi.Width);
            Assert.AreEqual(_height, logicApi.Height);
            Assert.AreEqual(logicApi.Balls.Count, 0);
        }

        [Test]
        public void CreateBallsTest()
        {
            int _amount = 5;
            int _radius = 10;
            logicApi.CreateBalls(_amount, _radius);

            Assert.AreEqual(_amount, logicApi.Balls.Count);

            foreach (Ball ball in logicApi.Balls)
            {
                Assert.IsTrue(ball.Position.X - _radius >= 0);
                Assert.IsTrue(ball.Position.X + _radius <= _width);
                Assert.IsTrue(ball.Position.Y - _radius >= 0);
                Assert.IsTrue(ball.Position.Y + _radius <= _height);
            }

        }

        [Test]
        public void DeleteBallsTest()
        {
            logicApi.DeleteBalls();
            Assert.AreEqual(0, logicApi.Balls.Count);
        }

    }
}
