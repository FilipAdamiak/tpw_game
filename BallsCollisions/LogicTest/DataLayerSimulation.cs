using Data;
using System.Collections.ObjectModel;
using System.Numerics;

namespace LogicTest
{

    public class DataSimulation : DataAbstractAPI
    {
        public ObservableCollection<BallEntity> _balls { get; set; }

        public DataSimulation()
        {
            _balls = new ObservableCollection<BallEntity>();
        }
        public bool IsSimulating { get; set; } = false;

        public override void AddBalls(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Vector2 position = new Vector2(1, 1);
                Vector2 velocity = new Vector2(100, 100);
                BallEntity ball = new BallSimulation(_balls.Count, position, velocity, this);
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

        public BallSimulation(int id, Vector2 position, Vector2 velocity, DataAbstractAPI owner)
        {
            Radius = 5;
            Id = id;
            Position = position;
            Velocity = velocity;

        }
        public override void RunSimulation()
        {
            //Run+
        }
    }
}
