using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Filters
{
    class SobelFilter : MatrixFilter
    {
        protected float[,] kernel1 = null;
        protected float[,] kernel2 = null;
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel1.GetLength(0) / 2;
            int radiusY = kernel1.GetLength(1) / 2;
            float resultR1 = 0;
            float resultG1 = 0;
            float resultB1 = 0;
            float resultR2 = 0;
            float resultG2 = 0;
            float resultB2 = 0;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color radiusColor = sourceImage.GetPixel(idX, idY);
                    resultR1 += radiusColor.R * kernel1[k + radiusX, l + radiusY];
                    resultG1 += radiusColor.G * kernel1[k + radiusX, l + radiusY];
                    resultB1 += radiusColor.B * kernel1[k + radiusX, l + radiusY];
                    resultR2 += radiusColor.R * kernel2[k + radiusX, l + radiusY];
                    resultG2 += radiusColor.G * kernel2[k + radiusX, l + radiusY];
                    resultB2 += radiusColor.B * kernel2[k + radiusX, l + radiusY];

                }
            return Color.FromArgb(
                Clamp((int)Math.Sqrt(resultR1*resultR1 + resultR2* resultR2), 0, 255),
                Clamp((int)Math.Sqrt(resultG1 * resultG1 + resultG2 * resultG2), 0, 255),
                Clamp((int)Math.Sqrt(resultB1 * resultB1 + resultB2 * resultB2), 0, 255)
                );
        }
        public SobelFilter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel1 = new float[sizeX, sizeY];
            kernel1[0, 0] = kernel1[0, 2] = -1;
            kernel1[0, 1] = -2;
            kernel1[2, 1] = 2;
            kernel1[2, 0] = kernel1[2, 2] = 1;
            kernel1[1, 0] = kernel1[1, 1] = kernel1[1, 2] = 0;

            kernel2 = new float[sizeX, sizeY];
            kernel2[0, 0] = kernel2[2, 0] = -1;
            kernel2[1, 0] = -2;
            kernel2[1, 2] = 2;
            kernel2[0, 2] = kernel2[2, 2] = 1;
            kernel2[0, 1] = kernel2[1, 1] = kernel2[2, 1] = 0;
        }
    }
}
