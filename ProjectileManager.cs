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

<<<<<<< HEAD
                // Destroy object if it leaves the play area (top of screen in this case)
=======
>>>>>>> d2b5cb01a4eb2a2bcd3d8d0b842c2a72f6efb2fd
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

<<<<<<< HEAD
=======
            Debug.WriteLine("LaserList count: " + LaserList.Count);
>>>>>>> d2b5cb01a4eb2a2bcd3d8d0b842c2a72f6efb2fd
        }


    }
}
