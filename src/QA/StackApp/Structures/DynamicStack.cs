using System;

namespace StackApp
{
    public class DinamicStack<T> : IStack<T>
    {
        private T[] collection;
        private int count;


        public DinamicStack(int length = 10)
        {
            collection = new T[10];
        }

        public void Push(T item)
        {
            if (collection.Length == count) Resize(count + 10);
            collection[count++] = item;
        }

        public T Pull()
        {
            if (count > 0 && count < collection.Length - 10) Resize(count - 10);
            T temp = collection[--count];
            collection[count] = default(T);
            return temp;
        }

        public T Peek()
        {
            return collection[count - 1];
        }

        private void Resize(int size)
        {
            T[] tempItems = new T[size];
            for (int i = 0; i < count; i++)
            {
                tempItems[i] = collection[i];
            }
            collection = tempItems;

        }

    }
}
