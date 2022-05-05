using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Data;

namespace Logic
{   
    internal class Board : LogicAbstractAPI
    {
        public static int _boardWidth = 750;
        public static int _boardHeight = 400;
        private CancellationToken _cancelToken;
        private List<Task> _tasks = new List<Task>();
        public ObservableCollection<Ball> _balls = new ObservableCollection<Ball>();
        private readonly DataAbstractAPI dataAbstract;

        public Board(DataAbstractAPI dataAbstractAPI)
        {
            this.dataAbstract = dataAbstractAPI;
        }

        public CancellationToken CancellationToken => _cancelToken;

        public override void RunSimulation()
        {
            foreach (Ball ball in _balls)
            {
                Task task = Task.Run(() =>
                {
                    Thread.Sleep(1);
                    while (true)
                    {
                        Thread.Sleep(10);
                        try
                        {
                            _cancelToken.ThrowIfCancellationRequested();
                        }
                        catch (OperationCanceledException)
                        {
                            break;
                        }

                        ball.ChangePosition();
                    }
                }
                );
                _tasks.Add(task);
            }
        }

        public override void StopSimulation()
        {
            _tasks.Clear();
            _balls.Clear();
        }

        public override Ball CreateBall(Vector2 pos, int radius)
        {
            return new Ball(pos, radius);
        }

        public override void CreateBalls(int count, int radius)
        {
            if (count < 0)
            {
                count = Math.Abs(count);
            }
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                Ball ball = new Ball();
                ball.Velocity = new Vector2((float)0.0034, (float)0.0034);
                ball.Position = new Vector2(random.Next(1, _boardWidth - 25), random.Next(1, _boardHeight - 25));
               
                _balls.Add(ball);
            }
        }

        public override void DeleteBalls()
        {
            _balls.Clear();
        }

        public int BoardWidth
        {
            get => _boardWidth;
        }
        public int BallsHeight
        {
            get => _boardHeight;
        }

        public override int Width => _boardWidth;

        public override int Height => _boardHeight;

        public override ObservableCollection<Ball> Balls => _balls;
    }
    
}
