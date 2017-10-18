using Microsoft.Xna.Framework;

namespace _4.zadatak
{
    /// <summary>
    /// Game ball object representation
    /// </summary>
    public class Ball : Sprite
    {
        public readonly float maxSpeed=1;
        public class BVector
        {
            private float x;
            private float y;

            public enum ArrowDir
            {
                SW,
                SE,
                NW,
                NE
            };

            public BVector(ArrowDir arrowDir)
            {
                if (arrowDir.Equals(ArrowDir.SW))
                {
                    x = -1f;
                    y = 1f;
                }
                if (arrowDir.Equals(ArrowDir.SE))
                {
                    x = 1f;
                    y = 1f;
                }
                if (arrowDir.Equals(ArrowDir.NW))
                {
                    x = -1f;
                    y = -1f;
                }
                if (arrowDir.Equals(ArrowDir.NE))
                {
                    x = 1f;
                    y = -1f;
                }
            }
            public static Vector2 operator *(BVector v, float f)
            {
                return new Vector2(v.x*f, v.y*f);
            }
            public static Vector2 operator *(BVector vector, Vector2 vector2)
            {
                return new Vector2(vector.x * vector2.X, vector.y * vector2.Y);
            }

            public override string ToString()
            {
                return this.x+""+this.y;
            }
        }
        /// <summary>
        /// Defines current ball speed in time .
        /// </summary>
        public float Speed { get; set; }

        public void setBallSpeed(float speed)
        {
            if (speed <= 1f) this.Speed = speed;
        }
        public float BumpSpeedIncreaseFactor { get; set; }
        /// <summary>
        /// Defines ball direction .
        /// Valid values ( -1 , -1) , (1 ,1) , (1 , -1) , ( -1 ,1).
        /// Using Vector2 to simplify game calculation . Potentially
        /// dangerous because vector 2 can swallow other values as well .
        /// OPTIONAL TODO : create your own , more suitable type
        /// </summary>
        public BVector Direction { get; set; }
        public Ball(int size, float speed, float
            defaultBallBumpSpeedIncreaseFactor) : base(size, size)
        {
            Speed = speed;
            BumpSpeedIncreaseFactor = defaultBallBumpSpeedIncreaseFactor;
            // Initial direction
            Direction = new BVector(BVector.ArrowDir.SE);
        }
    }
}