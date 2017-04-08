using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Filters
{
    abstract class MatMorphology : Filter
    {
        protected int[,] mask;
        protected double ind_m;
        protected abstract bool maskMap(int msk, double intens);
        protected abstract void ind_mask();
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int kerX = 3; 
            int kerY = 3;
            int radiusX = kerX / 2;
            int radiusY = kerY / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;

            ind_mask();
            for(int i = -radiusX; i <= radiusX; i++)
                for (int j = -radiusY; j <= radiusY; j++)
                { 
                    int idX = Clamp(x + i, 0, sourceImage.Width - radiusX);
                    int idY = Clamp(y + j, 0, sourceImage.Height - radiusY);
                    Color radiusColor = sourceImage.GetPixel(idX, idY);
                    int msk = mask[i + radiusY, j + radiusX];
                    double intens = 0.36 * radiusColor.R + 0.53 * radiusColor.G + 0.11 * radiusColor.B;
                    if (maskMap(msk, intens))
                    {
                        resultR = radiusColor.R;
                        resultG = radiusColor.G;
                        resultB = radiusColor.B;
                    }
                }
            return Color.FromArgb(Clamp((int)resultR, 0, 255),
                                  Clamp((int)resultG, 0, 255),
                                  Clamp((int)resultB, 0, 255));
        }
    }
}
