using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Filters
{
    class Glass : Filter
    {
        Random rnd = new Random();
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
           // Console.WriteLine(rnd.Next(1000));
            double rand1, rand2;
            rand1 = Convert.ToDouble(rnd.Next(1000)) / 1000;
            rand2 = Convert.ToDouble(rnd.Next(1000)) / 1000;
            int posX = Clamp((int)(x + (rand1 - 0.5f) * 10), 0, sourceImage.Width - 1);
            int posY = Clamp((int)(y + (rand2 - 0.5f) * 10), 0, sourceImage.Height - 1);

            if (posX > 0 && posY > 0 && posX < sourceImage.Width && posY < sourceImage.Height)
            {
                Color clr = sourceImage.GetPixel(posX, posY);
                return clr;
            }
            else
            {
                Color clr = Color.Black;
                return clr;
            }    
        }
    }
}
