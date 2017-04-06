using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Filters
{
    class Erossion : MatrixFilter
    {
        public Erossion()
        {
            int sizeX = 3;
            int sizeY = 3;

        }
        /*protected override Color calculateNewPixelColor(Bitmap sourceMap, int x, int y)
       {
          int radiusX = 2;
           int radiusY = 2;

           Color[] arr = new Color[25];
           int i = 0;
           for (int l = -radiusY; l <= radiusY; l++)
               for (int k = -radiusX; k <= radiusX; k++)
               {
                   int idX = Clamp(x + k, 0, sourceMap.Width - 1);
                   int idY = Clamp(y + l, 0, sourceMap.Height - 1);
                   arr[i] = sourceMap.GetPixel(idX, idY);
                   i++;
               }

           IComparer com = new ColorComparer();
           Array.Sort(arr, com); 
           return arr[0];
       }*/
    }
}
