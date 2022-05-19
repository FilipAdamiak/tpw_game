using System.Threading;
using System;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        protected DataAbstractAPI()
        {
            CancelSimulationSource = new CancellationTokenSource();
        }

        public static DataAbstractAPI CreateDataAPI()
        {
            return new Board();
        }

        public static int _boardWidth { get; } = 750;
        public static int _boardHeight { get; } = 400;

        public abstract void AddBalls(int amount);
        public abstract void RunSimulation();
        public abstract void StopSimulation();
        public CancellationTokenSource CancelSimulationSource { get; }
        public event EventHandler<BoardEventArgs> BallPositionChange;
        
        protected void OnPositionChange(BoardEventArgs args)
        {
            BallPositionChange?.Invoke(this, args);
        }

        

    }


}
