using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int partition(List<Vector> vectors, int start, int end)
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
        private static void QS(List<Vector> vectors, int start, int end)
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
            List<Vector> vectors = new List<Vector>();
            bool isExit1 = false;
            while (!isExit1)
            {
                try
                {
                    Console.WriteLine("1 - добавить ArrayVector");
                    Console.WriteLine("2 - добавить LinkedListVector");
                    Console.WriteLine("3 - вывести массив векторов");
                    Console.WriteLine("4 - вектор с макс. и мин. числом координат");
                    Console.WriteLine("5 - сортировка массива по кол-ву координат векторов (по возрастанию)");
                    Console.WriteLine("6 - записать/считать вектор");
                    Console.WriteLine("7 - сериализация");
                    Console.WriteLine("8 - выход");
                    int menu1 = ReadInt(1, 8);
                    switch (menu1)
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
                                if (vectors.Count < 1)
                                    throw new Exception("Вектора не созданы");
                                if (vectors.Count == 1)
                                    Console.WriteLine("Макс./мин. вектор (длина + координаты): " + vectors[0].ToString());
                                else
                                {
                                    Vector max = vectors[0];
                                    Vector min = vectors[0];
                                    List<int> maxEl = new List<int>();
                                    List<int> minEl = new List<int>() { 0 };
                                    for (int i = 1; i < vectors.Count; i++)
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
                                QS(vectors, 0, vectors.Count - 1);
                            }
                            break;
                        case 6:
                            {
                                bool isExit2 = false;
                                while (!isExit2)
                                {
                                    Console.WriteLine("1 - записать в бинарном формате");
                                    Console.WriteLine("2 - считать в бинарном формате");
                                    Console.WriteLine("3 - записать в текстовом формате");
                                    Console.WriteLine("4 - считать в текстовом формате");
                                    Console.WriteLine("5 - выход");
                                    int menu2 = ReadInt(1, 5);
                                    switch (menu2)
                                    {
                                        case 1:
                                            {
                                                using (FileStream stream = new FileStream("binVectors.b", FileMode.Create))
                                                {
                                                    for (int i = 0; i < vectors.Count; i++)
                                                        Vectors.OutputVector(vectors[i], stream);
                                                }
                                            };
                                            break;
                                        case 2:
                                            {
                                                using (FileStream stream = new FileStream("binVectors.b", FileMode.Open))
                                                {
                                                    Vector vector;
                                                    while ((vector = Vectors.InputVector(stream)) != null)
                                                        vectors.Add(vector);
                                                }
                                            }
                                            break;
                                        case 3:
                                            {
                                                using (FileStream stream = new FileStream("txtVectors.t", FileMode.Create))
                                                {
                                                    using (StreamWriter writer = new StreamWriter(stream))
                                                    {
                                                        for (int i = 0; i < vectors.Count; i++)
                                                            Vectors.WriteVector(vectors[i], writer);
                                                    }
                                                }
                                            }
                                            break;
                                        case 4:
                                            {
                                                using (FileStream stream = new FileStream("txtVectors.t", FileMode.Open))
                                                {
                                                    using (StreamReader reader = new StreamReader(stream))
                                                    {
                                                        Vector vector;
                                                        while ((vector = Vectors.ReadVector(reader)) != null)
                                                            vectors.Add(vector);
                                                    }
                                                }
                                            }
                                            break;
                                        case 5:
                                            {
                                                isExit2 = true;
                                            }
                                            break;
                                    }
                                }
                            }
                            break;
                        case 7:
                            {
                                Console.Write("Длина нового вектора: ");
                                int length = ReadInt(1, int.MaxValue);
                                ArrayVector vector = new ArrayVector(length);
                                Console.Write("Координаты вектора (через пробел): ");
                                string[] str = Console.ReadLine().Split(' ');
                                for (int i = 0; i < str.Length; i++)
                                    vector[i] = float.Parse(str[i]);

                                BinaryFormatter bf = new BinaryFormatter();
                                using (FileStream stream = new FileStream("binSer.b", FileMode.Create)) {
                                    bf.Serialize(stream, vector);
                                    Console.WriteLine("Объект сериализирован");
                                }
                                using (FileStream stream = new FileStream("binSer.b", FileMode.Open))
                                {
                                    vector = (ArrayVector)bf.Deserialize(stream);   
                                }
                                Console.Write("Десериализированный объект: ");
                                Console.WriteLine(vector.ToString());

                            }
                            break;
                        case 8:
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
