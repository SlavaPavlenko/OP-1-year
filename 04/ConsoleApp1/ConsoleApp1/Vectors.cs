using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Vectors
    {
        public static Vector Sum(Vector vector1, Vector vector2)
        {
            if (vector1.Length != vector2.Length) throw new FormatException("Векторы имеют разную длину");
            ArrayVector newVector = new ArrayVector(vector1.Length);
            for (int i = 0; i < vector1.Length; i++)
            {
                newVector[i] = (vector1[i] + vector2[i]);
            }
            return (Vector)newVector;
        }
        public static double Scalar(Vector vector1, Vector vector2)
        {
            float scalar = 0;
            if (vector1.Length != vector2.Length) throw new FormatException("Векторы имеют разную длину");
            for (int i = 0; i < vector1.Length; i++)
            {
                scalar = scalar + vector1[i] * vector2[i];
            }
            return scalar;
        }
        public static Vector NumberMul(Vector vector, int number)
        {
            ArrayVector newVector = new ArrayVector(vector.Length);
            for (int i = 0; i < vector.Length; i++)
                newVector[i] = (vector[i] * number);

            return (Vector)newVector;
        }
        public static double GetNorm(Vector vector)
        {
            return vector.GetNorm();
        }
    }
}
