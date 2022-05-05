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
        public void StopSimulationTest()
        {
            model.CallSimulation();
            model.StopSimulation();
            Assert.AreEqual(0, model.CreateBalls(10, 10).Count);
        }
        [Test]
        public void CheckBoardSize()
        {
            Assert.AreEqual(400, model.Height);
            Assert.AreEqual(750, model.Width);
        }

    }
}
