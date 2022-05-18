using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Data;

namespace Logic
{   
    internal class LogicAPI : LogicAbstractAPI
    {
        private readonly Mutex _mutex = new Mutex(false);
        private readonly DataAbstractAPI dataAbstract;

        public LogicAPI(DataAbstractAPI dataAbstractAPI)
        {
            dataAbstract = dataAbstractAPI;
        }

        public override void RunSimulation()
        {
            dataAbstract.BallPositionChange += OnDataBallsOnPositionChange;
            dataAbstract.RunSimulation();

        }

        public override void StopSimulation()
        {
            dataAbstract.StopSimulation();
        }
        private void OnDataBallsOnPositionChange(object _, BoardEventArgs args)
        {
            this.HandleBallsCollisions(args.sender, args.Balls);
            BallsService.CollideWithWalls(args.sender, new Vector2(DataAbstractAPI._boardWidth, DataAbstractAPI._boardHeight));
            var newArgs = new LogicEventArgs(new LogicBall(args.sender));
            OnPositionChange(newArgs);
        }
        private void HandleBallsCollisions(BallEntity ball, ObservableCollection<BallEntity> allBalls)
        {
            _mutex.WaitOne();
            try
            {
                var collidedBall = BallsService.CheckCollisions(ball, allBalls);
                if (collidedBall != null)
                {
                    BallsService.HandleCollision(ball, collidedBall);
                }
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }

        public override void AddBalls(int amount)
        {
            dataAbstract.AddBalls(amount);
        }

        public override int GetBoardWidth()
        {
            return DataAbstractAPI._boardWidth;
        }

        public override int GetBoardHeight()
        {
            return DataAbstractAPI._boardHeight;
        }
    }
    
}
