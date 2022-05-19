using System;

namespace Logic
{
    public class LogicEventArgs : EventArgs
    {
        public LogicBallWrapper Ball;
        public LogicEventArgs(LogicBallWrapper ball)
        {
            this.Ball = ball;
        }


    }
}
