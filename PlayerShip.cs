using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using spaceinvaders01.Helpers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace spaceinvaders01
{
    internal class PlayerShip : GameObject
    {
        private ProjectileManager _projectileManager;
        private float _speed = 500;
        private KeyboardState _oldKeyboardState;

        public PlayerShip(string spritePath, Vector2 position, ProjectileManager projectileManager) : base(spritePath, position)
        {
            _projectileManager = projectileManager;
        }

        public override void Update(GameTime gameTime)
        {
            InputManager(gameTime);
        }

        public override void Draw()
        {
            SpaceInvaders.spriteBatch.Draw(_texture, Position, Color.White);
        }

        public void InputManager(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.A))
            {
                Position = new Vector2(Position.X - _speed * delta, Position.Y);
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                Position = new Vector2(Position.X + _speed * delta, Position.Y);
            }

            Position = new Vector2(MathHelper.Clamp(Position.X, 0, GraphicsHelper.ScreenWidth - _texture.Width), Position.Y);

            if (keyboardState.IsKeyDown(Keys.Space) && !_oldKeyboardState.IsKeyDown(Keys.Space))
            {
                _projectileManager.LaserList.Add(new PlayerLaser("Sprites/laser",
                    new Vector2(Position.X + (_texture.Width / 2) - 1, Position.Y - _texture.Height / 2)));
            }

            _oldKeyboardState = keyboardState;
        }
    }
}
