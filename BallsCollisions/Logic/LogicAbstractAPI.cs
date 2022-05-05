using System.Numerics;
using System.Collections.ObjectModel;
using Data;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI CreateApi(DataAbstractAPI dataAbstractAPI = default(DataAbstractAPI))
        {
            return new Board(dataAbstractAPI);
        }

        public abstract int Width { get; }
        public abstract int Height { get; }
        public abstract ObservableCollection<Ball> Balls { get; }
        public abstract void RunSimulation();
        public abstract void StopSimulation();
        public abstract Ball CreateBall(Vector2 pos, int radius);
        public abstract void CreateBalls(int count, int radius);
        public abstract void DeleteBalls();
    }
}
