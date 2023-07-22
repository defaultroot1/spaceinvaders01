using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace spaceinvaders01
{
    internal class AlienLaser : GameObject
    {
        public Vector2 Velocity { get; set; } = new Vector2(0, 1);
        public float Speed { get; set; } = 5;
        public AlienLaser(string spritePath, Vector2 position) : base(spritePath, position)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw()
        {
            SpaceInvaders.spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
