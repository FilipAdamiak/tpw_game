using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static Data.BallEntity;

namespace Data
{
    internal class Board : DataAbstractAPI
    {
        public Board()
        {
            _balls = new List<BallEntity>();
        }

        public List<BallEntity> _balls { get; }


    
        public List<BallEntity> Balls
        {
            get { return _balls; }
        }

        public override void AddBalls(int amount)
        {
            Random random = new Random();
            for (int i = 0; i < amount; i++)
            {
                //BallEntity ballEntity = new Ball(i, new Vector2(random.Next(1, _boardWidth - 25), random.Next(1, _boardHeight - 25)),
                //    new Vector2((float)0.0034, (float)0.0034), this);
             
                Vector2 position = GetRandomPointInsideBoard(25);
                Vector2 velocity = GetRandomVelocity();
                BallEntity ball = new Ball(_balls.Count, position, velocity, this);
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
                ball.ChangedPosition += this.OnBallOnPositionChange;

                Task.Factory.StartNew(ball.RunSimulation, CancelSimulationSource.Token);
            }
        }

        public override void StopSimulation()
        {
            CancelSimulationSource.Cancel();
        }
        private Vector2 GetRandomPointInsideBoard(int ballRadius)
        {
            var rng = new Random();
            var isPositionCorrect = false;
            var x = 0;
            var y = 0;
            var i = 0;
            while (!isPositionCorrect)
            {
                //Vector2 position = new Vector2(25, 25);
                x = rng.Next(25, _boardWidth - 25);
                y = rng.Next(25, _boardHeight - 25);

                isPositionCorrect = this.CheckIsSpaceFree(new Vector2(x,y), 25);

                i++;
            }

            return new Vector2(x, y);
        }

        private bool CheckIsSpaceFree(Vector2 position, int ballRadius)
        {
            foreach (var ball in _balls)
            {
                if (this.IfCirclesCollide(ball.Position, ball.Radius, position, ballRadius))
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
            var x = rng.Next(-200, 200);
            var y = rng.Next(-50, 50);
            if (Math.Abs(x) < 50)
            {
                x = 50;
            }

            if (Math.Abs(y) < 50)
            {
                y = 50;
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
