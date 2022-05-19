using Logic;
using System.Numerics;
using NUnit.Framework;
using Data;

namespace LogicTest
{
    public class BallTests
    {
        private LogicAbstractAPI _logicApi;
        private DataSimulation _simulation;
        [SetUp]
        public void SetUp()
        {
            _simulation = new DataSimulation();
            _logicApi = LogicAbstractAPI.CreateApi(new DataSimulation());
        }

        [Test]
        public void BallContructorTest()
        {
            int r = 5;
            Vector2 v1 = new Vector2(1, 2);
            Vector2 v2 = new Vector2(2, 1);
            BallEntity ball = new BallSimulation(0, v1, v2, DataAbstractAPI.CreateDataAPI());

            Assert.AreEqual(r, ball.Radius);
            Assert.AreEqual(v1, ball.Position);
            Assert.AreEqual(v2, ball.Velocity);
        }
        
        [Test]
        public void AddBallsTest()
        {
            _simulation.AddBalls(2);
            Assert.AreEqual(2, _simulation._balls.Count);
        }
       
        [Test]
        public void RunStopSimulationTest()
        {
            _simulation.RunSimulation();
            Assert.AreEqual(true, _simulation.IsSimulating);
            _simulation.StopSimulation();
            Assert.AreEqual(false, _simulation.IsSimulating);
        }

        [Test]
        public void BallRadiusTest()
        {
            _simulation._balls.Add(new BallSimulation(1, new Vector2(50, 50),  new Vector2(0, 1), _simulation));
            _simulation._balls.Add(new BallSimulation(2, new Vector2(50, 75),  new Vector2(0, -1), _simulation));
            _logicApi.ChangedPosition += (_, args) =>
            {
                Assert.AreNotEqual(Vector2.One, _simulation._balls[0].Velocity);
            };
            _logicApi.RunSimulation();
        }

        [Test]
        public void BallCollisionsTest()
        {
            _simulation._balls.Add(new BallSimulation(1, new Vector2(50, 50), new Vector2(0, 1), _simulation));
            _simulation._balls.Add(new BallSimulation(2, new Vector2(50, 60),  new Vector2(0, -1), _simulation));
            _logicApi.ChangedPosition += (_, args) =>
            {
                Assert.AreNotEqual(Vector2.One, _simulation._balls[0].Velocity);
            };
            _logicApi.RunSimulation();
           
        }


    }
}
