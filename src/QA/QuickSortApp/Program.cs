using System;

namespace QuickSortApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] massive = { 1, 32, 13, 4, 5, 516, 37, 18, 39, 10, 111, 12 };
            new Sort<int>().QuickSort(massive, 0, massive.Length-1);

            foreach (var item in massive)
            {
                Console.Write(item.ToString());
                Console.Write(",");
            }
            Console.WriteLine("Hello World!");
        }
    }

    public class Sort<T> where T : IComparable<T>
    {
        public void QuickSort(T[] list, int start, int end)
        {
            if (end - start < 2) return;

            int index = start;
            T root = list[index];
            
            for (int i = start+1; i <= end; i++)
            {
                if (list[i].CompareTo(root) <= 0)
                {
                    list [index] = list [i];
                    index = i;
                }
            }
            list[index] = root;
            QuickSort(list, start, index-1);
            QuickSort(list, index + 1, end);
        }
    }
}
