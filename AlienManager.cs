using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using spaceinvaders01.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace spaceinvaders01
{
    internal class AlienManager
    {
        public List<Alien> AlienList { get; set; }
        private ProjectileManager _projectileManager;
        private Random _random;
        private float _startingY = 100;

        public AlienManager(ProjectileManager projectileManager)
        {
            _projectileManager = projectileManager;
            AlienList = new List<Alien>();
            CreateSwarm(_startingY);
        }

        public void Update(GameTime gameTime)
        {
            if (AlienList.Count > 0)
            {
                foreach (Alien alien in AlienList)
                {
                    alien.UpdateMovementX(gameTime);
                    alien.UpdateAnimation(gameTime);
                }

                HandleMovementAtBounds();
                RandomFireLaser();
            }
            else
            {
                AlienList.Clear();
                _startingY += 60;
                CreateSwarm(_startingY);
            }

        }

        public void Draw()
        {
            foreach(Alien alien in AlienList)
            {
                alien.DrawAnimated();
            }
        }

        /// <summary>
        /// Initial creation of the alien swarm layout. Front row is ActiveShooter so can fire
        /// </summary>
        public void CreateSwarm(float startingY)
        {
            if(AlienList.Count > 0)
            {
                AlienList.Clear();
            }

            for(int i = 0; i < 11; i++)
            {
                AlienList.Add(new Alien("Sprites/alien8atlas", new Vector2((i * 60) + 17, startingY), 1, 2, 1.0f, _projectileManager, 30));
                AlienList.Add(new Alien("Sprites/alien11atlas", new Vector2((i * 60) + 11, startingY + 60), 1, 2, 1.0f, _projectileManager, 20));
                AlienList.Add(new Alien("Sprites/alien11atlas", new Vector2((i * 60) + 11, startingY + 120), 1, 2, 1.0f, _projectileManager, 20));
                AlienList.Add(new Alien("Sprites/alien12atlas", new Vector2((i * 60) + 10, startingY + 180), 1, 2, 1.0f, _projectileManager, 10));
                AlienList.Add(new Alien("Sprites/alien12atlas", new Vector2((i * 60) + 10, startingY + 240), 1, 2, 1.0f, _projectileManager, 10, true));

            }

        }

        /// <summary>
        /// If either the first (left most) or last (right most) alien touch the screen bounds, reverse X velocity
        /// and move the swarm down a row
        /// </summary>
        public void HandleMovementAtBounds()
        {
            Alien lastAlien = AlienList.Last();
            Alien firstAlien = AlienList.First();

            if (lastAlien.Position.X + lastAlien.Width > GraphicsHelper.ScreenWidth || 
                firstAlien.Position.X <= 0)
            {
                foreach (Alien alien in AlienList)
                {
                    alien.ChangeVelocityX();
                    alien.AdvanceOneRow();
                }
            }
        }

        /// <summary>
        /// Each alien that is flagged as ActiveShooter as a small random chance to fire their laser each frame
        /// </summary>
        public void RandomFireLaser()
        {
            foreach(Alien alien in AlienList)
            {
                if(alien.ActiveShooter)
                {
                    _random = new Random();
                    int randomNum = _random.Next(0, 10000);

                    if (randomNum > 9980)
                    {
                        alien.FireLaser();
                    }
                }

            }
        }
    }
}
