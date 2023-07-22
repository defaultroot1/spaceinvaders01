using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using spaceinvaders01.Helpers;

namespace spaceinvaders01
{
    internal class ProjectileManager
    {
        public List<PlayerLaser> PlayerLaserList;
        public List<AlienLaser> AlienLaserList;

        public ProjectileManager()
        {
            PlayerLaserList = new List<PlayerLaser>();
            AlienLaserList = new List<AlienLaser>();
        }

        public void Update(GameTime gameTime)
        {
            UpdatePlayerLasers(gameTime);
            UpdateAlienLasers(gameTime);
        }

        public void Draw()
        {
            foreach (PlayerLaser playerLaser in PlayerLaserList)
            {
                playerLaser.Draw();
            }

            foreach (AlienLaser alienLaser in AlienLaserList)
            {
                alienLaser.Draw();
            }

        }
        
        public void UpdatePlayerLasers(GameTime gameTime)
        {
            var delta = gameTime.ElapsedGameTime.TotalSeconds;

            for (int i = 0; i < PlayerLaserList.Count; i++)
            {
                PlayerLaser laser = PlayerLaserList[i];

                laser.Position = new Vector2(laser.Position.X,
                    laser.Position.Y + laser.Velocity.Y * laser.Speed);

                // Destroy object if it leaves the play area (top of screen in this case)
                if (laser.Position.Y < 0)
                {
                    PlayerLaserList.Remove(laser);
                }
            }
        }

        public void UpdateAlienLasers(GameTime gameTime)
        {
            var delta = gameTime.ElapsedGameTime.TotalSeconds;

            for (int i = 0; i < AlienLaserList.Count; i++)
            {
                AlienLaser laser = AlienLaserList[i];

                laser.Position = new Vector2(laser.Position.X,
                    laser.Position.Y + laser.Velocity.Y * laser.Speed);

                // Destroy object if it leaves the play area (top of screen in this case)
                if (laser.Position.Y > GraphicsHelper.ScreenHeight)
                {
                    AlienLaserList.Remove(laser);
                }
            }
        }


    }
}
