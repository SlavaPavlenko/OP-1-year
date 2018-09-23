using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int partition(Vector[] vectors, int start, int end)
        {
            Vector temp;
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (vectors[i].Length < vectors[end].Length)
                {
                    temp = vectors[marker];
                    vectors[marker] = vectors[i];
                    vectors[i] = temp;
                    marker += 1;
                }
            }
            temp = vectors[marker];
            vectors[marker] = vectors[end];
            vectors[end] = temp;
            return marker;
        }
        private static void QS(Vector[] vectors, int start, int end)
        {
            if (start < end)
            {
                int marker = partition(vectors, start, end);
                QS(vectors, start, marker - 1);
                QS(vectors, marker + 1, end);
            }
        }
        private static int ReadInt(int left, int right)
        {
            int num = 0;
            bool isExit = false;
            while (!isExit)
            {
                bool tmp = int.TryParse(Console.ReadLine(), out num);
                if (!tmp || num < left || num > right)
                {
                    Console.WriteLine("Неверное значение");
                }
                else
                {
                    isExit = true;
                }
            }
            return num;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Программа предназначена для работы с векторами");
            Console.WriteLine("Введите кол-во векторов");
            int vector_num = ReadInt(1, int.MaxValue);
            int current = 0;
            Vector[] vectors = new Vector[vector_num];
            bool isExit = false;
            while (!isExit)
            {
                try
                {
                    Console.WriteLine("1 - добавить ArrayVector");
                    Console.WriteLine("2 - добавить LinkedListVector");
                    Console.WriteLine("3 - вывести массив векторов");
                    Console.WriteLine("4 - вектор с макс. и мин. числом координат");
                    Console.WriteLine("5 - сортировка массива по кол-ву координат векторов (по возрастанию)");
                    Console.WriteLine("6 - сортировка по нормали");
                    Console.WriteLine("7 - выход");
                    int menu = ReadInt(1, 7);
                    switch (menu)
                    {
                        case 1:
                            {
                                if (current == vector_num)
                                    throw new Exception("Максимальное кол-во векторов");
                                Console.Write("Длина нового вектора: ");
                                int length = ReadInt(1, int.MaxValue);
                                ArrayVector vector = new ArrayVector(length);
                                Console.Write("Координаты вектора (через пробел): ");
                                string[] str = Console.ReadLine().Split(' ');
                                for (int i = 0; i < str.Length; i++)
                                    vector[i] = float.Parse(str[i]);
                                vectors[current] = vector;
                                current++;
                            }
                            break;
                        case 2:
                            {
                                if (current == vector_num)
                                    throw new Exception("Максимальное кол-во векторов");
                                Console.Write("Длина нового вектора: ");
                                int length = ReadInt(1, int.MaxValue);
                                LinkedListVector vector = new LinkedListVector(length);
                                Console.Write("Координаты вектора (через пробел): ");
                                string[] str = Console.ReadLine().Split(' ');
                                for (int i = 0; i < str.Length; i++)
                                    vector[i] = float.Parse(str[i]);
                                vectors[current] = vector;
                                current++;
                            }
                            break;
                        case 3:
                            {
                                for (int i = 0; i < vector_num; i++)
                                    Console.WriteLine(vectors[i].GetType().ToString().Split('.')[1] + ": " + vectors[i].ToString());
                                    //Console.WriteLine(vectors[i].ToString());
                            }
                            break;
                        case 4:
                            {
                                if (vector_num == 0)
                                    throw new Exception("Вектора не созданы");
                                if (vector_num == 1)
                                    Console.WriteLine("Макс./мин. вектор (длина + координаты): " + vectors[0].ToString());
                                else
                                {
                                    Vector max = vectors[0];
                                    Vector min = vectors[0];
                                    List<int> maxEl = new List<int>();
                                    List<int> minEl = new List<int>() { 0 };
                                    for (int i = 1; i < vector_num; i++)
                                    {
                                        if (vectors[i].CompareTo(max) > 0)
                                        {
                                            maxEl.Clear();
                                            maxEl.Add(i);
                                            max = vectors[i];
                                        }
                                        else if (vectors[i].CompareTo(max) == 0)
                                        {
                                            maxEl.Add(i);
                                        }

                                        if (vectors[i].CompareTo(min) < 0)
                                        {
                                            minEl.Clear();
                                            minEl.Add(i);
                                            min = vectors[i];
                                        }
                                        else if (vectors[i].CompareTo(min) == 0)
                                        {
                                            minEl.Add(i);
                                        }
                                    }
                                    Console.WriteLine("Вектора с наибольшим кол-вом координат");
                                    for (int i = 0; i < maxEl.Count; i++)
                                        Console.WriteLine(vectors[maxEl[i]].GetType().ToString().Split('.')[1] + ": " + vectors[maxEl[i]].ToString());
                                    Console.WriteLine("Вектора с наименьшим кол-вом координат");
                                    for (int i = 0; i < minEl.Count; i++)
                                        Console.WriteLine(vectors[minEl[i]].GetType().ToString().Split('.')[1] + ": " + vectors[minEl[i]].ToString());
                                }
                            }
                            break;
                        case 5:
                            {
                                QS(vectors, 0, vector_num - 1);
                            }
                            break;
                        case 6:
                            {
                                class_for_IComparer comp = new class_for_IComparer();
                                Array.Sort(vectors, comp);
                            }
                            break;
                        case 7:
                            {
                                isExit = true;
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}