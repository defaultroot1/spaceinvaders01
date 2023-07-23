using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using spaceinvaders01.Helpers;

namespace spaceinvaders01
{
    internal class DestructibleBlockManager
    {
        public List<DestructableBlock> Blocks { get; set; }

        public DestructibleBlockManager()
        {
            int offset = 16;
            Blocks = new List<DestructableBlock>();
            InitialiseBunkers(new Vector2(GraphicsHelper.ScreenWidth * 0.20f - offset, 700));
            InitialiseBunkers(new Vector2(GraphicsHelper.ScreenWidth * 0.50f - offset, 700));
            InitialiseBunkers(new Vector2(GraphicsHelper.ScreenWidth * 0.80f - offset, 700));

            InitialiseGround();

        }

        public void InitialiseBunkers(Vector2 position)
        {
            for (int i = 0; i < 10; i++)
            {
                Blocks.Add(new DestructableBlock(new Vector2(position.X + (i * 8), position.Y)));
            }
            for (int i = 0; i < 12; i++)
            {
                Blocks.Add(new DestructableBlock(new Vector2(position.X + (i * 8) - 8, position.Y + 8)));
            }
            for (int i = 0; i < 14; i++)
            {
                Blocks.Add(new DestructableBlock(new Vector2(position.X + (i * 8) - 16, position.Y + 8 * 2)));
            }
            for (int i = 0; i < 16; i++)
            {
                Blocks.Add(new DestructableBlock(new Vector2(position.X + (i * 8) - 24, position.Y + 8 * 3 )));
            }
            for (int i = 0; i < 16; i++)
            {
                Blocks.Add(new DestructableBlock(new Vector2(position.X + (i * 8) - 24, position.Y + 8 * 4)));
            }
            for (int i = 0; i < 16; i++)
            {
                Blocks.Add(new DestructableBlock(new Vector2(position.X + (i * 8) - 24, position.Y + 8 * 5)));
            }
            for (int i = 0; i < 16; i++)
            {
                Blocks.Add(new DestructableBlock(new Vector2(position.X + (i * 8) - 24, position.Y + 8 * 6)));
            }
        }

        public void InitialiseGround()
        {
            for (int i = 0; i < GraphicsHelper.ScreenWidth; i++)
            {
                if(i % 8 == 0)
                {
                    Blocks.Add(new DestructableBlock(new Vector2(i, 850)));
                }
            }
        }

        public void Draw()
        {
            foreach(DestructableBlock block in Blocks)
            {
                block.Draw();
            }
        }
    }
}
