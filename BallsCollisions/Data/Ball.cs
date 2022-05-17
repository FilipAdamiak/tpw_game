using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Numerics;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Data
{
     public class Ball : INotifyPropertyChanged
    {
        public int Id { get; private set; }
        public static int Radius { get; private set; }
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; set; }
        public CancellationToken Cancellation { get; private set; }
        private Stopwatch stopwatch = new Stopwatch();

        public Ball(int id, Vector2 position, Vector2 velocity)
        {
            Id = id;
            Position = position;
            Velocity = velocity;
            Radius = 25;
        }

        public void ChangePosition(float period)
        {
            Position += new Vector2(Velocity.X * period, Velocity.Y * period);
        }

        private async Task RunTask(float period)
        {
            while (!Cancellation.IsCancellationRequested)
            {
                stopwatch.Reset();
                stopwatch.Start();
                if(!Cancellation.IsCancellationRequested)
                {
                    ChangePosition(period);
                    RaisePropertyChanged();
                }
                stopwatch.Stop();

                await Task.Delay((int) (period - stopwatch.ElapsedMilliseconds)); 
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
