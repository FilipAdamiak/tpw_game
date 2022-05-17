using System.Numerics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static Data.BallEntity;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public abstract void AddBall(BallEntity ball);
        public abstract void RemoveBall(BallEntity ball);
        public abstract BallEntity GetBallById(int id);
        public abstract ObservableCollection<BallEntity> GetAllBalls();
        public abstract void CreateBalls(int count);
        public static DataAbstractAPI CreateDataAPI()
        {
            return new Board();
        }
        public static BallEntity CreateBall(int id, Vector2 position, Vector2 velocity)
        {
            return new Ball(id, position, velocity);
        }
    }

   
}
