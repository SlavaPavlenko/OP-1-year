using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class class_for_IComparer : IComparer<Vector>
    {
        public int Compare(Vector vector1, Vector vector2)
        {
            int length = vector1.Length - vector2.Length;
            return length;
        }
    }
}
