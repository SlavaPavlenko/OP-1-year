using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ArrayVector
    {
        int[] coord;
        public ArrayVector()
        {
            coord = new int[5];
        }
        public ArrayVector(int len)
        {
            if (len > 0)
            {
                coord = new int[len];
            }
            else
            {
                coord = new int[5];
                Console.WriteLine("Неверное значение. Задано значение по-умолчанию 5.");
            }
        }
        public ArrayVector(ArrayVector vector)
        {
            coord = new int[vector.VectorLen];
            for (int i = 0; i < vector.VectorLen; i++)
                coord[i] = vector.GetElement(i);
        }
        public void SetElement(int value, int id)
        {
            if ((id >= 0) && (id < coord.Length))
            {
                coord[id] = value;
            }
            else
            {
                Console.WriteLine("Неверный индекс элемента");
            }
        }
        public int GetElement(int id)
        {
            return coord[id];
        }
        public int VectorLen
        {
            get
            {
                return coord.Length;
            }
        }
        public double GetNorm()
        {
            double norm = 0;
            for (int i = 0; i < coord.Length; i++)
            {
                norm = norm + coord[i] * coord[i];
            }
            norm = Math.Sqrt(norm);
            return norm;
        }
        public int SumPositivesFromChetIndex()
        {
            bool isFound = false;
            int sum = 0;
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
        public int SumLessFromNechetIndex()
        {
            bool isFound = false;
            int sum = 0;
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
        public int MulChet()
        {
            bool isFound = false;
            int mul = 1;
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
        public int MulNechet()
        {
            bool isFound = false;
            int mul = 1;
            for (int i = 1; i < coord.Length; i+=2)
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
            int temp;
            int average = coord[(last + first) / 2];
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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа предназначена для работы с векторами");
            Console.Write("Кол-во координат вектора: ");
            int CoordNum = Convert.ToInt16(Console.ReadLine());
            ArrayVector vector = new ArrayVector(CoordNum);

            int value;
            Console.WriteLine("\nВвод значений координат вектора");
            for (int i = 0; i < vector.VectorLen; i++)
            {
                Console.Write("Координата №" + i + ": ");
                value = Convert.ToInt16(Console.ReadLine());
                vector.SetElement(value, i);
            }
            Console.Write("Координаты вектора:");
            for (int i = 0; i < vector.VectorLen; i++)
            {
                Console.Write(vector.GetElement(i) + "   ");
            }

            Console.WriteLine("\nМодуль вектора: " + vector.GetNorm());
            try
            {
                Console.WriteLine("Сумма положительных элементов с четными номерами: " + vector.SumPositivesFromChetIndex());
            }
            catch {
                Console.WriteLine("В векторе не найдены положительные элементы с четными номерами");
            }

            try
            {
                Console.WriteLine("Сумма элементов с четными номерами, меньших среднего значения модуля суммы: " + vector.SumLessFromNechetIndex());
            }
            catch {
                Console.WriteLine("В векторе не найдены элементы с четными номерами, меньших среднего значения модуля суммы");
            }

            try
            {
                Console.WriteLine("Произведение четных положительных элементов: " + vector.MulChet());
            }
            catch
            {
                Console.WriteLine("В векторе не найдено четных положительных элементов");
            }

            try
            {
                Console.WriteLine("Произведение нечетных элементов, не делящихся на 3: " + vector.MulNechet());
            }
            catch
            {
                Console.WriteLine("В векторе не найдено нечетных элементов, не делящихся на 3");
            }

            Console.Write("Элементы, отсортированные по возрастанию:");
            vector.SortUp(0, vector.VectorLen - 1);
            for (int i = 0; i < vector.VectorLen; i++)
            {
                Console.Write(vector.GetElement(i) + "   ");
            }

            Console.Write("\nЭлементы, отсортированные по убыванию:");
            vector.SortDown(0, vector.VectorLen - 1);
            for (int i = 0; i < vector.VectorLen; i++)
            {
                Console.Write(vector.GetElement(i) + "   ");
            }
            Console.ReadLine();
        }
    }
}
