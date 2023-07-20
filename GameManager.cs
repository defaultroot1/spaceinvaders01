using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using spaceinvaders01.Helpers;

namespace spaceinvaders01
{
    public class GameManager
    {
        private static GameManager instance;
        private PlayerShip _playerShip;
        private PlayerLaser _playerLaser;

        private GameManager()
        {
            _playerShip = new PlayerShip("Sprites/player", new Vector2(100, GraphicsHelper.ScreenHeight * 0.9f));
            _playerLaser = new PlayerLaser("Sprites/laser", new Vector2(100,100));
            
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
            _playerLaser.Update(gameTime);
        }

        public void Draw()
        {
            _playerShip.Draw(SpaceInvaders.spriteBatch);
            _playerLaser.Draw(SpaceInvaders.spriteBatch);
        }
    }
}
