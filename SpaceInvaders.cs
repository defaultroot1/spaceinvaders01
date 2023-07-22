using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using spaceinvaders01.Helpers;

namespace spaceinvaders01
{
    public class SpaceInvaders : Game
    {
        private GraphicsDeviceManager _graphics;
        public static SpriteBatch spriteBatch; // Spritebatch made public static for easy access
        private GameManager _gameManager;
        public static ContentManager contentManager; // ContentManager made public static for easy access

        public SpaceInvaders()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;

            contentManager = Content; // Initialise contentManager with Game.Content

        }

        protected override void Initialize()
        {
            // Original Space Invaders resolution. Allegedly. 
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 896;
            _graphics.ApplyChanges();

            // Initialise the GraphicsHelper static class with screen width and height
            GraphicsHelper.Init(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create singleton instance of GameManager
            _gameManager = GameManager.Instance;

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // GameManager takes care of Update() methods for various classes
            _gameManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            // GameManager takes care of Draw() methods for various classes
            _gameManager.Draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}