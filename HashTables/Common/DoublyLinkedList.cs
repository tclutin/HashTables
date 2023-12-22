using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.Common
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Next;
        public Node<T> Previous;

        public Node(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }

    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public Node<T> head;
        public Node<T> tail;

        private int count;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            count++;
        }

        public void Remove(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }

                    if (head == current)
                    {
                        head = current.Next;
                    }

                    if (tail == current)
                    {
                        tail = current.Previous;
                    }
                    count--;
                    return;
                }
                current = current.Next;
            }
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public T Get(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return current.Data;
                }
                current = current.Next;
            }
            return default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
