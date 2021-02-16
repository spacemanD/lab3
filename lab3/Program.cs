using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input set: ");
            string str = Console.ReadLine();
            int[] set = str.Split(" ").Select(Int32.Parse).ToArray();
            Console.Write("\nInput k - combinations: ");
            int combinations = int.Parse(Console.ReadLine());
            Console.WriteLine("\nAll combinations of the set: ");
            Console.WriteLine();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Permute(set, 0, set.Length - 1);
            stopwatch.Stop();
            Console.WriteLine($"Time efficiency: {stopwatch.ElapsedMilliseconds} ms\n");
            Console.WriteLine("K - combinations: ");
            Console.WriteLine();
            stopwatch.Restart();
            KCombinations(set, combinations);
            stopwatch.Stop();
            Console.WriteLine($"Time efficiency: {stopwatch.ElapsedMilliseconds} ms");
        }
        static int[] Swap(int[] set, int index1, int index2)
        {
            int temp = set[index1];
            set[index1] = set[index2];
            set[index2] = temp;
            return set;
        }
        static void Permute(int[] set, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                Console.WriteLine($"{string.Join(", ", set)}\n");
            }
            else
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    Swap(set, startIndex, i);
                    Permute(set, startIndex + 1, endIndex);
                    Swap(set, i, startIndex);
                }
            }
        }
        static void PrintCombinations(int[] arr, int[] data, int start, int end, int index, int r)
        {
            if (index == r)
            {
                for (int j = 0; j < r; j++)
                {
                    Console.Write(data[j] + " ");
                }
                Console.WriteLine("\n");
                return;
            }
            for (int i = start; i <= end;i++)
            {
                data[index] = arr[i];
                PrintCombinations(arr, data, i + 1, end, index + 1, r);
            }
        }
        static void KCombinations(int[] arr, int r)
        {
            int[] data = new int[r];
            PrintCombinations(arr, data, 0, arr.Length - 1, 0, r);
        }
    }
}
