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

            List<double> valColor = new List<double>();
            Dictionary<double, Color> map = new Dictionary<double, Color>();
            double median;

            for(int i = -radiusX; i <= radiusX; i++)
                for (int j = -radiusY; j <= radiusY; j++)
                {
                    int idX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color radiusColor = sourceImage.GetPixel(idX, idY);
                    double intens = 0.36 * radiusColor.R + 0.53 * radiusColor.G + 0.11 * radiusColor.B;
                    if (!valColor.Contains(intens))
                    {
                        map.Add(intens, radiusColor);
                        valColor.Add(intens);
                    }
                }
            valColor.Sort();
            median = valColor[valColor.Count / 2];
            return map[median];
        }
    }
}
