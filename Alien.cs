using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceinvaders01
{
    internal class Alien : GameObject
    {
        private Vector2 _velocity;
        private float _speed;
        private ProjectileManager _projectileManager;
        public Alien(string spritePath, Vector2 position, ProjectileManager projectileManager) : base(spritePath, position) 
        {
            _velocity = new Vector2(1, 0);
            _speed = 1.0f;
            _projectileManager = projectileManager; 
        }

        public  void UpdateMovementX(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Position = new Vector2(Position.X + _velocity.X * _speed, Position.Y);

            
        }

        public override void Draw()
        {
            SpaceInvaders.spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void ChangeVelocityX()
        {
            _velocity = _velocity * -1;
        }

        public void AdvanceOneRow()
        {
            Position = new Vector2(Position.X, Position.Y + 60);
        }

        public void FireLaser()
        {
            _projectileManager.AlienLaserList.Add(new AlienLaser("Sprites/laser2",
                new Vector2(Position.X + Texture.Width / 2, Position.Y + Texture.Width / 2)));
        }
    }
}
