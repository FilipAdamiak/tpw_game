using Data;
using System.Collections.ObjectModel;
using System.Numerics;

namespace LogicTest
{

    public class DataSimulation : DataAbstractAPI
    {
        public ObservableCollection<BallSimulation> _balls { get; set; }

        public DataSimulation()
        {
            _balls = new ObservableCollection<BallSimulation>();
        }
        public bool IsSimulating { get; set; } = false;

        public override void AddBalls(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Vector2 position = new Vector2(1, 1);
                Vector2 velocity = new Vector2(100, 100);
                BallSimulation ball = new BallSimulation(_balls.Count, position, velocity, this);
                _balls.Add(ball);
            }
        }

        public override void RunSimulation()
        {
            foreach(var ball in _balls)
            {
                ball.RunSimulation();
            }
            IsSimulating = true;   
        }

        public override void StopSimulation()
        {
            IsSimulating = false;
        }
    }
    public class BallSimulation : BallEntity
    {
        private int _radius;
        private Vector2 _velocity;
        private Vector2 _position;
        private int _id;
        public BallSimulation(int id, Vector2 position, Vector2 velocity, DataAbstractAPI owner)
        {
            _radius = 5;
            _id = id;
            _position = position;
            _velocity = velocity;
        }

        public int Radius { get { return _radius; } }
        public Vector2 Position { get { return _position; } }
        public int Id { get { return _id; } }
        public Vector2 Velocity { get { return _velocity; } }
        public override void RunSimulation()
        {
            
        }
    }
}
