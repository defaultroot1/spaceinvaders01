using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using spaceinvaders01.Helpers;

namespace spaceinvaders01
{
    internal class GUI
    {
        private SpriteFont _pixelFont;

        public GUI()
        {
            _pixelFont = SpaceInvaders.contentManager.Load<SpriteFont>("Fonts/pixelFont");
        }

        public void Draw(int playerScore, int playerLives)
        {
            SpaceInvaders.spriteBatch.DrawString(_pixelFont, "SCORE", new Vector2(10, 10), Color.White);
            SpaceInvaders.spriteBatch.DrawString(_pixelFont, playerScore.ToString("D4"), new Vector2(20, 50), Color.White);
            SpaceInvaders.spriteBatch.DrawString(_pixelFont, playerLives.ToString(), new Vector2(10,
                GraphicsHelper.ScreenHeight - 50), Color.White);
        }


    }
}
