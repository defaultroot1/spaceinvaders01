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
                        AudioManager.playAlienHitFX();
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
                    AudioManager.playPlayerHitFX();
                    gameManager.PlayerLives--;
                }
            }
        }

        public void HandlePlayerLasersHitBlocks(ProjectileManager projectileManager, ExplosionManager explosionManager, DestructibleBlockManager destructibleBlockManager)
        {
            for (int l = 0; l < projectileManager.PlayerLaserList.Count; l++)
            {
                for (int b = 0; b < destructibleBlockManager.Blocks.Count; b++)
                {
                    if (projectileManager.PlayerLaserList[l].GetBounds().Intersects(destructibleBlockManager.Blocks[b].GetBounds()))
                    {
                        explosionManager.explosionList.Add(new Explosion("Sprites/explosion", destructibleBlockManager.Blocks[b].Position));
                        projectileManager.PlayerLaserList.Remove(projectileManager.PlayerLaserList[l]);
                        destructibleBlockManager.Blocks.Remove(destructibleBlockManager.Blocks[b]);
                        break; // Stop a single laser from triggers more than 1 block destruction, which I think causes bound error
                    }
                }
            }
        }

        public void HandleAlienLasersHitBlocks(ProjectileManager projectileManager, ExplosionManager explosionManager, DestructibleBlockManager destructibleBlockManager)
        {
            for (int l = 0; l < projectileManager.AlienLaserList.Count; l++)
            {
                for (int b = 0; b < destructibleBlockManager.Blocks.Count; b++)
                {
                    if (projectileManager.AlienLaserList[l].GetBounds().Intersects(destructibleBlockManager.Blocks[b].GetBounds()))
                    {
                        explosionManager.explosionList.Add(new Explosion("Sprites/explosion", destructibleBlockManager.Blocks[b].Position));
                        projectileManager.AlienLaserList.Remove(projectileManager.AlienLaserList[l]);
                        destructibleBlockManager.Blocks.Remove(destructibleBlockManager.Blocks[b]);                      
                        break; // Stop a single laser from triggers more than 1 block destruction, which I think causes bound error
                    }
                }
            }
        }

        public void HandleAlienHitBlocks(AlienManager alienManager, ExplosionManager explosionManager, DestructibleBlockManager destructibleBlockManager)
        {
            for (int l = 0; l < alienManager.AlienList.Count; l++)
            {
                for (int b = 0; b < destructibleBlockManager.Blocks.Count; b++)
                {
                    if (alienManager.AlienList[l].GetBounds().Intersects(destructibleBlockManager.Blocks[b].GetBounds()))
                    {
                        explosionManager.explosionList.Add(new Explosion("Sprites/explosion", destructibleBlockManager.Blocks[b].Position));
                        destructibleBlockManager.Blocks.Remove(destructibleBlockManager.Blocks[b]);
                        break; // Stop a single laser from triggers more than 1 block destruction, which I think causes bound error
                    }
                }
            }
        }

    }
}
