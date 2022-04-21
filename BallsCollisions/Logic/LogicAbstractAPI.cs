using System;
using System.Collections.Generic;
using System.Text;
using Data;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI CreateLogicAPI(DataAbstractAPI dataAbstractAPI)
        {
            return new LogicAPILayer(dataAbstractAPI);
        }
        public abstract void RunSimulation(Board board);
        public abstract void StopSimulation(Board board);
        public abstract Ball CreateBall(Vector2 pos, int radius);
        public abstract Board CreateBoard(int balls_amount);
    }

    public class LogicAPILayer : LogicAbstractAPI
    {
        private CancellationToken _cancelToken;
        public CancellationToken CancellationToken => _cancelToken;
        private List<Task> _tasks = new List<Task>();

        public override void RunSimulation(Board board)
        {
            foreach (Ball ball in board._balls)
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

        public override void StopSimulation(Board board)
        {
            _tasks.Clear();
            board._balls.Clear();
        }
        public LogicAPILayer(DataAbstractAPI dataAbstractAPI)
        {
            DataAbstractAPI dataLayer = dataAbstractAPI;
        }
        public override Ball CreateBall(Vector2 pos, int radius)
        {
            return new Ball(pos, radius);
        }
        public override Board CreateBoard(int balls_amount)
        {
            return new Board(balls_amount);
        }

         
    }
    
}
