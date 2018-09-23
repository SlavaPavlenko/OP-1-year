using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ArrayVector: Vector
    {
        float[] coord;
        public float this[int index]
        {
            get
            {
                if (index >= 0 && index < coord.Length)
                    return coord[index];
                else throw new Exception("Индекс вне границ массива");
            }
            set
            {
                if (index >= 0 && index < coord.Length)
                    coord[index] = value;
                else throw new Exception("Индекс вне границ массива");
            }
        }
        public ArrayVector()
        {
            coord = new float[5];
        }
        public ArrayVector(int len)
        {
            if (len > 0)
            {
                coord = new float[len];
            }
            else
            {
                coord = new float[5];
                Console.WriteLine("Неверное значение. \nЗадано значение по-умолчанию 5.");
            }
        }
        public ArrayVector(ArrayVector vector)
        {
            coord = new float[vector.Length];
            for (int i = 0; i < vector.Length; i++)
                coord[i] = vector[i];
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(Length + " ");
            for (int i = 0; i < Length; i++)
                str.Append(coord[i] + " ");
            return str.ToString();
        }
        public int Length
        {
            get
            {
                return coord.Length;
            }
        }
        public float GetNorm()
        {
            float norm = 0;
            for (int i = 0; i < coord.Length; i++)
            {
                norm = norm + coord[i] * coord[i];
            }
            norm = (float)Math.Sqrt(norm);
            return norm;
        }
        public float SumPositivesFromChetIndex()
        {
            bool isFound = false;
            float sum = 0;
            for (int i = 0; i < coord.Length; i += 2)
            {
                if (coord[i] > 0)
                {
                    isFound = true;
                    sum = sum + coord[i];
                }
            }
            if (!isFound) throw new Exception();
            return sum;
        }
        public float SumLessFromNechetIndex()
        {
            bool isFound = false;
            float sum = 0;
            double average = 0;

            for (int i = 0; i < coord.Length; i++)
            {
                average += Math.Abs(coord[i]);
            }
            average /= coord.Length;

            for (int i = 1; i < coord.Length; i += 2)
            {
                if (coord[i] < average)
                {
                    isFound = true;
                    sum += coord[i];
                }
            }
            if (!isFound) throw new Exception();
            return sum;
        }
        public float MulChet()
        {
            bool isFound = false;
            float mul = 1;
            for (int i = 0; i < coord.Length; i++)
            {
                if ((coord[i] > 0) && (coord[i] % 2 == 0))
                {
                    isFound = true;
                    mul *= coord[i];
                }
            }
            if (!isFound) throw new Exception();
            return mul;
        }
        public float MulNechet()
        {
            bool isFound = false;
            float mul = 1;
            for (int i = 1; i < coord.Length; i += 2)
            {
                if (coord[i] % 3 != 0)
                {
                    isFound = true;
                    mul *= coord[i];
                }
            }
            if (!isFound) throw new Exception();
            return mul;
        }
        public void SortUp(int first, int last)
        {
            int i = first;
            int j = last;
            float temp;
            float average = coord[(last + first) / 2];
            while (i <= j)
            {
                while (coord[i] < average) i++;
                while (coord[j] > average) j--;
                if (i <= j)
                {
                    temp = coord[i];
                    coord[i] = coord[j];
                    coord[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < last) SortUp(i, last);
            if (j > first) SortUp(first, j);
        }
        public void SortDown(int first, int last)
        {
            Array.Reverse(coord);
        }
    }
}