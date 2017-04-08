using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Filters
{
    class Wave : Filter
    {
        Random rnd = new Random();
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double m = 2 * Math.PI * y;

            int posX = Clamp((int)(x + 20 * Math.Sin(m / 60)), 0, sourceImage.Width - 1);
            int posY = Clamp((int)(y), 0, sourceImage.Height - 1);

            Color clr = sourceImage.GetPixel(posX, posY);
            return clr;
        }
    }

}
