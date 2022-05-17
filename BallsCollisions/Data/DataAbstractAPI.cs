using System.Numerics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Data
{
    public abstract class DataAbstractAPI
    {

        public abstract void AddBall(Ball ball);
        public abstract void RemoveBall(Ball ball);
        public abstract Ball GetBallById(int id);

        public abstract ObservableCollection<Ball> GetAllBalls();
        public abstract void CreateBalls(int count);
        public static DataAbstractAPI CreateDataAPI()
        {
            return new Board();
        }
        public static Ball CreateBall(int id, Vector2 position, Vector2 velocity, double radius)
        {
            return new Ball(id, position, velocity);
        }
    }

   
}
