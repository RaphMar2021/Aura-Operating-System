﻿/*
* PROJECT:          Aura Operating System Development
* CONTENT:          VBE VESA Graphics
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

namespace Aura_OS.System.Graphics
{
    public class GUI
    {
        public void WriteByte(char ch, int mX, int mY, Color color)
        {
            Kernel.canvas.DrawChar((char)ch, Kernel.font, color, mX, mY);
        }

        public void SetCursorPos(int mX, int mY)
        {
            if (Kernel.console.CursorVisible)
            {
                Kernel.canvas.DrawFilledRectangle(Kernel.console.ForegroundColor, (int)Kernel.console.x + mX * Kernel.font.Width,
                    (int)Kernel.console.y + mY * Kernel.font.Height + Kernel.font.Height, 8, 4);
            }
        }
    }
}