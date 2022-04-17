using System;
using Data;

namespace Logic
{
    public class Manager
    {
        private Board _board;

        public Board Board
        {
            get { return _board; }
        }

        public Manager(int boardWidth, int boardHeight)
        {
            _board = new Board(boardWidth, boardHeight);   
        }

        public void AddBalls(int count)
        {
            Random random = new Random();
            for(int i = 0; i < count; i++)
            {
                int _randX = random.Next(1, _board.BoardWidth);
                int _randY = random.Next(1, _board.BoardHeight);

                _board.Generate_Ball(_randX, _randY, 15);
            }
        }
    }
}
