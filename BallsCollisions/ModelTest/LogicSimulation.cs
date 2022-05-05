using Logic;
using System;
using System.Collections.ObjectModel;
using System.Numerics;

namespace ModelTest
{
    public class LogicSimulation : LogicAbstractAPI
    {


        public LogicSimulation()
        {
            CreateApi();
        }

        public override int Width => 750;

        public override int Height => 400;

        public override ObservableCollection<Ball> Balls => new ObservableCollection<Ball>();

        public ObservableCollection<Ball> BallsCollection
        {
            get => Balls;
            set => BallsCollection = value;
        }

        public override Ball CreateBall(Vector2 pos, int radius)
        {
            return new Ball(pos, radius);
        }

        public override void CreateBalls(int count, int radius)
        {
            for (int i = 0; i < count; i++)
            {
                Balls.Add(new Ball(new Vector2(0,0), 25));
            }
        }

        public override void DeleteBalls()
        {
            Balls.Clear();
        }

        public override void RunSimulation()
        {
            for(int i = 0; i < Balls.Count; i++)
            {
                Balls[i].ChangePosition();
            }
        }

        public override void StopSimulation()
        {
            DeleteBalls();
        }
        public int GetBallsAmount()
        {
            return Balls.Count;
        }

    }
}