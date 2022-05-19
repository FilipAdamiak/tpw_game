using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    public class VisualBall : INotifyPropertyChanged
    {
        private Vector2 position;
        private float radius;


        public VisualBall()
        {
            position = Vector2.Zero;
            radius = 0;
        }
        public VisualBall(Vector2 position, float radius)
        {
            this.position = position;
            this.radius = radius;
        }
        public Vector2 Position
        {
            get { return position; }
            set 
            {
                X = value.X;
                Y = value.Y;
                OnPropertyChanged();
            }
        }
        public float X
        {
            get { return position.X; }
            set 
            {
                position.X = value;
                OnPropertyChanged();
            }
        }
        public float Y
        {
            get { return position.Y; }
            set
            {
                position.Y = value;
                OnPropertyChanged();
            }
        }
        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string caller = null)
        {
            var args = new PropertyChangedEventArgs(caller);
            PropertyChanged?.Invoke(this, args);
        }
    }
}
