using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace spaceinvaders01
{
    internal class CollisionManager
    {
        public void HandleLaserHitAlien(ProjectileManager projectileManager, AlienManager alienManager, GameManager gameManager, ExplosionManager explosionManager)
        {

            // Cycle through each player laser projectile
            for (int l = 0; l < projectileManager.PlayerLaserList.Count; l++)
            {
                Rectangle laserBounds = projectileManager.PlayerLaserList[l].GetBounds();

                // Cycle through each alien and compare bounds to the current projectile
                for (int a = 0; a < alienManager.AlienList.Count; a++)
                {
                    Rectangle alienBounds = alienManager.AlienList[a].GetBounds();

                    if (laserBounds.Intersects(alienBounds))
                    {
                        gameManager.PlayerScore += alienManager.AlienList[a].Points;
                        explosionManager.explosionList.Add(new Explosion("Sprites/explosion", alienManager.AlienList[a].Position));

                        // If not the last alien, the alien in the row above will be made active shooter
                        if (a != 0 && alienManager.AlienList[a].ActiveShooter)
                        {
                            alienManager.AlienList[a - 1].MakeActiveShooter();
                        }

                        projectileManager.PlayerLaserList.Remove(projectileManager.PlayerLaserList[l]);       
                        alienManager.AlienList.Remove(alienManager.AlienList[a]);

                        // For every x alien destroyed, increase the speed of the remaininng aliens
                        if(alienManager.AlienList.Count % 2 == 0)
                        {
                            foreach (Alien alien in alienManager.AlienList)
                            {
                                alien.IncreaseSpeed();
                            }
                        }
                    }
                }    
            }
        }

        public void HandleLaserHitPlayer(ProjectileManager projectileManager, PlayerShip playerShip, GameManager gameManager, ExplosionManager explosionManager)
        {
            // Cycle through each alien laser and see if it has hit the player ship
            for (int l = 0; l < projectileManager.AlienLaserList.Count; l++)
            {
                Rectangle laserBounds = projectileManager.AlienLaserList[l].GetBounds();
                Rectangle playerShipBounds = playerShip.GetBounds();

                if (laserBounds.Intersects(playerShipBounds))
                {
                    explosionManager.explosionList.Add(new Explosion("Sprites/explosion", playerShip.Position));
                    projectileManager.AlienLaserList.Remove(projectileManager.AlienLaserList[l]);
                    gameManager.PlayerLives--;
                }
            }
        }

    }
}
