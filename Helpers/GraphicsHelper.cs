﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceinvaders01.Helpers
{
    public static class GraphicsHelper
    {
        public static int ScreenWidth { get; private set; }
        public static int ScreenHeight { get; private set; }
        
        public static void Init(int width, int height)
        {
            ScreenWidth = width;
            ScreenHeight = height;
        }
    }
}
