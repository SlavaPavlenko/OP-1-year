using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
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
            bool isExit1 = false;
            int menu1 = 0;
            ArrayVector vector1 = null;
            ArrayVector vector2 = null;
            LinkedListVector linkedList = null;
            while (!isExit1)
            {
                Console.WriteLine("1 - создать векторы");
                Console.WriteLine("2 - создать список");
                Console.WriteLine("3 - работа с векторами");
                Console.WriteLine("4 - работа со списком");
                Console.WriteLine("5 - Выход");
                menu1 = ReadInt(1, 5);
                try
                {
                    switch (menu1)
                    {
                        case 1:
                            {
                                Console.Write("Длина 1 вектора: ");
                                int len = ReadInt(0, int.MaxValue);
                                vector1 = new ArrayVector(len);
                                Console.Write("Координаты вектора (через пробел): ");
                                string[] str = Console.ReadLine().Split(' ');
                                for (int i = 0; i < str.Length; i++)
                                    vector1[i] = float.Parse(str[i]);

                                Console.Write("Длина 2 вектора: ");
                                len = ReadInt(0, int.MaxValue);
                                vector2 = new ArrayVector(len);
                                Console.Write("Координаты вектора (через пробел): ");
                                str = Console.ReadLine().Split(' ');
                                for (int i = 0; i < str.Length; i++)
                                    vector2[i] = float.Parse(str[i]);
                            }
                            break;
                        case 2:
                            {
                                Console.Write("Длина списка: ");
                                int len = ReadInt(0, int.MaxValue);
                                linkedList = new LinkedListVector(len);
                                Console.Write("Координаты вектора (через пробел): ");
                                string[] str = Console.ReadLine().Split(' ');
                                for (int i = 0; i < str.Length; i++)
                                    linkedList[i] = float.Parse(str[i]);
                            }
                            break;
                        case 3:
                            {
                                if (vector1 == null)
                                    Console.WriteLine("Вектора не созданы");
                                else
                                {
                                    bool isExit2 = false;
                                    int menu2 = 0;
                                    while (!isExit2)
                                    {
                                        Console.WriteLine("1 - сумма векторов");
                                        Console.WriteLine("2 - скалярное произведение векторов");
                                        Console.WriteLine("3 - модули векторов");
                                        Console.WriteLine("4 - выход");
                                        menu2 = ReadInt(1, 4);
                                        switch (menu2)
                                        {
                                            case 1:
                                                {
                                                    ArrayVector tmp = Vectors.Sum(vector1, vector2);
                                                    for (int i = 0; i < tmp.Length; i++)
                                                        Console.Write(tmp[i] + " ");
                                                    Console.WriteLine();
                                                }
                                                break;
                                            case 2:
                                                {
                                                    float tmp = Vectors.Scalar(vector1, vector2);
                                                    Console.WriteLine(tmp);
                                                }
                                                break;
                                            case 3:
                                                {
                                                    float tmp1 = Vectors.GetNorm(vector1);
                                                    float tmp2 = Vectors.GetNorm(vector2);
                                                    Console.WriteLine(tmp1);
                                                    Console.WriteLine(tmp2);
                                                }
                                                break;
                                            case 4:
                                                {
                                                    isExit2 = true;
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                            break;
                        case 4:
                            {
                                if (linkedList == null)
                                    Console.WriteLine("Список не создан");
                                else
                                {
                                    bool isExit3 = false;
                                    int menu3 = 0;
                                    while (!isExit3)
                                    {
                                        Console.WriteLine("1 - длина вектора");
                                        Console.WriteLine("2 - кол-во элементов вектора");
                                        Console.WriteLine("3 - редактировать элемент вектора");
                                        Console.WriteLine("4 - вывести список");
                                        Console.WriteLine("5 - выход");
                                        menu3 = ReadInt(1, 5);
                                        switch (menu3)
                                        {
                                            case 1:
                                                {
                                                    Console.WriteLine(linkedList.GetNorm());
                                                }
                                                break;
                                            case 2:
                                                {
                                                    Console.WriteLine(linkedList.Count);
                                                }
                                                break;
                                            case 3:
                                                {
                                                    int index;
                                                    Console.Write("Индекс элемента: ");
                                                    index = ReadInt(0, linkedList.Count - 1);
                                                    Console.Write("Значение: ");
                                                    linkedList[index] = float.Parse(Console.ReadLine());
                                                }
                                                break;
                                            case 4:
                                                {
                                                    for (int i = 0; i < linkedList.Count; i++)
                                                        Console.Write(linkedList[i] + " ");
                                                    Console.WriteLine();
                                                }
                                                break;
                                            case 5:
                                                {
                                                    isExit3 = true;
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                            break;
                        case 5:
                            {
                                isExit1 = true;
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