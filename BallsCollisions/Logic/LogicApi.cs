using System.Numerics;
using System.Collections.ObjectModel;

namespace Logic
{
    public abstract class LogicApi
    {
        public static LogicApi CreateApi()
        {
            return new Board();
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
