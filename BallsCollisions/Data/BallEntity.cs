using System.Numerics;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Data
{
    public abstract class BallEntity : ISerializable
    {

        public int Id { get; private set;  }
        [JsonIgnore]
        public int Radius { get; private set; }
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; set; }
        public float Mass { get; private set; }
        [JsonIgnore]
        public CancellationToken Cancellation { get; set; }
        public event EventHandler<BallEventArgs> ChangedPosition;
        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);

        public abstract void RunSimulation();

        internal class Ball : BallEntity
        {
            private readonly DataAbstractAPI owner;
            public Ball(int id, Vector2 position, Vector2 velocity, float mass ,DataAbstractAPI owner)
            {
                Id = id;
                Position = position;
                Velocity = velocity;
                Radius = 25;
                Mass = mass;
                this.owner = owner;
            }
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("id", Id);
                info.AddValue("position", Position);
                info.AddValue("velocity", Velocity);
                info.AddValue("mass", Mass);
                info.AddValue("radius", Radius);
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
                    nextPosition.Y = DataAbstractAPI._boardHeight - Radius + 1;
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
