﻿using Microsoft.Xna.Framework;
using spaceinvaders01.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceinvaders01
{
    internal class AlienManager
    {
        public List<Alien> AlienList { get; set; }
        private ProjectileManager _projectileManager;

        public AlienManager(ProjectileManager projectileManager)
        {
            _projectileManager = projectileManager;
            AlienList = new List<Alien>();
            CreateSwarm();
            

        }

        public void Update(GameTime gameTime)
        {
            if( AlienList.Count > 0 )
            {
                HandleMovementAtBounds();

                foreach (Alien alien in AlienList)
                {
                    alien.UpdateMovementX(gameTime);

                }
            }
        }

        public void Draw()
        {
            foreach (Alien alien in AlienList)
            {
                alien.Draw();
            }
        }

        public void CreateSwarm()
        {
            if(AlienList.Count > 0)
            {
                AlienList.Clear();
            }

            for(int i = 0; i < 11; i++)
            {
                AlienList.Add(new Alien("Sprites/alien8", new Vector2((i * 60) + 17, 160), _projectileManager));
                AlienList.Add(new Alien("Sprites/alien11", new Vector2((i * 60) + 11, 220), _projectileManager));
                AlienList.Add(new Alien("Sprites/alien11", new Vector2((i * 60) + 11, 280), _projectileManager));
                AlienList.Add(new Alien("Sprites/alien12", new Vector2((i * 60) + 10, 340), _projectileManager));
                AlienList.Add(new Alien("Sprites/alien12", new Vector2((i * 60) + 10, 400), _projectileManager));
            }
        }

        public void HandleMovementAtBounds()
        {
            Alien lastAlien = AlienList.Last();
            Alien firstAlien = AlienList.First();

            if (lastAlien.Position.X + lastAlien.Texture.Width > GraphicsHelper.ScreenWidth || 
                firstAlien.Position.X <= 0)
            {
                foreach (Alien alien in AlienList)
                {
                    alien.ChangeVelocityX();
                    alien.AdvanceOneRow();
                }

                firstAlien.FireLaser();
            }


        }
    }
}
