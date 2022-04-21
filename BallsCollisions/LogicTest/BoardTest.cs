using NUnit.Framework;
using Logic;
using System.Numerics;

namespace LogicTest
{
    public class BoardTest
    {
        [Test]
        public void BoardConstructorTest()
        {
            Board board = new Board();
            Assert.AreEqual(750, board.BoardWidth);
            Assert.AreEqual(400, board.BallsHeight);
        }
        
        [Test]
        public void CorrectBallsAmountTest()
        {
            Board board = new Board(10);
            Assert.AreEqual(10, board.Balls.Count);
        }

        [Test]
        public void IncorrectBallsAmountTest()
        {
            Board board = new Board(-5);
            Assert.AreEqual(5, board.Balls.Count);
            
        }
    }

}
