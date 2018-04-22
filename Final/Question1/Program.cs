using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(1234);//uses a seed 
            int[] result = new int[25];
            for (int i = 0; i < 25; i++)
            {
                result[i] = rnd.Next(1, 9999);
            }

            Console.WriteLine("Original Array: ");
            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            var sorted = result.OrderBy(x=>x);
            Console.WriteLine("Sorted Array");
            foreach (var item in sorted)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();


            var evenNumber = result.Where(x => x % 2 == 0);
            Console.WriteLine("Even Number");
            foreach (var item in evenNumber)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.WriteLine($"\nFirst number of array: {result.First()}");
            Console.WriteLine($"Last number of array: {result.Last()}");

            Console.WriteLine("\n\nMin,Max and Average with LINQ");
            Console.WriteLine("--------------------------------------------------");
            var startTime = DateTime.Now;
            var minValue = result.Min();
            var maxValue = result.Max();
            var avgValue = result.Average();
            var endTime = DateTime.Now;
            var time = endTime.Subtract(startTime).TotalMilliseconds;

            Console.WriteLine($"Min:{minValue} Max:{maxValue} Average:{avgValue} Time:{time}");


            Console.WriteLine("\n\nMin,Max and Average with PLINQ");
            Console.WriteLine("--------------------------------------------------");
            var pstartTime = DateTime.Now;
            var pminValue = result.AsParallel().Min();
            var pmaxValue = result.AsParallel().Max();
            var pavgValue = result.AsParallel().Average();
            var pendTime = DateTime.Now;
            var pTime = pendTime.Subtract(pstartTime).TotalMilliseconds;

            Console.WriteLine($"Min:{pminValue} Max:{pmaxValue} Average:{pavgValue} Time:{pTime}");

        }


    }
}
