using System;
using System.Collections;
using StructData;

namespace CSharpHints
{
    public class WayOfStructData : ILesson
    {
        public void StartLesson()
        {
            OneLinkedList<int> linkedList = new OneLinkedList<int>();

            linkedList.Add(0);
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);
            linkedList.Add(6);
            linkedList.Add(7);
            linkedList.Add(8);
            linkedList.Add(9);

            Console.WriteLine(linkedList.Contains(6));
            Console.WriteLine(linkedList.Contains(9));
            Console.WriteLine(linkedList.Contains(0));
            Console.WriteLine(linkedList.Contains(5));
            Console.WriteLine(linkedList.ToString());

            Console.WriteLine("ARRAY:");
            for (int i = 0; i < linkedList.Length; ++i)
            {
                Console.WriteLine(linkedList[i]);
            }
            Console.WriteLine();

            linkedList.RemoveFromHead();
            Console.WriteLine(linkedList.ToString());
            linkedList.RemoveFromTail();
            Console.WriteLine(linkedList.ToString());
            linkedList.Remove(11);
            Console.WriteLine(linkedList.ToString());
            linkedList.Remove(6);
            Console.WriteLine(linkedList.ToString());

            Console.WriteLine("ARRAY:");
            foreach (int i in linkedList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }
    }
}

namespace StructData
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    public class OneLinkedList<T> : IEnumerable
    {
        private T[] values = null;
        private Node<T> head = null;
        private Node<T> tail = null;

        public int Length
        {
            get
            {
                return values != null && values.Length > 0 ? values.Length : 0;
            }
        }
        public T this[int index]
        {
            get
            {
                try
                {
                    return values![index];
                }
                catch
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                try
                {
                    values![index] = value;
                }
                catch
                {
                    throw;
                }
            }
        }

        public OneLinkedList() { }

        public OneLinkedList(T[] values)
        {
            this.values = values;
            foreach (T item in values) AddToNode(item);
        }

        private void AddToNode(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null) head = newNode;
            else tail.Next = newNode;
            tail = newNode;
        }

        private void AddToArray(T data, int index = -1)
        {
            if (values == null)
            {
                values = new T[1] { data };
            }
            else
            {
                T[] newValues = new T[values.Length + 1];
                newValues[index > -1 ? index : newValues.Length - 1] = data;
                for (int i = 0; i < values.Length; ++i)
                {
                    if (index == i) break;
                    newValues[i] = values[i];
                }
                values = newValues;
            }
        }

        private void RemoveFromArray(int index)
        {
            T[] newValues = new T[values.Length - 1];

            for (int j = 0, i = 0; i < values.Length; ++i)
            {
                if (i != index) newValues[j++] = values[i];
            }
            values = newValues;
        }

        public void Add(T data)
        {
            AddToNode(data);
            AddToArray(data);
        }

        public void Remove(T data)
        {
            if (values != null && Length > 0 && Contains(data))
            {
                int i = 0;
                Node<T> searchNode = head;
                Node<T> prevNode = head;

                while (searchNode.Next != null)
                {
                    if (searchNode.Data.Equals(data))
                    {
                        prevNode.Next = searchNode.Next;
                        RemoveFromArray(i);
                        return;
                    }
                    prevNode = searchNode;
                    searchNode = searchNode.Next;
                    ++i;
                }
            }
            else return;
        }

        public void RemoveFromHead()
        {
            Node<T> node = head.Next;
            head = node;
            RemoveFromArray(0);
        }

        public void RemoveFromTail()
        {
            Node<T> node = head;

            while (node.Next != tail) node = node.Next;
            tail = node;
            tail.Next = null;
            RemoveFromArray(values.Length - 1);
        }

        public bool Contains(T data)
        {
            bool result = false;
            Node<T> searchNode = head;

            while (!result && searchNode.Next != null)
            {
                if (data.Equals(searchNode.Data))
                {
                    result = true;
                    break;
                }
                else
                    searchNode = searchNode.Next;
            }
            return result || searchNode.Data.Equals(data);
        }

        public override string ToString()
        {
            Node<T> node = head;
            string str = "";

            while (node.Next != null)
            {
                str += $"{node.Data}, ";
                node = node.Next;
            }
            return str += node.Data.ToString() + "\n";
        }

        public IEnumerator GetEnumerator()
        {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class TwoLinkedList<T>
    {
        private Node<T> head = null;
        private Node<T> tail = null;

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null) head = newNode;
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
            }
            tail = newNode;
        }

        public void Remove(T data)
        {
            if (Contains(data))
            {
                Node<T> searchNode = head;
                Node<T> prevNode = head;

                while (searchNode.Next != null)
                {
                    if (searchNode.Data.Equals(data))
                    {
                        prevNode.Next = searchNode.Next;
                        return;
                    }
                    prevNode = searchNode;
                    searchNode = searchNode.Next;
                }
            }
            else return;
        }

        public void RemoveFromHead()
        {
            Node<T> node = head.Next;
            head = node;
        }

        public void RemoveFromTail()
        {
            Node<T> node = tail.Prev;
            tail = node;
        }

        public bool Contains(T data)
        {
            bool result = false;
            Node<T> searchNode = head;

            while (!result && searchNode.Next != null)
            {
                if (data.Equals(searchNode.Data))
                {
                    result = true;
                    break;
                }
                else
                    searchNode = searchNode.Next;
            }
            return result || searchNode.Data.Equals(data);
        }

        public override string ToString()
        {
            Node<T> node = head;
            string str = "";

            while (node.Next != null)
            {
                str += $"{node.Data}, ";
                node = node.Next;
            }
            return str += node.Data.ToString() + "\n";
        }
    }
}