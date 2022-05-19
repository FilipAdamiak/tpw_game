using System;

namespace Model
{
    public class ModelEventArgs : EventArgs
    {
        public readonly ModelBallWrapper Ball;
        public ModelEventArgs(ModelBallWrapper ball)
        {
            Ball = ball;
        }
    }
}
