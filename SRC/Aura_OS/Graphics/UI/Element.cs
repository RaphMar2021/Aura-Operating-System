/*
* PROJECT:          Aura Operating System Development
* CONTENT:          Element base class
* PROGRAMMERS:      Valentin Charbonnier <valentinbreiz@gmail.com>
*/

using Cosmos.Core;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using Aura_OS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Aura_OS.System.Graphics.UI
{
    public class Element
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;

        public Element(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public virtual void Update()
        {
        }

        public bool IsInside(int x, int y)
        {
            return (x >= X && x <= X + Width) && (y >= Y && y <= Y + Height);
        }
    }
}