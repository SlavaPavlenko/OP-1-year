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
            List<Vector> vectors = new List<Vector>();
            bool isExit = false;
            while (!isExit)
            {
                try
                {
                    Console.WriteLine("1 - добавить ArrayVector");
                    Console.WriteLine("2 - добавить LinkedListVector");
                    Console.WriteLine("3 - вывести массив векторов");
                    Console.WriteLine("4 - выход");
                    int menu = ReadInt(1, 4);
                    switch (menu)
                    {
                        case 1:
                            {
                                Console.Write("Длина нового вектора: ");
                                int length = ReadInt(1, int.MaxValue);
                                ArrayVector vector = new ArrayVector(length);
                                Console.Write("Координаты вектора (через пробел): ");
                                string[] str = Console.ReadLine().Split(' ');
                                for (int i = 0; i < str.Length; i++)
                                    vector[i] = float.Parse(str[i]);
                                vectors.Add(vector);
                            }
                            break;
                        case 2:
                            {
                                Console.Write("Длина нового вектора: ");
                                int length = ReadInt(1, int.MaxValue);
                                LinkedListVector vector = new LinkedListVector(length);
                                Console.Write("Координаты вектора (через пробел): ");
                                string[] str = Console.ReadLine().Split(' ');
                                for (int i = 0; i < str.Length; i++)
                                    vector[i] = float.Parse(str[i]);
                                vectors.Add(vector);
                            }
                            break;
                        case 3:
                            {
                                for (int i = 0; i < vectors.Count; i++)
                                    Console.WriteLine(vectors[i].GetType().ToString().Split('.')[1] + ": " + vectors[i].ToString());
                            }
                            break;
                        case 4:
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