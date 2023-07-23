using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceinvaders01
{
    internal class Bunker : GameObject
    {
        private ProjectileManager _projectileManager;

        public Bunker(string spritePath, Vector2 position, ProjectileManager projectileManager) : base(spritePath, position)
        {
            // Dependency injection to avoid passing projectileManager multiple times
            _projectileManager = projectileManager;
        }

    }
}
