using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Numerics;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Data
{
    public abstract class BallEntity : INotifyPropertyChanged
    {

        public int Id { get; set;  }
        public int Radius { get; private set; }
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; set; }
        public CancellationToken Cancellation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public abstract void ChangePosition(float period);
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal class Ball : BallEntity
        {

            private Stopwatch stopwatch = new Stopwatch();

            public Ball(int id, Vector2 position, Vector2 velocity)
            {
                Id = id;
                Position = position;
                Velocity = velocity;
                Radius = 25;
            }

            public override void ChangePosition(float period)
            {
                Position += new Vector2(Velocity.X * period, Velocity.Y * period);
            }

            private async Task RunTask(float period)
            {
                while (!Cancellation.IsCancellationRequested)
                {
                    stopwatch.Reset();
                    stopwatch.Start();
                    if (!Cancellation.IsCancellationRequested)
                    {
                        ChangePosition(period);
                        RaisePropertyChanged();
                    }
                    stopwatch.Stop();

                    await Task.Delay((int)(period - stopwatch.ElapsedMilliseconds));
                }
            }

        }
    }

    
}
