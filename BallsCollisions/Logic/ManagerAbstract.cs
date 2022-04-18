using System;
using Data;

namespace Logic
{
    public abstract class ManagerAbstract
    {
        public abstract BoardAbstract _board { get; }


        public static ManagerAbstract Create(int boardWidth, int boardHeight)
        {
            return new Manager(boardWidth, boardWidth);   
        }

        public abstract void AddBalls(int count);
    }

    internal class Manager : ManagerAbstract
    {
        public override BoardAbstract _board { get; }

        public Manager(int boardWidth, int boardHeight)
        {
            _board = BoardAbstract.Create(boardWidth, boardHeight);
        }

        public override void AddBalls(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                int _randX = random.Next(1, _board._boardWidth);
                int _randY = random.Next(1, _board._boardHeight);

                _board.Generate_Ball(_randX, _randY, 15);
            }
        }
    }
}
