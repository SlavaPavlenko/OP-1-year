using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class class_for_IComparer : IComparer<Vector>
    {
        public int Compare(Vector vec1, Vector vec2)
        {
            if (vec1.GetNorm() < vec2.GetNorm()) return -1;
            if (vec1.GetNorm() == vec2.GetNorm()) return 0;
            if (vec1.GetNorm() > vec2.GetNorm()) return 1;
            return 0;
        }
    }
}
