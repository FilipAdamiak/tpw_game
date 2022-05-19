﻿using System.Collections.Generic;
using System.Numerics;
using Data;

namespace Logic
{
    internal class BallsService
    {
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
            var centerOne = ballOne.Position + (Vector2.One * ballOne.Radius / 2) + ballOne.Velocity * (16 / 1000f);
            var centerTwo = ballTwo.Position + (Vector2.One * ballTwo.Radius / 2) + ballTwo.Velocity * (16 / 1000f);

            var distance = Vector2.Distance(centerOne, centerTwo);
            var radiusSum = (ballOne.Radius + ballTwo.Radius) / 2f;

            return distance <= radiusSum;
        }

        public static void CollideWithWalls(BallEntity ball, Vector2 boardSize)
        {
            var position = ball.Position + ball.Velocity * (16 / 1000f);
            if (position.X <= 0 || position.X + ball.Radius >= boardSize.X)
            {
                ball.Velocity = new Vector2(-ball.Velocity.X, ball.Velocity.Y);
            }

            if (position.Y <= 0 || position.Y + ball.Radius >= boardSize.Y)
            {
                ball.Velocity = new Vector2(ball.Velocity.X, -ball.Velocity.Y);
            }
        }

        public static void HandleCollision(BallEntity ballOne, BallEntity ballTwo)
        {
            Vector2 centerOne = ballOne.Position + (Vector2.One * ballOne.Radius / 2);
            Vector2 centerTwo = ballTwo.Position + (Vector2.One * ballTwo.Radius / 2);

            Vector2 unitNormalVector = Vector2.Normalize(centerTwo - centerOne);
            Vector2 unitTangentVector = new Vector2(-unitNormalVector.Y, unitNormalVector.X);

            float velocityOneNormal = Vector2.Dot(unitNormalVector, ballOne.Velocity);
            float velocityOneTangent = Vector2.Dot(unitTangentVector, ballOne.Velocity);
            float velocityTwoNormal = Vector2.Dot(unitNormalVector, ballTwo.Velocity);
            float velocityTwoTangent = Vector2.Dot(unitTangentVector, ballTwo.Velocity);

            float newNormalVelocityOne = (velocityOneNormal * (ballOne.Mass - ballTwo.Mass) + 2 * ballTwo.Mass * velocityTwoNormal) / (ballOne.Mass + ballTwo.Mass);
            float newNormalVelocityTwo = (velocityTwoNormal * (ballTwo.Mass - ballOne.Mass) + 2 * ballOne.Mass * velocityOneNormal) / (ballOne.Mass + ballTwo.Mass);

            Vector2 newVelocityOne = Vector2.Multiply(unitNormalVector, newNormalVelocityOne) + Vector2.Multiply(unitTangentVector, velocityOneTangent);
            Vector2 newVelocityTwo = Vector2.Multiply(unitNormalVector, newNormalVelocityTwo) + Vector2.Multiply(unitTangentVector, velocityTwoTangent);

            ballOne.Velocity = newVelocityOne;
            ballTwo.Velocity = newVelocityTwo;
        }
    }
}
