using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using spaceinvaders01.Helpers;
using System.Collections.Generic;

namespace spaceinvaders01
{
    public class GameManager
    {
        private static GameManager instance;
        private PlayerShip _playerShip;
        private ProjectileManager _projectileManager;

        private GameManager()
        {
            _projectileManager = new ProjectileManager();
            _playerShip = new PlayerShip("Sprites/player", new Vector2(100, GraphicsHelper.ScreenHeight * 0.9f), _projectileManager);
            
            
        }

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public void Update(GameTime gameTime)
        {
            _playerShip.Update(gameTime);
            _projectileManager.Update(gameTime);
        }

        public void Draw()
        {
            _projectileManager.Draw();
            _playerShip.Draw();

        }
    }
}
