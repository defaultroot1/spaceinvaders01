using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceinvaders01
{
    internal class Alien : GameObject
    {
        public Alien(string spritePath, Vector2 position) : base(spritePath, position) 
        { 

        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw()
        {
            SpaceInvaders.spriteBatch.Draw(_texture, Position, Color.White);
        }

    }
}
