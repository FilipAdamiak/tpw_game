using Data;
using NUnit.Framework;


namespace DataTest
{
    public class Tests
    {
        private DataAbstractAPI dataAbstract;
        private readonly int width = 750;
        private readonly int height = 400;

        [SetUp]
        public void Setup()
        {
            dataAbstract = DataAbstractAPI.CreateDataAPI();
        }

        [Test]
        public void BoardWidthHeightTest()
        {
            Assert.AreEqual(width, DataAbstractAPI._boardWidth);
            Assert.AreEqual(height, DataAbstractAPI._boardHeight);
        }

    }
}