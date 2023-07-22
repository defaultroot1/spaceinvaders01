using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace spaceinvaders01
{
    internal class ProjectileManager
    {
        public List<PlayerLaser> LaserList;

        public ProjectileManager()
        {
            LaserList = new List<PlayerLaser>();
        }

        public void Update(GameTime gameTime)
        {
            var delta = gameTime.ElapsedGameTime.TotalSeconds;

            for (int i = 0; i < LaserList.Count; i++)
            {
                PlayerLaser laser = LaserList[i];

                laser.Position = new Vector2(laser.Position.X,
                    laser.Position.Y + laser.Velocity.Y * laser.Speed);

                if (laser.Position.Y < 0)
                {
                    LaserList.Remove(laser);
                }
            }
        }

        public void Draw()
        {
            foreach (PlayerLaser laser in LaserList)
            {
                laser.Draw();
            }

            Debug.WriteLine("LaserList count: " + LaserList.Count);
        }


    }
}
