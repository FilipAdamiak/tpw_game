using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{   
    public class Board
    {
        public static int _boardWidth;
        public static int _boardHeight;
        public List<Ball> _balls;
        public List<Task> _tasks = new List<Task>();


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
                
                int _randX = random.Next(1, _boardWidth - 25);
                int _randY = random.Next(1, _boardHeight - 25);

                _balls.Add(new Ball(_randX, _randY, ball_radius));
            }
        }
       
    }
    
}
