using NUnit.Framework;
using Model;

namespace ModelTest
{
    public class ModelTest
    {
        private ModelAPILayer model;
        [SetUp]
        public void SetUp()
        {
            model = new ModelAPILayer();
        }
        [Test]
        public void CreateAndStopSimulationTest()
        {
            model.CallSimulation();
            Assert.AreEqual(true, model.);
            model.StopSimulation();
            Assert.AreEqual(0, model.GetBallAmount());
        }
        [Test]
        public void CheckBoardSize()
        {
            Assert.AreEqual(400, model.GetWidth());
            Assert.AreEqual(750, model.GetHeight());
        }

    }
}
