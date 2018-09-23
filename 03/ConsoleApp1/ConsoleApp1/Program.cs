using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Vacancies { Manager, Boss, Clerk, Salesman };
    struct Employee
    {
        public string name;
        public Vacancies vacancy;
        public int salary;
        public int[] hiredate;
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Имя: " + name + Environment.NewLine);
            str.Append("Должность: " + vacancy + Environment.NewLine);
            str.Append("Зарплата: " + salary + Environment.NewLine);
            str.Append("Дата найма: " + hiredate[0] + " " + hiredate[1] + " " + hiredate[2] + Environment.NewLine);
            return str.ToString();
        }
    }
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
            Console.WriteLine("Программа предназначена для работы с сотрудниками");
            List<Employee> emploers = new List<Employee>();
            Console.Write("Кол-во сотрудников: ");
            int num = ReadInt(0, int.MaxValue);
            for (int i = 0; i < num; i++)
            {
                Employee tmp = new Employee();
                Console.Write("Имя: ");
                tmp.name = Console.ReadLine();

                Console.WriteLine("Выберите должность: ");
                var t = Enum.GetNames(typeof(Vacancies)).ToArray();
                for (int k = 0; k < t.Length; k++)
                    Console.WriteLine(k + 1 + ": " + t[k]);
                tmp.vacancy = (Vacancies)ReadInt(1, 4) - 1;

                Console.Write("Зарплата: ");
                tmp.salary = ReadInt(0, int.MaxValue);

                bool isExit = false;
                while (!isExit)
                {
                    try
                    {
                        Console.Write("Дата найма (формат ввода: дд мм гггг): ");
                        string[] str = Console.ReadLine().Split(' ');
                        if (str.Length != 3)
                        {
                            Console.WriteLine("Неверный формат");
                            continue;
                        }
                        int day, month, year;
                        int.TryParse(str[0], out day);
                        int.TryParse(str[1], out month);
                        int.TryParse(str[2], out year);
                        if (day < 1 || day > 31 || (day > 30 && (month == 4 || month == 6 || month == 9 || month == 11)))
                        {
                            throw new Exception("Неверный формат дня");
                        }
                        if (month == 2)
                        {
                            if (year % 4 != 0 && day > 28)
                            {
                                throw new Exception("Неверный формат дня");
                            }
                            else if (day > 29)
                                throw new Exception("Неверный формат дня");
                        }

                        if (month < 1 || month > 12)
                        {
                            Console.WriteLine("Неверный формат месяца");
                            continue;
                        }

                        if (year < 0 || year > 2018)
                        {
                            Console.WriteLine("Неверный формат года");
                            continue;
                        }
                        tmp.hiredate = new int[] { day, month, year };
                        emploers.Add(tmp);
                        isExit = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            }

            bool isExit1 = false;
            while (!isExit1)
            {
                Console.WriteLine("1 - вывести информацию обо всех сотрудниках");
                Console.WriteLine("2 - вывести информацию о сотрудниках указанной должности");
                Console.WriteLine("3 - вывести (по алфавиту) менеджеров, чья зарплата больше средней зарплаты всех клерков");
                Console.WriteLine("4 - вывести (по афлавиту) информацию обо всех сотрудниках, нанятых после босса");
                int menu = ReadInt(1, 4);
                switch (menu)
                {
                    case 1:
                        {
                            for (int i = 0; i < emploers.Count; i++)
                                Console.WriteLine(emploers[i].ToString() + Environment.NewLine);
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Выберите должность: ");
                            var t = Enum.GetNames(typeof(Vacancies)).ToArray();
                            for (int k = 0; k < t.Length; k++)
                                Console.WriteLine(k + 1 + ": " + t[k]);
                            int tmp = ReadInt(1, 4) - 1;

                            for (int i = 0; i < emploers.Count; i++)
                                if (emploers[i].vacancy == (Vacancies)tmp) Console.WriteLine(emploers[i].ToString() + Environment.NewLine);
                        }
                        break;
                    case 3:
                        {
                            List<Employee> managers = new List<Employee>();
                            float salary = 0;
                            int tmp = 0;
                            for (int i = 0; i < emploers.Count; i++)
                                if (emploers[i].vacancy == Vacancies.Clerk)
                                {
                                    salary += emploers[i].salary;
                                    tmp++;
                                }
                            if (tmp != 0) salary /= tmp;
                            for (int i = 0; i < emploers.Count; i++)
                                if (emploers[i].vacancy == Vacancies.Manager && emploers[i].salary > salary) managers.Add(emploers[i]);
                            managers.Sort();
                            for (int i = 0; i < managers.Count; i++)
                                Console.WriteLine(managers[i].ToString() + Environment.NewLine);
                        }
                        break;
                    case 4:
                        {
                            try
                            {
                                int day = 0;
                                int month = 0;
                                int year = 0;
                                bool isBoss = false;
                                for (int i = 0; i < emploers.Count; i++)
                                    if (emploers[i].vacancy == Vacancies.Boss)
                                    {
                                        isBoss = true;
                                        day = emploers[i].hiredate[0];
                                        month = emploers[i].hiredate[1];
                                        year = emploers[i].hiredate[2];
                                    }
                                if (!isBoss) throw new Exception("Босс не найден");

                                List<Employee> workers = new List<Employee>();
                                for (int j = 0; j < emploers.Count; j++)
                                    if (emploers[j].hiredate[2] > year
                                        || (emploers[j].hiredate[2] == year && emploers[j].hiredate[1] > month)
                                        || (emploers[j].hiredate[2] == year && emploers[j].hiredate[1] == month && emploers[j].hiredate[0] > day))
                                        workers.Add(emploers[j]);

                                workers.Sort();
                                for (int i = 0; i < workers.Count; i++)
                                    Console.WriteLine(workers[i].ToString() + Environment.NewLine);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        break;
                }
            }
        }
    }
}
