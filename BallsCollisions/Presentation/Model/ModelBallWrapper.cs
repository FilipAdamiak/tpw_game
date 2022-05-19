using System.Numerics;
using Logic;

namespace Model
{
    public abstract class ModelBallWrapper
    {
        public abstract Vector2 Position { get; }
        public abstract float Radius { get; }
        public abstract int ID { get; }
    }
    internal class ModelBall : ModelBallWrapper
    {
        private readonly LogicBallWrapper ball;
        public ModelBall(LogicBallWrapper ball)
        {
            this.ball = ball; 
        }
        public override Vector2 Position
        {
            get { return ball.Position; }
        }
        public override float Radius
        {
            get { return ball.Radius; }
        }
        public override int ID
        {
            get { return ball.ID; }
        }
    }
}
