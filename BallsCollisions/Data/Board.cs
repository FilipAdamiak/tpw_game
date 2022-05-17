using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Data
{
    internal class Board : DataAbstractAPI
    {
        public static int BoardWidth { get; set; }
        public static int BoardHeight { get; set; }
        private ObservableCollection<Ball> _balls;
       
        public Board()
        {
            _balls = new ObservableCollection<Ball>();
            BoardWidth = 750;
            BoardHeight = 400;
        }

        public ObservableCollection<Ball> Balls
        {
            get { return _balls; }
        }
   
        public override ObservableCollection<Ball> GetAllBalls()
        {
            return _balls;
        }

        public override Ball GetBallById(int id)
        {
            Ball result = null;
            foreach(Ball ball in _balls)
            {
                if(ball.Id == id)
                {
                    result = ball;
                }
            }
            return result;
        }

        public override void AddBall(Ball ball)
        {
            _balls.Add(ball);   
        }
        public override void RemoveBall(Ball ball)
        {
            _balls.Remove(ball);
        }

  
        public override void CreateBalls(int count)
        {
            if (count < 0)
            {
                count = Math.Abs(count);
            }
            Random random = new Random();
            int radius = Ball.Radius;
            for (int i = 0; i < count; i++)
            { 
                Vector2 vel = new Vector2((float)0.0034, (float)0.0034);
                Vector2 pos = new Vector2(random.Next(1, BoardWidth - radius), random.Next(1, BoardHeight - radius));
                Ball ball = new Ball(Balls.Count, pos, vel);
                _balls.Add(ball);
            }
        }

   
    }
}
