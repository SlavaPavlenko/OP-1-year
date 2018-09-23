using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class LinkedListVector
    {
        private Node _first;
        public LinkedListVector() : this(5) { }
        public LinkedListVector(int length) {
            _first = new Node();
            Node tmp = _first;
            for (int i = 0; i < length-1; i++) {
                Node next = new Node();
                tmp.Next = next;
                tmp = next;
            }
        }
        public int Count {
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
        public float GetNorm() {
            float sum = 0;
            int i = 0;
            Node current = _first;
            while (current != null)
            {
                sum += current.Data * current.Data;
                i++;
                current = current.Next;
            }
            return (float)Math.Sqrt(sum);
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
