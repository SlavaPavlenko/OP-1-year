using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    delegate void MethodContainer();
    class Program
    {
        public static Vector[] vectors;
        public static int current = 0;
        static void CreateArrayVector()
        {
            if (current < vectors.Length)
            {
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
            else {
                throw new Exception("Больше векторов создать нельзя");
            }
        }
        private static void CreateLinkedListVector()
        {
            if (current < vectors.Length)
            {
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
            else {
                throw new Exception("Больше векторов создать нельзя");
            }
        }
        private static void ShowVectors()
        {
            for (int i = 0; i < vectors.Length; i++)
                Console.WriteLine(vectors[i].GetType().ToString().Split('.')[1] + ": " + vectors[i].ToString());
        }
        private static void FindMinMax()
        {
            if (current < 1)
            {
                throw new Exception("Вектора не созданы");

            }
            if (current == 0)
                Console.WriteLine("Макс./мин. вектор (длина + координаты): " + vectors[0].ToString());
            else
            {
                Vector max = vectors[0];
                Vector min = vectors[0];
                List<int> maxEl = new List<int>();
                List<int> minEl = new List<int>() { 0 };
                for (int i = 0; i < current; i++)
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
        private static void Sort()
        {
            QS(vectors, 0, vectors.Length - 1);
            ShowVectors();
        }
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
        private static void SortNorm()
        {
            class_for_IComparer comp = new class_for_IComparer();
            Array.Sort(vectors, comp);
        }
        private static int ReadInt(int left, int right)
        {
            int num = 0;
            bool isExit = false;
            while (!isExit)
            {
                string str = Console.ReadLine();
                if (str == "exit")
                    return -1;
                else if (str == "done")
                    return -2;
                else
                {
                    bool tmp = int.TryParse(str, out num);
                    if (!tmp || num < left || num > right)
                    {
                        Console.WriteLine("Неверное значение");
                    }
                    else
                    {
                        isExit = true;
                    }
                }
            }
            return num;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Программа предназначена для работы с делегатами");
            Console.WriteLine("Введите команды. После выполнения списка команд работа программы продолжается");
            Console.WriteLine("Кол-во векторов: ");
            vectors = new Vector[ReadInt(1, int.MaxValue)];
            Console.WriteLine("1 - добавить ArrayVector");
            Console.WriteLine("2 - добавить LinkedListVector");
            Console.WriteLine("3 - вывести массив векторов");
            Console.WriteLine("4 - вектор с макс. и мин. числом координат");
            Console.WriteLine("5 - сортировка массива по кол-ву координат векторов (по возрастанию)");
            Console.WriteLine("6 - сортировка по нормали");
            Console.WriteLine("0 - выполнение команд");
            MethodContainer container = null;
            bool isExit = false;
            int menu;
            while (!isExit)
            {
                try
                {
                    menu = ReadInt(0, 6);
                    switch (menu) {
                        case 0:
                            {
                                if (container == null)
                                    throw new Exception("Сценарий пуст");
                                else
                                {
                                    try
                                    {
                                        container();
                                    }
                                    catch (Exception e) { Console.WriteLine(e.Message); }
                                    container = null;
                                }
                            }
                            break;
                        case 1: container += CreateArrayVector;
                            break;
                        case 2: container += CreateLinkedListVector;
                            break;
                        case 3: container += ShowVectors;
                            break;
                        case 4: container += FindMinMax;
                            break;
                        case 5: container += Sort;
                            break;
                        case 6: container += SortNorm;
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
