using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{

    internal class Board : BoardAbstract
    {
        public override int _boardWidth { get; }
        public override int _boardHeight { get; }
        private IList<Ball> _balls;

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

        public override void Generate_Ball(int x, int y, double radius)
        {
            _balls.Add(new Ball(x, y, radius));
        }
    }

    public abstract class BoardAbstract
    {
        public abstract int _boardWidth { get; }
        public abstract int _boardHeight { get; }
        public abstract void Generate_Ball(int x, int y, double radius);

        public static BoardAbstract Create(int boardWidth, int boardHeight)
        {
            return new Board(boardWidth, boardHeight);
        }
    }
}
