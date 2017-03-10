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
            float k = 2.0f;
            Color sourceColor = sourceImage.GetPixel(x, y);

            byte intensity = (byte)(0.36f * sourceColor.R + 0.53f * sourceColor.G + 0.11f * sourceColor.B);
            byte clrR = (byte)(intensity + 2.0f * k);
            byte clrG = (byte)(intensity + 0.5f * k);
            byte clrB = (byte)(intensity - 1.0f * k);
            Color resultColor = Color.FromArgb(Clamp(clrR, 0, 255), Clamp(clrG, 0, 255), Clamp(clrB, 0, 255));
            return resultColor;
        }
    }
}
