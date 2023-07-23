using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using spaceinvaders01.Helpers;
using System;
using System.Collections.Generic;

namespace spaceinvaders01
{
    public class GameManager
    {
        public enum GameState {
            Playing,
            GameOver
            }
        
        public GameState gameState = GameState.Playing;
        private static GameManager instance;
        private PlayerShip _playerShip;
        private ProjectileManager _projectileManager;
        private AlienManager _alienManager;
        private CollisionManager _collisionManager;
        private GUI _gui;
        public int PlayerLives { get; set; } = 3;
        public int PlayerScore { get; set; } = 0;
        public int HighScore {  get; set; } = 0;

        private GameManager()
        {
            _projectileManager = new ProjectileManager();
            _alienManager = new AlienManager(_projectileManager);
            _playerShip = new PlayerShip("Sprites/player", new Vector2(100, GraphicsHelper.ScreenHeight * 0.9f), _projectileManager);
            _collisionManager = new CollisionManager();
            _gui = new GUI();
        }

        // Method to instantiante a single instance of GameManager (singleton)
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
            if (gameState == GameState.Playing)
            {
                _playerShip.Update(gameTime);
                _alienManager.Update(gameTime);
                _projectileManager.Update(gameTime);
                _collisionManager.HandleLaserHitAlien(_projectileManager, _alienManager, this);
                _collisionManager.HandleLaserHitPlayer(_projectileManager, _playerShip, this);

                if (PlayerLives < 1)
                {
                    gameState = GameState.GameOver;
                    
                }
                UpdateHighScore();
            }

            if (gameState == GameState.GameOver)
            {
                CheckForRestart();
            }
        }

        public void Draw()
        {
            _projectileManager.Draw();
            _alienManager.Draw();
            _playerShip.Draw();
            _gui.Draw(PlayerScore, PlayerLives, HighScore);

            if(gameState == GameState.GameOver)
            {
                _gui.DrawGameOver();
            }

        }

        public void ChangeGameState()
        {
            if (gameState == GameState.GameOver)
                gameState = GameState.Playing;
            else if (gameState == GameState.Playing)
                gameState = GameState.GameOver;
        }

        public void UpdateHighScore()
        {
            if (PlayerScore > HighScore)
            {
                HighScore = PlayerScore;
            }
        }

        public void CheckForRestart()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Enter)) 
            {
                ResetGame();
                gameState = GameState.Playing;
                
            }
        }

        public void ResetGame()
        {
            _projectileManager = new ProjectileManager();
            _alienManager = new AlienManager(_projectileManager);
            _playerShip = new PlayerShip("Sprites/player", new Vector2(100, GraphicsHelper.ScreenHeight * 0.9f), _projectileManager);
            PlayerLives = 3;
            PlayerScore = 0;
        }
    }
}
