using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace spaceinvaders01
{
    internal class DestructableBlock
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public int Width { get; set; } = 8;
        public int Height { get; set; } = 8;
        public Rectangle SourceArea { get; set; }
        public Rectangle DestinationArea { get; set; }

        public DestructableBlock(Vector2 position)
        {
            Position = position;
            SourceArea = new Rectangle(16, 16, Width, Height);
            DestinationArea = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            Texture = SpaceInvaders.contentManager.Load<Texture2D>("Sprites/player");
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

        }

        public void Draw()
        {
            SpaceInvaders.spriteBatch.Draw(Texture, DestinationArea, SourceArea, Color.White);
        }
    }
}
