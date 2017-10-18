using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _4.zadatak
{
    /// <summary>
    /// Represents player paddle.
    /// </summary>
    public class Paddle : Sprite
    {
        /// <summary>
        /// Current paddle speed in time
        /// </summary>
        public String name;
        public float Speed { get; set; }
        public Paddle(int width, int height, float initialSpeed, String name) : base(width,
            height)
        {
            Speed = initialSpeed;
            this.name = name;
        }
        /// <summary>
        /// Overriding draw method . Masking paddle texture with black color .
        /// </summary>
        public override void DrawSpriteOnScreen(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Vector2(X, Y), new Rectangle(0, 0,
                Width, Height), Color.GhostWhite);
        }
    }
}