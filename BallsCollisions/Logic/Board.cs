using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{   
    public class Board
    {
        private int _boardWidth { get; }
        private int _boardHeight { get; }
        public List<Ball> _balls;


        public Board(int width, int height, int balls_number)
        {
            _boardWidth = width;
            _boardHeight = height;
            _balls = new List<Ball>();
            CreateBalls(balls_number);
        }

        public void CreateBalls(int count)
        {
            Random random = new Random();
            int ball_radius = 5;
            for (int i = 0; i < count; i++)
            {
                
                int _randX = random.Next(1, _boardWidth);
                int _randY = random.Next(1, _boardHeight);

                _balls.Add(new Ball(_randX, _randY, ball_radius));
            }
        }

       
    }
    
}
