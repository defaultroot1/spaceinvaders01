using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceinvaders01
{
    internal class Explosion : GameObject
    {
        public Explosion(string spritePath, Vector2 position) : base(spritePath, position)
        {

        }

        public override void Draw()
        {
            SpaceInvaders.spriteBatch.Draw(Texture, Position, Color.Red);
        }
    }
}
