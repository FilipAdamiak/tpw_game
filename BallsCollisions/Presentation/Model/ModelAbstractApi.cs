using System;

namespace Model
{
    public abstract class ModelAbstractApi
    {
        public abstract int BallsAmount { get; }

        public static ModelAbstractApi Create()
        {
            return new ModelApi();
        }
    }

    internal class ModelApi : ModelAbstractApi
    {
        public override int BallsAmount => 15;  
    }
}
