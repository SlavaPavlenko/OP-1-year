using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class LinkedListVector: Vector, IComparable, ICloneable
    {
        private Node _first;
        public LinkedListVector() : this(5) { }
        public LinkedListVector(int length) {
            if (length == 0) return;
            _first = new Node();
            Node tmp = _first;
            for (int i = 0; i < length-1; i++) {
                Node next = new Node();
                tmp.Next = next;
                tmp = next;
            }
        }
        public float this[int index] {
            get {
                int i = 0;
                Node current = _first;
                while (current != null && i < index)
                {
                    current = current.Next;
                    i++;
                }
                if (current == null)
                    throw new Exception("Индекс вне границ массива");
                return  current.Data;
            }
            set {
                int i = 0;
                Node current = _first;
                while (current != null && i < index)
                {
                    current = current.Next;
                    i++;
                }
                if (current == null)
                    throw new Exception("Индекс вне границ массива");
                current.Data = value;
            }
        }
        public override string ToString()
        {
            Node current = _first;
            StringBuilder str = new StringBuilder();
            str.Append(Length + " ");
            for (int i = 0; i < Length; i++)
            {
                str.Append(current.Data + " ");
                current = current.Next;
            }
            return str.ToString();
        }
        public override bool Equals(object obj)
        {
            Vector vector = (Vector)obj;
            Node current = _first;
            if (vector.Length != Length) return false;
            for (int i = 0; i < Length; i++)
                {
                    if (vector[i] != current.Data) return false;
                    current = current.Next;
                }
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            Vector vector = (Vector)obj;
            int length = Length - vector.Length;
            return length;
        }
        public object Clone()
        {
            Node current = _first;
            LinkedListVector newVector = new LinkedListVector(this.Length);
            for (int i = 0; i < this.Length; i++)
            {
                newVector[i] = current.Data;
                current = current.Next;
            }
            return newVector;
        }
        public int Length {
            get {
                int num = 0;
                Node current = _first;
                while (current != null)
                {
                    current = current.Next;
                    num++;
                }
                return num;
            }
        }
        public float GetNorm() {
            float sum = 0;
            int i = 0;
            Node current = _first;
            while (current != null)
            {
                current = current.Next;
                sum += current.Data * current.Data;
                i++;
            }
            return (float)Math.Sqrt(sum) / i;
        }
        public class Node
        {
            private float _data;
            private Node _next;
            public float Data
            {
                get { return _data; }
                set { _data = value; }
            }
            public Node Next
            {
                get { return _next; }
                set { _next = value; }
            }
            public Node() {
                _data = 0;
                _next = null;
            }
            public Node(float data) {
                _data = data;
            }
            public Node(float data, Node next) {
                _data = data;
                _next = next;
            }
        }
    }
}
