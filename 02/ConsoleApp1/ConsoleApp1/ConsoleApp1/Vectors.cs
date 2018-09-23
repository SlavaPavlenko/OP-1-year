using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Vectors
    {
        public static ArrayVector Sum(ArrayVector vector1, ArrayVector vector2)
        {
            if (vector1.Length != vector2.Length) throw new FormatException("Векторы имеют разную длину");
            ArrayVector newVector = new ArrayVector(vector1.Length);
            for (int i = 0; i < vector1.Length; i++)
            {
                newVector[i] = vector1[i] + vector2[i];
            }
            return newVector;
        }
        public static float Scalar(ArrayVector vector1, ArrayVector vector2)
        {
            float scalar = 0;
            if (vector1.Length != vector2.Length) throw new FormatException("Векторы имеют разную длину");
            for (int i = 0; i < vector1.Length; i++)
            {
                scalar = scalar + vector1[i] * vector2[i];
            }
            return scalar;
        }
        public static ArrayVector NumberMul(ArrayVector vector, int number)
        {
            ArrayVector newVector = new ArrayVector(vector.Length);
            for (int i = 0; i < vector.Length; i++)
                newVector[i] = vector[i] * number;

            return newVector;
        }
        public static float GetNorm(ArrayVector vector)
        {
            float norm = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                norm = norm + vector[i] * vector[i];
            }
            norm = (float)Math.Sqrt(norm);
            return norm;
        }
    }
}
