using Cosmos.Core;
using Cosmos.Core.Memory;
using Cosmos.System;
using System.Drawing;

namespace Aura_OS
{
    public class MemoryInfo : App
    {
        public MemoryInfo(int width, int height, int x = 0, int y = 0) : base("MemoryInfo", width, height, x, y)
        {

        }

        public override void UpdateApp()
        {
            Kernel.canvas.DrawString("Available RAM                = " + GCImplementation.GetAvailableRAM() + "MB", Kernel.font, Kernel.BlackColor, (int)x, (int)y);
            Kernel.canvas.DrawString("Used RAM                     = " + GCImplementation.GetUsedRAM() + "B" , Kernel.font, Kernel.BlackColor, (int)x, (int)(y + Kernel.font.Height));
            Kernel.canvas.DrawString("Small Allocated Object Count = " + HeapSmall.GetAllocatedObjectCount(), Kernel.font, Kernel.BlackColor, (int)x, (int)(y + 2 * Kernel.font.Height));
            Kernel.canvas.DrawString("Small Page Count             = " + RAT.GetPageCount((byte)RAT.PageType.HeapSmall), Kernel.font, Kernel.BlackColor, (int)x, (int)(y + 3 * Kernel.font.Height));
            Kernel.canvas.DrawString("Medium Page Count            = " + RAT.GetPageCount((byte)RAT.PageType.HeapMedium), Kernel.font, Kernel.BlackColor, (int)x, (int)(y + 4 * Kernel.font.Height));
            Kernel.canvas.DrawString("Large Page Count             = " + RAT.GetPageCount((byte)RAT.PageType.HeapLarge), Kernel.font, Kernel.BlackColor, (int)x, (int)(y + 5 * Kernel.font.Height));
            Kernel.canvas.DrawString("RAT Page Count               = " + RAT.GetPageCount((byte)RAT.PageType.RAT), Kernel.font, Kernel.BlackColor, (int)x, (int)(y + 6 * Kernel.font.Height));
            Kernel.canvas.DrawString("SMT Page Count               = " + RAT.GetPageCount((byte)RAT.PageType.SMT), Kernel.font, Kernel.BlackColor, (int)x, (int)(y + 7 * Kernel.font.Height));
            Kernel.canvas.DrawString("GC Managed Page Count        = " + RAT.GetPageCount((byte)RAT.PageType.SMT), Kernel.font, Kernel.BlackColor, (int)x, (int)(y + 8 * Kernel.font.Height));
            Kernel.canvas.DrawString("Free Count                   = " + Kernel.FreeCount, Kernel.font, Kernel.BlackColor, (int)x, (int)(y + 9 * Kernel.font.Height));
        }
    }
}
