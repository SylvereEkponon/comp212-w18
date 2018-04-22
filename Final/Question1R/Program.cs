using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1R
{
    // Can you fix the infinity loop
    class Program
    {
        static void Main(string[] args)
        {
            int Min = 1;
            int Max = 9999;
            Random randNum = new Random();
            int[] values = Enumerable
                .Repeat(0, 25)
                .Select(i => randNum.Next(Min, Max))
                .ToArray();

            Console.Write("Original array:\n");
            foreach (var element in values)
            {
                Console.Write($" {element}");
            }
            Console.WriteLine();
            var sorted =
               from value in values
               orderby value
               select value;

            Console.Write("\nSorted array in Ascending order:");
            foreach (var element in sorted)
            {
                Console.Write($" {element}");
            }
            var filtered = from value in values
                           where value % 2 == 0
                           select value;
            Console.WriteLine();
            Console.Write("\nArray of Even Numbers:");
            foreach (var element in filtered)
            {
                Console.Write($" {element}");
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine($"\nFirst number of array: {values.First()}");
            Console.WriteLine($"Last number of array: {values.Last()}");
            Console.WriteLine();
            Console.WriteLine("Min,Max ,Average and Sum using LINQ using single cores");
            Console.WriteLine("--------------------------------------------------");
            var linqStart = DateTime.Now;
            var linqMin = values.Min();
            var linqMax = values.Max();
            var linqAverage = values.Average();
            var linqSum = values.Sum();
            var linqEnd = DateTime.Now;
            // display results and total time in milliseconds
            var linqTime = linqEnd.Subtract(linqStart).TotalMilliseconds;
            DisplayResults(linqMin, linqMax, linqSum, linqAverage, linqTime);
            // time the Min, Max and Average PLINQ extension methods
            Console.WriteLine();
            Console.WriteLine("\nMin, Max, Average and Sum with PLINQ using multiple cores");
            Console.WriteLine(" ------------------------------------------------------");
            var plinqStart = DateTime.Now;
            var plinqMin = values.AsParallel().Min();
            var plinqMax = values.AsParallel().Max();
            var plinqAverage = values.AsParallel().Average();
            var plinqSum = values.AsParallel().Sum();
            var plinqEnd = DateTime.Now;
            // display results and total time in milliseconds
            var plinqTime = plinqEnd.Subtract(plinqStart).TotalMilliseconds;
            DisplayResults(plinqMin, plinqMax, plinqSum, plinqAverage, plinqTime);

            Console.WriteLine("\nPLINQ took " +
               $"{((linqTime - plinqTime) / linqTime):P0}" +
               " less time than LINQ");
            Console.ReadLine();
        }
        static void DisplayResults(
           int min, int max, double sum, double average, double time)
        {
            Console.WriteLine($"Min: {min}\nMax: {max}\nSum: {sum}\n" +
               $"Average: {average:F}\nTotal time in milliseconds: {time:F}");
        }
    }
}