using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Data;

namespace Logic
{
    internal class BallsService
    {
        private int radius = 25;
        public void BounceFromWall(BallEntity ball, int boardWidth, int boardHeight)
        {
            if (ball.Position.X < 10 || ball.Position.X > boardWidth - radius)
            {
                ball.Velocity *= -Vector2.UnitX;
            }
            if(ball.Position.Y < 10 || ball.Position.Y > boardHeight - radius)
            {
                ball.Velocity *= -Vector2.UnitY;
            }
        }

        public void BounceFromBall(List<BallEntity> balls, int i)
        {
            BallEntity ball = balls[i];
            foreach(BallEntity ball2 in balls)
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

        public float Distance(BallEntity ball_1, BallEntity ball_2)
        {
            return Vector2.Distance(ball_1.Position, ball_2.Position);
        }

        public bool CheckCollision(BallEntity ball_1, BallEntity ball_2)
        {
            if (ball_1 == null || ball_2 == null)
                return false;

            return Distance(ball_1, ball_2) <= (2*radius);
        }

        public void BounceBack(BallEntity ball_1, BallEntity ball_2)
        {
            while(CheckCollision(ball_1, ball_2))
            {
                ball_1.ChangePosition(-1);
            }
        }


    }
}
