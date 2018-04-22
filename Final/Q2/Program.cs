using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Q2
{
    class Program
    {
        static void Main(string[] args)
        {

            SortedDictionary<string, int> dictionary = CollectWords();

            DisplayDictionary(dictionary); // display sorted dictionary content

            Console.ReadLine();
        }


        private static SortedDictionary<string, int> CollectWords()
        {

            var dictionary = new SortedDictionary<string, int>();

            Console.WriteLine("Enter your string: ");
            string input = Console.ReadLine();
            input = Regex.Replace(input, @"\p{P}", "");


            string[] words = Regex.Split(input, @"\s+");



            foreach (var word in words)
            {
                var key = word.ToLower();


                if (dictionary.ContainsKey(key))
                {
                    ++dictionary[key];
                }
                else
                {

                    dictionary.Add(key, 1);
                }
            }

            return dictionary;
        }


        private static void DisplayDictionary<K, V>(
           SortedDictionary<K, V> dictionary)
        {
            Console.WriteLine($"\nDuplicate Words:\n{"Key",-12}{"Repetition",-12}");
            Console.WriteLine("----------------------");



            foreach (var key in dictionary.Keys)
            {
                int a = Convert.ToInt32(dictionary[key]);
                if (a > 1)
                {
                    Console.WriteLine($"{key,-12}{dictionary[key],-15}");
                }

            }

        }

    }
}