using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace spaceinvaders01
{
    /// <summary>
    /// GameObject is the base class for most other objects in the game to inherit from, providing common 
    /// functionality, such as assignment of texture and bounds for collision detection.
    /// </summary>
    internal class GameObject
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        protected int Rows { get; set; }
        protected int Columns { get; set; }
        protected int _currentFrame;
        protected int _totalFrames;
        protected float _animationTimer = 0f;
        protected float _animationSpeed = 1f;
        public int Width { get; set; }
        public int Height { get; set; }

        /// <summary>
        /// Constructor for static sprite
        /// </summary>
        /// <param name="spritePath"></param>
        /// <param name="position"></param>
        public GameObject(string spritePath, Vector2 position)
        {
            Texture = SpaceInvaders.contentManager.Load<Texture2D>(spritePath);
            Position = position;
            Width = Texture.Width;
            Height = Texture.Height;
        }

        /// <summary>
        /// Constructor for animated sprite
        /// </summary>
        /// <param name="spritePath"></param>
        /// <param name="position"></param>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public GameObject(string spritePath, Vector2 position, int rows, int columns, float animationSpeed)
        {
            Texture = SpaceInvaders.contentManager.Load<Texture2D>(spritePath);
            Position = position;
            _animationSpeed = animationSpeed;
            Rows = rows;
            Columns = columns;
            _currentFrame = 0;
            _totalFrames = Rows * Columns;
            Width = Texture.Width / Columns;
            Height = Texture.Height / Rows;

        }

        /// <summary>
        /// Returns a Retangle of the object's bounds for collision detection.
        /// </summary>
        /// <returns></returns>
        public Rectangle GetBounds()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

        }

        public virtual void Update(GameTime gameTime)
        {
            // Update logic
        }

        public virtual void Draw()
        {
            // Draw object
        }

        public void UpdateAnimation(GameTime gameTime)
        {
            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float timePerFrame = 1f / _animationSpeed;

            _animationTimer += elapsedSeconds;

            if (_animationTimer >= timePerFrame)
            {
                _currentFrame++;
                if (_currentFrame == _totalFrames)
                {
                    _currentFrame = 0;
                }

                _animationTimer -= timePerFrame;
            }

        }

        public void DrawAnimated()
        {
            //int width = Texture.Width / Columns; // Get width of each animation frame
            //int height = Texture.Height / Rows; // Get height of each animation frame
            int row = _currentFrame / Columns;
            int column = _currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(Width * column, Height * row, Width, Height);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

            SpaceInvaders.spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
