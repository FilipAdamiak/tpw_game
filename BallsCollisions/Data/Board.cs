using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Threading.Tasks;

namespace Data
{
    internal class Board : DataAbstractAPI
    {
        public Board()
        {
            _balls = new List<BallEntity>();
        }

        public List<BallEntity> _balls { get; }
        private const int Radius = 25;
       
        public List<BallEntity> Balls
        {
            get { return _balls; }
        }

        public override void AddBalls(int amount)
        {
            Random random = new Random();
            for (int i = 0; i < amount; i++)
            {
                Vector2 position = GeneratePointInsideBoard(25);
                Vector2 velocity = GetRandomVelocity();
                float weight = random.Next(25, 50);
                BallEntity ball = new BallEntity.Ball(_balls.Count, position, velocity, weight, this);
                _balls.Add(ball);
            }
        }

        public override void RunSimulation()
        {
            if (CancelSimulationSource.IsCancellationRequested)
            {
                return;
            }

            foreach (var ball in _balls)
            {
                ball.ChangedPosition += OnBallOnPositionChange;

                Task.Factory.StartNew(ball.RunSimulation, CancelSimulationSource.Token);
            }
        }

        public override void StopSimulation()
        {
            CancelSimulationSource.Cancel();
        }
        private Vector2 GeneratePointInsideBoard(int ballRadius)
        {
            var rng = new Random();
            var isPositionCorrect = false;
            var x = 0;
            var y = 0;
            var i = 0;
            while (!isPositionCorrect)
            {
                x = rng.Next(Radius, _boardWidth - Radius);
                y = rng.Next(Radius, _boardHeight - Radius);

                isPositionCorrect = IsSpaceFree(new Vector2(x,y), Radius);

                i++;
            }

            return new Vector2(x, y);
        }

        private bool IsSpaceFree(Vector2 position, int ballRadius)
        {
            foreach (var ball in _balls)
            {
                if (IfCirclesCollide(ball.Position, ball.Radius, position, ballRadius))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IfCirclesCollide(Vector2 position1, float radius1, Vector2 position2, float radius2)
        {
            var distSq = (position1.X - position2.X) * (position1.X - position2.X) + (position1.Y - position2.Y) * (position1.Y - position2.Y);
            var radSumSq = (radius1 + radius2) * (radius1 + radius2);
            return distSq <= radSumSq;
        }

        private Vector2 GetRandomVelocity()
        {
            var rng = new Random();
            var x = rng.Next(-100, 100);
            var y = rng.Next(-100, 100);
            if (Math.Abs(x) < 40)
            {
                x = 40;
            }

            if (Math.Abs(y) < 40)
            {
                y = 40;
            }

            return new Vector2(x, y);
        }
        private void OnBallOnPositionChange(object _, BallEventArgs args)
        {
            var newArgs = new BoardEventArgs(new ObservableCollection<BallEntity>(_balls), args.Ball);
            this.OnPositionChange(newArgs);
        }
    }
    

}
