using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceinvaders01
{
    internal class ExplosionManager
    {
        public List<Explosion> explosionList { get; set; }

        public ExplosionManager()
        {
            explosionList = new List<Explosion>();
        }

        public void Draw()
        {
            foreach(Explosion explosion in explosionList)
            {
                explosion.Draw();
            }
            explosionList.Clear();
        }
    }
}
