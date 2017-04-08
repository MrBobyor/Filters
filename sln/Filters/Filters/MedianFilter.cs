using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Filters
{
    class MedianFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int kerX = 3;                          //изменить!
            int kerY = 3;
            int radiusX = kerX / 2;
            int radiusY = kerY / 2;

            List<double> valIntens = new List<double>();
            Color color = sourceImage.GetPixel(x, y);
           // Color[,] map = new Color[kerX, kerY];
            double median;

            for(int i = -radiusX; i <= radiusX; i++)
                for (int j = -radiusY; j <= radiusY; j++)
                {
                    int idX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color radiusColor = sourceImage.GetPixel(idX, idY);
                    double intens = 0.36 * radiusColor.R + 0.53 * radiusColor.G + 0.11 * radiusColor.B;
                    valIntens.Add(intens);
                }
            valIntens.Sort();
            median = valIntens[valIntens.Count / 2];
            
            for(int i = -radiusX; i <= radiusX; i++)
                for (int j = -radiusY; j <= radiusY; j++)
                {
                    int idX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color radiusColor = sourceImage.GetPixel(idX, idY);
                    double intens = 0.36 * radiusColor.R + 0.53 * radiusColor.G + 0.11 * radiusColor.B;
                    if(intens == median)
                    {
                        return radiusColor;
                        break;
                    }
                }
            return color;
        }
    }
}
