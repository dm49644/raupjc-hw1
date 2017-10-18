using System;

namespace _4.zadatak
{
    public class CollisionDetector
    {
        public static bool Overlaps(IPhysicalObject2D a, IPhysicalObject2D b)
        {
            Ball ball = (Ball) a;
            if (b.Width == GameConstants.PaddleDefaultWidth)
            {
                Paddle paddle = (Paddle)b;
                if (paddle.name.Equals("Bottom"))
                {
                    if (Math.Abs(ball.Y - paddle.Y+paddle.Height) < 5f && (ball.X > paddle.X && ball.X<paddle.X+paddle.Width)) return true;
                }
                if (paddle.name.Equals("Top"))
                {
                    if ((Math.Abs(ball.Y - paddle.Y - paddle.Height) < 10f) && (ball.X > paddle.X && ball.X < paddle.X + paddle.Width)) return true;
                }

            }
            else if (Math.Abs(b.X + GameConstants.WallDefaultSize) < 0.0001)
            {
                Wall leftWall = (Wall) b;
                if (Math.Abs(leftWall.X + GameConstants.WallDefaultSize - ball.X-ball.Width) < 5f)
                {
                    return true;
                }
            }
            else if (Math.Abs(b.Y) < 0.0001)
            {
                Wall rightWall = (Wall) b;
                if (Math.Abs(rightWall.X - ball.X-ball.Width) < 5f) return true; //High performance graphics processor doesn't support Reach!
            }
            else if (Math.Abs(b.X)<0.0001)
            {
                Wall bottomWall = (Wall) b;
                if (Math.Abs(bottomWall.Y-ball.Y) < 4f) return true;
            }
            else
            {
                Wall topWall = (Wall) b;
                if (Math.Abs(topWall.Y - ball.Y) < 4f) return true;
            }
            return false; 
        }
    }
}