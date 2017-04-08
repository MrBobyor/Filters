using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Filters
{
    class GrayWorld : Filter
    {
        Color medium;
        double mediumAll;
        public GrayWorld(Bitmap sourceImage)
        {
            double medR = 0;
            double medG = 0;
            double medB = 0;
            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    medR += sourceColor.R;
                    medG += sourceColor.G;
                    medB += sourceColor.B;
                }
            double area = sourceImage.Width * sourceImage.Height;
            medR = medR / area;
            medG = medG / area;
            medB = medB / area;
            medium = Color.FromArgb(Clamp((int)medR, 0, 255), Clamp((int)medG, 0, 255), Clamp((int)medB, 0, 255));
            mediumAll = (medium.R + medium.G + medium.B) / 3;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int resultR = Clamp((int)(sourceColor.R * (mediumAll / medium.R)), 0, 255);
            int resultG = Clamp((int)(sourceColor.G * (mediumAll / medium.G)), 0, 255);
            int resultB = Clamp((int)(sourceColor.B * (mediumAll / medium.B)), 0, 255);
            Color resultColor = Color.FromArgb(resultR, resultG, resultB);
            return resultColor;
        }
    }
}
