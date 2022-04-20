using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI CreateLogicAPI(DataAbstractAPI dataAbstractAPI)
        {
            return new LogicAPILayer(dataAbstractAPI);
        }
        public abstract void RunSimulation(Board board);
        public abstract Ball CreateBall(int x, int y, int radius);
        public abstract Board CreateBoard(int width, int height, int balls_amount);
    }

    public class LogicAPILayer : LogicAbstractAPI
    {
        public override void RunSimulation(Board board)
        {

        }
        public LogicAPILayer(DataAbstractAPI dataAbstractAPI)
        {
            DataAbstractAPI dataLayer = dataAbstractAPI;
        }
        public override Ball CreateBall(int x, int y, int radius)
        {
            return new Ball(x, y, radius);
        }
        public override Board CreateBoard(int width, int height, int balls_amount)
        {
            return new Board(width, height, balls_amount);
        }
       
    }
    
}
