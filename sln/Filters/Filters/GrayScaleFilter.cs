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
    class GrayScaleFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            byte clr = (byte)(sourceColor.R * 0.36f + sourceColor.G * 0.53f + sourceColor.B * 0.11f);
            Color resultColor = Color.FromArgb(clr, clr, clr);
            return resultColor;
        }
    }
}
