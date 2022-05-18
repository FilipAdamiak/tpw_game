using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

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
