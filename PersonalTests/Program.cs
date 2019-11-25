using System;
using System.Collections.Generic;

namespace KatasSolutions
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var datas = GenerateWordList(50);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var longestConsecutiveStrings = Kata.LongestConsec(datas, 11);
            Kata.LongestConsec(datas, 7);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(longestConsecutiveStrings);
            Console.WriteLine("time elapsed = " + elapsedMs + " ms");
            Console.ReadKey();
        }

        private static string[] GenerateWordList(int size)
        {
            List<string> words = new List<string>();
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                words.Add(new string('a', rand.Next(1, 10)));
            }
            return words.ToArray();
        }
    }
}