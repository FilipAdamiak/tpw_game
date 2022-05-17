using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Logic
{
    internal class BallsService
    {

        public void BounceFromWall(Data.Ball ball, int boardWidth, int boardHeight)
        {
            int radius = Data.Ball.Radius;
            if (ball.Position.X < 10 || ball.Position.X > boardWidth - radius)
            {
                ball.Velocity *= -Vector2.UnitX;
            }
            if(ball.Position.Y < 10 || ball.Position.Y > boardHeight - radius)
            {
                ball.Velocity *= -Vector2.UnitY;
            }
        }

        public void BounceFromBall(List<Data.Ball> balls, int i)
        {
            Data.Ball ball = balls[i];
            int radius = Data.Ball.Radius;
            foreach(Data.Ball ball2 in balls)
            {
                if (ball == ball2) continue;
                
                if(CheckCollision(ball, ball2))
                {
                    BounceBack(ball, ball2);
                    
                    Vector2 speed1 = ball.Velocity;
                    Vector2 speed2 = ball2.Velocity;

                    var v1X = speed1.X / 2 * radius + 2 * radius * speed2.X / 2 * radius;
                    var v1Y = speed1.Y / 2 * radius + 2 * radius * speed2.Y / 2 * radius;

                    var v2X = 2 * radius * speed1.X / 2 * radius + speed2.X / 2 * radius;
                    var v2Y = 2 * radius * speed1.Y / 2 * radius + speed2.Y / 2 * radius;

                    ball.Velocity = new Vector2(v1X, v1Y);
                    ball2.Velocity = new Vector2(v2X, v2Y);
                }
                return;
            }
        }

        public float Distance(Data.Ball ball_1, Data.Ball ball_2)
        {
            return Vector2.Distance(ball_1.Position, ball_2.Position);
        }

        public bool CheckCollision(Data.Ball ball_1, Data.Ball ball_2)
        {
            int radius = Data.Ball.Radius;
            if (ball_1 == null || ball_2 == null)
                return false;

            return Distance(ball_1, ball_2) <= (2*radius);
        }

        public void BounceBack(Data.Ball ball_1, Data.Ball ball_2)
        {
            while(CheckCollision(ball_1, ball_2))
            {
                ball_1.ChangePosition(-1);
            }
        }


    }
}
