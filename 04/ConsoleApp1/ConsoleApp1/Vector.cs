using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface Vector
    {
        float this[int index] {get; set; }
        int Length { get; }
        float GetNorm();
    }
}
