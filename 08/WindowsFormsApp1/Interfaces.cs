using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    interface Vector : IComparable
    {
        float this[int index] {get; set; }
        int Length { get; }
        float GetNorm();
    }
}
