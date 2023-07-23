using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private float _speed = 1.0f;
        private float _speedIncrase = 0.2f;
        private ProjectileManager _projectileManager;
        public bool ActiveShooter { get; set; } = false;
        public int Points { get; set; }

        public Alien(string spritePath, Vector2 position, int rows, int columns, float animationSpeed, ProjectileManager projectileManager, int points, bool activeShooter=false) : base(spritePath, position, rows, columns, animationSpeed) 
        {
            _velocity = new Vector2(1, 0);
            _projectileManager = projectileManager; 
            ActiveShooter = activeShooter;
            Points = points;
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
            Position = new Vector2(Position.X, Position.Y + 30);
        }

        public void FireLaser()
        {
            _projectileManager.AlienLaserList.Add(new AlienLaser("Sprites/laser2",
                new Vector2(Position.X + Width / 2, Position.Y + Width / 2)));
        }

        public void MakeActiveShooter()
        {
            ActiveShooter = true;
        }

        public void IncreaseSpeed()
        {
            _speed += _speedIncrase;
        }

    }
}
