using System.Collections.ObjectModel;
using System;
using Logic;
using System.Collections.Generic;

namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public static ModelAbstractAPI CreateModelAPI()
        {
            return new ModelAPILayer();
        }

        public abstract int Width { get; }
        public abstract int Height { get; }
        public abstract List<Ball> Balls(int balls);
        public abstract void RunBalls();

    }
    public class ModelAPILayer : ModelAbstractAPI
    {
        private Board board = new Board(750, 400 ,10);
        public override int Width => Board._boardWidth;
        public override int Height => Board._boardHeight;

        public override void RunBalls()
        {
            
        }

        public override List<Ball> Balls(int amount)
        {
            board.CreateBalls(amount);
            return board._balls;
        }

        public static void Main()
        {
            Logic.LogicAbstractAPI logicAbstractAPI = Logic.LogicAbstractAPI.CreateLogicAPI(Data.DataAbstractAPI.CreateDataAPI());
            Logic.Board board = logicAbstractAPI.CreateBoard(532, 400, 10);

            for (int i = 0; i < board._balls.Count; i++)
            {
                System.Console.WriteLine("Ball " + i.ToString());
                System.Console.WriteLine(board._balls[i].X);
                System.Console.WriteLine(board._balls[i].Y);
                System.Console.WriteLine(board._balls[i].Radius);
            }
        } 
    }

}
