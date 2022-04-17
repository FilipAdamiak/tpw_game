using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Board
    {
        private int _boardWidth;
        private int _boardHeight;
        private IList<Ball> _balls;

        public int BoardWidth
        {
            get { return _boardWidth; }
        }

        public int BoardHeight
        {
            get { return _boardHeight; }
        }

        public IList<Ball> Balls
        {
            get { return _balls; }
        }

        public Board(int boardWidth, int boardHeight)
        {
            _boardWidth = boardWidth;
            _boardHeight = boardHeight;
            _balls = new List<Ball>();
        }

        public void Generate_Ball(int x, int y, double radius)
        {
            _balls.Add(new Ball(x, y, radius));
        }
    }
}
