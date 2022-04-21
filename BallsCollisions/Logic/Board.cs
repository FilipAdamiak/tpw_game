using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{   
    public class Board
    {
        public static int _boardWidth = 750;
        public static int _boardHeight = 400;
        public ObservableCollection<Ball> _balls = new ObservableCollection<Ball>();

        public Board()
        {

        }

        public Board(int balls_number)
        {
            CreateBalls(balls_number);
        }

        public void CreateBalls(int count)
        {
            if(count < 0)
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
        public ObservableCollection<Ball> Balls
        {
            get => _balls;
        }
       
        public int BoardWidth
        {
            get => _boardWidth;
        }
        public int BallsHeight
        {
            get => _boardHeight;
        }

    }
    
}
