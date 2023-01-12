using System;
using System.Collections.Generic;

namespace EnumerableToChunkApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] vs = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            var m = GetChunks<int>(vs, 3);
            foreach (var chunk in m)
            {
                foreach (var v in chunk)
                {
                    Console.Write(v + " ");
                }
                Console.WriteLine();
            }
            
        }

        static IEnumerable<IEnumerable<T>> GetChunks<T>(IEnumerable<T> collection, int ChunkLength)
        {
            using (var enumerator = collection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    yield return GetChunk(enumerator, ChunkLength);
                }
            }
        }

        static IEnumerable<T> GetChunk<T>(IEnumerator<T> enumerator, int ChunkLength)
        {
            int i = 0;
            yield return enumerator.Current;
            while (i<ChunkLength-1 && enumerator.MoveNext())
            {
                yield return enumerator.Current;
                i++;
            }
        }
    }
}
