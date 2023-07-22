using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceinvaders01
{
    internal class CollisionManager
    {
        public void HandleLaserHitAlien(ProjectileManager projectileManager, AlienManager alienManager, GameManager gameManager)
        {
            for (int l = 0; l < projectileManager.PlayerLaserList.Count; l++)
            {
                Rectangle laserBounds = projectileManager.PlayerLaserList[l].GetBounds();

                for (int a = 0; a < alienManager.AlienList.Count; a++)
                {
                    Rectangle alienBounds = alienManager.AlienList[a].GetBounds();

                    if (laserBounds.Intersects(alienBounds))
                    {
                        gameManager.PlayerScore += alienManager.AlienList[a].Points;

                        if (a != 0 && alienManager.AlienList[a].ActiveShooter)
                        {
                            alienManager.AlienList[a - 1].MakeActiveShooter();
                        }
                        
                        projectileManager.PlayerLaserList.Remove(projectileManager.PlayerLaserList[l]);
                        alienManager.AlienList.Remove(alienManager.AlienList[a]);

                        

                    }
                }
                

                
            }
        }

        public void HandleLaserHitPlayer(ProjectileManager projectileManager, PlayerShip playerShip, GameManager gameManager)
        {
            for (int l = 0; l < projectileManager.AlienLaserList.Count; l++)
            {
                Rectangle laserBounds = projectileManager.AlienLaserList[l].GetBounds();
                Rectangle playerShipBounds = playerShip.GetBounds();

                if (laserBounds.Intersects(playerShipBounds))
                {
                    projectileManager.AlienLaserList.Remove(projectileManager.AlienLaserList[l]);
                    gameManager.PlayerLives--;
                }




            }
        }

    }
}
