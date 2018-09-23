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
            ArrayVector newVector;
            int length = vector1.VectorLen;
            if (length > vector2.VectorLen)
            {
                newVector = new ArrayVector(vector1);
                length = vector2.VectorLen;
            }
            else newVector = new ArrayVector(vector2);

            for (int i = 0; i < length; i++)
            {
                newVector.SetElement(vector1.GetElement(i) + vector2.GetElement(i), i);
            }
            return newVector;
        }
        public static double Scalar(ArrayVector vector1, ArrayVector vector2)
        {
            int scalar = 0;
            if (vector1.VectorLen != vector2.VectorLen) throw new Exception();
            for (int i = 0; i < vector1.VectorLen; i++)
            {
                scalar = scalar + vector1.GetElement(i) * vector2.GetElement(i);
            }
            return scalar;
        }
        public static ArrayVector NumberMul(ArrayVector vector, int number)
        {
            ArrayVector newVector = new ArrayVector(vector.VectorLen);
            for (int i = 0; i < vector.VectorLen; i++)
                newVector.SetElement(vector.GetElement(i) * number, i);

            return newVector;
        }
        public static double GetNorm(ArrayVector vector)
        {
            double norm = 0;
            for (int i = 0; i < vector.VectorLen; i++)
            {
                norm = norm + vector.GetElement(i) * vector.GetElement(i);
            }
            norm = Math.Sqrt(norm);
            return norm;
        }
    }
}
