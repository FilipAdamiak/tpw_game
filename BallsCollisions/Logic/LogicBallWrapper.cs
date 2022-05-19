using System.Numerics;
using Data;

namespace Logic
{
    public abstract class LogicBallWrapper
    {
        public abstract Vector2 Position { get; }
        public abstract int ID { get; }
        public abstract float Radius { get; }
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
        public override float Radius { get { return Ball.Radius; } }
    }
}
