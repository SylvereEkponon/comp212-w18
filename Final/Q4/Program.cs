using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            Random random = new Random();
            int[] values = Enumerable.Repeat(0, 60000000)
                .Select(x => random.Next(1, 7)).ToArray();
            var groupByValue = values.GroupBy(x => x).OrderBy(x=>x.Key);
            foreach (var item in groupByValue)
            {
                Console.WriteLine($"{item.Key} ===> {item.Count()} times");
                total += item.Count();
            }
            Console.WriteLine($"\nTotal:{total}"); 
                
        }
    }
}
