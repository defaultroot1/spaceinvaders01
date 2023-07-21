using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace spaceinvaders01
{
    internal class GameObject
    {
        protected Texture2D _texture;
        public Vector2 Position { get; set; }


        public GameObject(string spritePath, Vector2 position)
        {
            _texture = SpaceInvaders.contentManager.Load<Texture2D>(spritePath);
            Position = position;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
        }

        public virtual void Update(GameTime gameTime)
        {
            // Update logic
        }

        public virtual void Draw()
        {
            // Draw object
        }
    }
}
