using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Data;

namespace Logic
{
    public abstract class LogicBallWrapper
    {
        public abstract Vector2 Position { get; }
        public abstract int ID { get; }
    }
    internal class LogicBall : LogicBallWrapper
    {
        private readonly BallEntity Ball;
        public LogicBall(BallEntity ball)
        {
            Ball = ball;
        }
        public override Vector2 Position { get { return Ball.Position; } }
        public override int ID { get { return Ball.Id; } }
    }
}
