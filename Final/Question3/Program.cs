using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "Mary", "got", "a", "little", "lamb" };
            LinkedList<string> linkWord = new LinkedList<string>(words);
            //linkWord.AddFirst("lamb");
            //linkWord.AddFirst("little");
            //linkWord.AddFirst("a");
            //linkWord.AddFirst("got");
            //linkWord.AddFirst("Mary");
            

            foreach (var item in linkWord)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();

            //Add today
            linkWord.AddFirst("Today");

            foreach (var item in linkWord)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            //move today
            LinkedListNode<string> first = linkWord.First;
            linkWord.Remove(first.Value);
            linkWord.AddLast(first.Value);


            //change the last node to "yesterday"
            linkWord.Find("Today").Value = "yesterday";


            // Insert a node after "Mary"
            LinkedListNode<string> node = linkWord.Find("Mary");
            linkWord.AddAfter(node, "Stuart");

            //Insert a node before "lamb"
            LinkedListNode<string> linked = linkWord.Find("lamb");
            linkWord.AddBefore(linked, "white");

            foreach (var item in linkWord)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
