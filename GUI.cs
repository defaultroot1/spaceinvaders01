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

        public void Draw(int playerScore, int playerLives, int highScore)
        {
            SpaceInvaders.spriteBatch.DrawString(_pixelFont, "SCORE", new Vector2(10, 10), Color.White);
            SpaceInvaders.spriteBatch.DrawString(_pixelFont, playerScore.ToString("D4"), new Vector2(20, 50), Color.White);
            SpaceInvaders.spriteBatch.DrawString(_pixelFont, "HI-SCORE", new Vector2(GraphicsHelper.ScreenWidth - 280, 10), Color.White);
            SpaceInvaders.spriteBatch.DrawString(_pixelFont, highScore.ToString("D4"), new Vector2(GraphicsHelper.ScreenWidth - 200, 50), Color.White);
            SpaceInvaders.spriteBatch.DrawString(_pixelFont, playerLives.ToString(), new Vector2(10,
                GraphicsHelper.ScreenHeight - 35), Color.White);

        }

        public void DrawGameOver()
        {
            string gameOverString = "GAME OVER";
            string pressSpaceString = "Press Enter To Try Again";
            Vector2 gameOverStringSize = _pixelFont.MeasureString(gameOverString);
            Vector2 pressSpaceStringSize = _pixelFont.MeasureString(pressSpaceString);

            SpaceInvaders.spriteBatch.DrawString(_pixelFont,
                gameOverString,
                new Vector2((GraphicsHelper.ScreenWidth / 2) - gameOverStringSize.X, (GraphicsHelper.ScreenHeight / 2) - gameOverStringSize.Y),
                Color.Red,
                0f,
                Vector2.Zero,
                2.0f,
                SpriteEffects.None,
                0f);
            SpaceInvaders.spriteBatch.DrawString(_pixelFont,
                pressSpaceString,
                new Vector2((GraphicsHelper.ScreenWidth / 2) - pressSpaceStringSize.X / 2, (GraphicsHelper.ScreenHeight / 2) + 100),
                Color.Red,
                0f,
                Vector2.Zero,
                1.0f,
                SpriteEffects.None,
                0f);
        }


    }
}
