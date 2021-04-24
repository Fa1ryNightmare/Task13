using System;
using System.Collections;
using System.Collections.Generic;

namespace Task13
{
    class CollectionType<T> : IEnumerable<T>
    {
        LinkedList<T> data;

        public CollectionType()
        {
            data = new LinkedList<T>();
        }

        ~CollectionType()
        {
            Console.WriteLine("Dispose");
            Clear();
        }

        public LinkedListNode<T> Last
        { 
            get
            {
                return data.Last;
            }
        }

        public LinkedListNode<T> First
        {
            get
            {
                return data.First;
            }
        }

        public int Count
        { 
            get
            {
                return data.Count;
            }
        }

        public void AddFirst(T value)
        {
            data.AddFirst(value);
        }

        public void AddLast(T value)
        {
            data.AddLast(value);
        }

        public void Clear()
        {
            data.Clear();
        }

        public bool Contains(T value)
        {
            return data.Contains(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public bool Remove(T value)
        {
            return data.Remove(value);
        }

        public void RemoveFirst()
        {
            data.RemoveFirst();
        }

        public void RemoveLast()
        {
            data.RemoveLast();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
