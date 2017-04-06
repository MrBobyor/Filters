using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Filters
{
    class SobelFilter : MatrixFilter
    {
        float[,] kernel1 = null;
        float[,] kernel2 = null;
        //static float[,] SobelX = new float[3, 3] {{-1, 0, 1}, {-2, 0, 2}, {-1, 0, 1}};
        //static float[,] SobelY = new float[3, 3] {{ 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 }};
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR1 = 0;
            float resultG1= 0;
            float resultB1 = 0;
            float resultR2 = 0;
            float resultG2 = 0;
            float resultB2 = 0;

            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + 1, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR1 += neighborColor.R * kernel1[k + radiusX, l + radiusY];
                    resultG1 += neighborColor.G * kernel1[k + radiusX, l + radiusY];
                    resultB1 += neighborColor.B * kernel1[k + radiusX, l + radiusY];
                    resultR2 += neighborColor.R * kernel2[k + radiusX, l + radiusY];
                    resultG2 += neighborColor.G * kernel2[k + radiusX, l + radiusY];
                    resultB2 += neighborColor.B * kernel2[k + radiusX, l + radiusY];
                }
            return Color.FromArgb(Clamp((int)Math.Sqrt(resultR1 * resultR1 + resultR2 * resultR2), 0, 255), 
                                  Clamp((int)Math.Sqrt(resultG1 * resultG1 + resultG2 * resultG2), 0, 255), 
                                  Clamp((int)Math.Sqrt(resultB1 * resultB1 + resultB2 * resultB2), 0, 255));
        }
        /*public SobelFilter()
        {
            float[,] kernel1 = new float[3, 3] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            float[,] kernel2 = new float[3, 3] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };
        }*/  
        public SobelFilter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel1 = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                    kernel1[i,j] = 0;
            kernel1[0,0] = -1;
            kernel1[0,2] = 1;
            kernel1[1, 0] = -2;
            kernel1[1, 2] = 2;
            kernel1[2, 0] = -1;
            kernel1[2, 2] = 1;

            kernel2 = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                    kernel2[i, j] = 0;
            kernel2[0, 0] = 1;
            kernel2[0, 1] = 2;
            kernel2[0, 2] = 1;
            kernel2[2, 0] = -1;
            kernel2[2, 1] = -2;
            kernel2[2, 2] = -1;
        }      
    }
}
