using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Data;

namespace Logic
{
    internal class BallsService
    {
        /*private static int radius = 25;
        public static void BounceFromWall(BallEntity ball, int boardWidth, int boardHeight)
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

        public static void BounceFromBall(List<BallEntity> balls, int i)
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

        public static float Distance(BallEntity ball_1, BallEntity ball_2)
        {
            return Vector2.Distance(ball_1.Position, ball_2.Position);
        }

        public static bool CheckCollision(BallEntity ball_1, BallEntity ball_2)
        {
            if (ball_1 == null || ball_2 == null)
                return false;

            return Distance(ball_1, ball_2) <= (2*radius);
        }

        public static void BounceBack(BallEntity ball_1, BallEntity ball_2)
        {
            while(CheckCollision(ball_1, ball_2))
            {
                ball_1.Move(-1);
            }
        }*/

        public static BallEntity CheckCollisions(BallEntity ball, IEnumerable<BallEntity> ballsList)
        {
            foreach (var ballTwo in ballsList)
            {
                if (ReferenceEquals(ball, ballTwo))
                {
                    continue;
                }

                if (IsBallsCollides(ball, ballTwo))
                {
                    return ballTwo;
                }
            }

            return null;
        }

        private static bool IsBallsCollides(BallEntity ballOne, BallEntity ballTwo)
        {
            var centerOne = ballOne.Position + (Vector2.One * 25 / 2) + ballOne.Velocity * (16 / 1000f);
            var centerTwo = ballTwo.Position + (Vector2.One * 25 / 2) + ballTwo.Velocity * (16 / 1000f);

            var distance = Vector2.Distance(centerOne, centerTwo);
            var radiusSum = (25 + 25) / 2f;

            return distance <= radiusSum;
        }

        public static void CollideWithWalls(BallEntity ball, Vector2 boardSize)
        {
            var position = ball.Position + ball.Velocity * (16 / 1000f);
            if (position.X <= 0 || position.X + 25 >= boardSize.X)
            {
                ball.Velocity = new Vector2(-ball.Velocity.X, ball.Velocity.Y);
            }

            if (position.Y <= 0 || position.Y + 25 >= boardSize.Y)
            {
                ball.Velocity = new Vector2(ball.Velocity.X, -ball.Velocity.Y);
            }
        }

        public static void HandleCollision(BallEntity ballOne, BallEntity ballTwo)
        {
            var centerOne = ballOne.Position + (Vector2.One * 25 / 2);
            var centerTwo = ballTwo.Position + (Vector2.One * 25 / 2);

            var unitNormalVector = Vector2.Normalize(centerTwo - centerOne);
            var unitTangentVector = new Vector2(-unitNormalVector.Y, unitNormalVector.X);

            var velocityOneNormal = Vector2.Dot(unitNormalVector, ballOne.Velocity);
            var velocityOneTangent = Vector2.Dot(unitTangentVector, ballOne.Velocity);
            var velocityTwoNormal = Vector2.Dot(unitNormalVector, ballTwo.Velocity);
            var velocityTwoTangent = Vector2.Dot(unitTangentVector, ballTwo.Velocity);

            var newNormalVelocityOne = (velocityOneNormal * velocityTwoNormal);
            var newNormalVelocityTwo = (velocityTwoNormal  * velocityOneNormal) ;

            var newVelocityOne = (unitNormalVector) + Vector2.Multiply(unitTangentVector, velocityOneTangent);
            var newVelocityTwo = (unitNormalVector) + Vector2.Multiply(unitTangentVector, velocityTwoTangent);

            ballOne.Velocity = newVelocityOne;
            ballTwo.Velocity = newVelocityTwo;
        }
    }
}
