using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Filters
{
    class LinearStretching : Filter
    {
        Color Minclr;
        double tmp;
        public LinearStretching(Bitmap sourceImage)
        {
            Color minclr = Color.White, maxclr;
            double maxIntens = 0, minIntens = 255;
            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    double intensity = 0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B;
                    if (intensity >= maxIntens)
                    {
                        maxIntens = intensity;
                        maxclr = sourceColor;
                    }
                    if (intensity <= minIntens)
                    {
                        minIntens = intensity;
                        minclr = sourceColor;
                    }
                }
            tmp = (255) / (maxIntens - minIntens);
            Minclr = minclr;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int resultR = Clamp((int)((sourceColor.R - Minclr.R) * tmp), 0, 255);
            int resultG = Clamp((int)((sourceColor.G - Minclr.G) * tmp), 0, 255);
            int resultB = Clamp((int)((sourceColor.B - Minclr.B) * tmp), 0, 255);
            Color resultColor = Color.FromArgb(resultR, resultG, resultB);
            return resultColor;
        }
    }
}
