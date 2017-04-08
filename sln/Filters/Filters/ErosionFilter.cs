using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filters
{
    class ErosionFilter : MatMorphology
    {
        protected ErosionFilter() { }

        public ErosionFilter(int[,] mask)
        {
            this.mask = mask;
        }

        protected override void ind_mask()
        {
            ind_m = 0;
        }

        protected override bool maskMap(int msk, double intens)
        {
            if ((msk != 0) && (intens >= ind_m))
            {
                ind_m = intens;
                return true;
            }
            return false;
        }
    }

    class ErosionMask : ErosionFilter
    {
        public ErosionMask()
        {
            int sizeX = 3;
            int sizeY = 3;
            mask = new int[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                    mask[i, j] = 1;
        }
    }
}
