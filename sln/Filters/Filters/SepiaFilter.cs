using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Filters
{
    class SepiaFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float k = 10;
            Color sourceColor = sourceImage.GetPixel(x, y);

            float intensity = 0.36f * sourceColor.R + 0.53f * sourceColor.G + 0.11f * sourceColor.B;
            float clrR = intensity + 2.0f * k;
            float clrG = intensity + 0.5f * k;
            float clrB = intensity - 1.0f * k;
            Color resultColor = Color.FromArgb(Clamp((int)clrR, 0, 255), Clamp((int)clrG, 0, 255), Clamp((int)clrB, 0, 255));
            return resultColor;
        }
    }
}
