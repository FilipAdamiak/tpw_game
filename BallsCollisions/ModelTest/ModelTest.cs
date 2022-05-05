using NUnit.Framework;
using Model;

namespace ModelTest
{
    public class ModelTest
    {
        private ModelAbstractAPI model;
        [SetUp]
        public void SetUp()
        {
            model = ModelAbstractAPI.CreateModelAPI(new LogicSimulation());
        }
        [Test]
        public void CreateAndStopSimulationTest()
        {
            model.CreateBalls(10, 10);
            Assert.AreEqual(10, model.GetBallAmount());
            model.StopSimulation();
            Assert.AreEqual(0, model.GetBallAmount());
        }
        [Test]
        public void CheckBoardSize()
        {
            Assert.AreEqual(400, model.Height);
            Assert.AreEqual(750, model.Width);
        }

    }
}
