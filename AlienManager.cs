using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceinvaders01
{
    internal class AlienManager
    {
        public List<Alien> AlienList { get; set; }

        public AlienManager()
        {
            AlienList = new List<Alien>();
            CreateSwarm();
        }

        public void Update(GameTime gameTime)
        {
            //
        }

        public void Draw()
        {
            foreach (Alien alien in AlienList)
            {
                alien.Draw();
            }
        }

        public void CreateSwarm()
        {
            if(AlienList.Count > 0)
            {
                AlienList.Clear();
            }

            for(int i = 0; i < 11; i++)
            {
                AlienList.Add(new Alien("Sprites/alien12", new Vector2((i * 60) + 10, 100)));
            }
        }
    }
}
