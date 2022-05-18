using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Numerics;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System;

namespace Data
{
    public abstract class BallEntity
    {

        public int Id { get; set;  }
        public int Radius { get; private set; }
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; set; }
        public CancellationToken Cancellation { get; set; }
        public event EventHandler<BallEventArgs> ChangedPosition;
     
        public abstract void RunSimulation();

        internal class Ball : BallEntity
        {
            private readonly DataAbstractAPI owner;
            public Ball(int id, Vector2 position, Vector2 velocity, DataAbstractAPI owner)
            {
                Id = id;
                Position = position;
                Velocity = velocity;
                Radius = 25;
                this.owner = owner;
            }

            public Vector2 Move(Vector2 nextPosition)
            {
                if (nextPosition.X < 0)
                    nextPosition.X = -1;
                if (Radius + nextPosition.X > DataAbstractAPI._boardWidth)
                    nextPosition.X = DataAbstractAPI._boardWidth - Radius + 1;

                if (nextPosition.Y < 0)
                    nextPosition.Y = -1;
                if (Radius + nextPosition.Y > DataAbstractAPI._boardHeight)
                    nextPosition.Y = Board._boardHeight - Radius + 1;
                return nextPosition;
            }

            public override async void RunSimulation()
            {
                Stopwatch stopwatch = new Stopwatch();
                float time = 0f;
                while (!owner.CancelSimulationSource.Token.IsCancellationRequested)
                {
                    stopwatch.Start();
                    BallEventArgs args = new BallEventArgs(this);
                    ChangedPosition?.Invoke(this, args);
                    Vector2 movedPos = Position + Vector2.Multiply(Velocity, time);
                    Position = Move(movedPos);
                    await Task.Delay(4, owner.CancelSimulationSource.Token).ContinueWith(_ => { });
                    stopwatch.Stop();
                    time = stopwatch.ElapsedMilliseconds / 1000f;
                    stopwatch.Reset();
                }
            }

            

        }
    }

    
}
