using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    delegate void MethodContainer();
    public partial class Form1 : Form
    {
        private MethodContainer container = null;
        private bool _started = false;
        private bool _buf = false;
        public Form1()
        {
            InitializeComponent();
        }
        private List<Vector> vectors = new List<Vector>();
        void CreateArrayVector()
        {
            Write("Длина нового вектора: ");
            int length = ReadInt(1, int.MaxValue);
            ArrayVector vector = new ArrayVector(length);
            Write("Координаты вектора (через пробел): ");
            string[] str = Read().Split(' ');
            for (int i = 0; i < str.Length; i++)
                vector[i] = float.Parse(str[i]);
            vectors.Add(vector);
        }
        private void CreateLinkedListVector()
        {
            Write("Длина нового вектора: ");
            int length = ReadInt(1, int.MaxValue);
            LinkedListVector vector = new LinkedListVector(length);
            Write("Координаты вектора (через пробел): ");
            string[] str = Read().Split(' ');
            for (int i = 0; i < str.Length; i++)
                vector[i] = float.Parse(str[i]);
            vectors.Add(vector);
        }
        private void ShowVectors()
        {
            for (int i = 0; i < vectors.Count; i++)
                Write(vectors[i].GetType().ToString().Split('.')[1] + ": " + vectors[i].ToString());
        }
        private void FindMinMax()
        {
            if (vectors.Count < 1)
                throw new Exception("Вектора не созданы");
            if (vectors.Count == 1)
                Write("Макс./мин. вектор (длина + координаты): " + vectors[0].ToString());
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
                Write("Вектора с наибольшим кол-вом координат");
                for (int i = 0; i < maxEl.Count; i++)
                    Write(vectors[maxEl[i]].GetType().ToString().Split('.')[1] + ": " + vectors[maxEl[i]].ToString());
                Write("Вектора с наименьшим кол-вом координат");
                for (int i = 0; i < minEl.Count; i++)
                    Write(vectors[minEl[i]].GetType().ToString().Split('.')[1] + ": " + vectors[minEl[i]].ToString());
            }
        }
        private void Sort()
        {
            QS(vectors, 0, vectors.Count - 1);
            ShowVectors();
        }
        int partition(List<Vector> vectors, int start, int end)
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
        private void QS(List<Vector> vectors, int start, int end)
        {
            if (start < end)
            {
                int marker = partition(vectors, start, end);
                QS(vectors, start, marker - 1);
                QS(vectors, marker + 1, end);
            }
        }
        private int ReadInt(int left, int right)
        {
            int num = 0;
            bool isExit = false;
            while (!isExit)
            {
                string str = Read();
                if (str == "exit")
                    return -1;
                else if (str == "done")
                    return -2;
                else
                {
                    bool tmp = int.TryParse(str, out num);
                    if (!tmp || num < left || num > right)
                    {
                        Write("Неверное значение");
                    }
                    else
                    {
                        isExit = true;
                    }
                }
            }
            return num;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Создать ArrayVector");
            listBox1.Items.Add("Создать LinkedListVector");
            listBox1.Items.Add("Вывести массив векторов");
            listBox1.Items.Add("Вектор с макс. и мин. числом коорд.");
            listBox1.Items.Add("Сортировка массива");
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.Text += listBox1.SelectedItem + Environment.NewLine;
            switch (listBox1.SelectedIndex + 1)
            {
                case 1:
                    container += CreateArrayVector;
                    break;
                case 2:
                    container += CreateLinkedListVector;
                    break;
                case 3:
                    container += ShowVectors;
                    break;
                case 4:
                    container += FindMinMax;
                    break;
                case 5:
                    container += Sort;
                    break;
            }
        }
        private string Read()
        {
                while (!_buf)
                {
                    Thread.Sleep(0);
                }
            string str = null;
            this.Invoke((MethodInvoker)delegate
            {
                str = textBox1.Text;
                textBox1.Text = "";
            });
            _buf = false;
            return str;
        }
        private void Write(string str)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBox2.Text += str + Environment.NewLine;
            });
        }
        private bool isEnd = false;
        private void End()
        {
            this.Invoke((MethodInvoker)delegate
            {
                button1.Text = "End";
                textBox1.Enabled = false;
            });
            isEnd = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!_started)
            {
                if (container == null)
                    throw new Exception("Сценарий пуст");
                else
                {
                    button1.Text = "Enter";
                    textBox1.Enabled = true;
                    _started = true;
                    listBox1.Enabled = false;
                    container += End;
                    Thread thread = new Thread(container.Invoke);
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
            else if (isEnd)
            {
                container = null;
                button1.Text = "Start";
                listBox1.Enabled = true;
                textBox2.Text = "";
                isEnd = false;
                _started = false;
            }
            else
            {
                textBox2.Text += textBox1.Text + Environment.NewLine;
                _buf = true;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, null);
        }
    }
}
