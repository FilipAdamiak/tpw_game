using System;
using System.Collections.Generic;
using System.Text;

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
