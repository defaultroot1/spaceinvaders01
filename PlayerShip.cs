using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using spaceinvaders01.Helpers;
using System.Runtime.CompilerServices;

namespace spaceinvaders01
{
    internal class PlayerShip : GameObject
    {
        private float _speed = 500;
        public PlayerShip(string spritePath, Vector2 position):base(spritePath, position)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            InputManager(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        public void InputManager(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Position = new Vector2(Position.X - _speed * delta, Position.Y);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Position = new Vector2(Position.X + _speed * delta, Position.Y);
            }

            Position = new Vector2(MathHelper.Clamp(Position.X, 0, GraphicsHelper.ScreenWidth - _texture.Width), Position.Y);
        }
    }
}
