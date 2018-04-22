using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W10_demo
{
    class Program
    {
        static void BubbleSearch(int[] num)
        {
            for (int j = 0; j < num.Length-1; j++)
            {
                for (int i = 0; i < num.Length-1; i++)
                {
                    if (num[i]>num[i+1])
                    {
                        int tmp = num[i];
                        num[i] = num[i + 1];
                        num[i + 1] = tmp;
                    }
                }
            }
        }

        static void BubbleSearch2(int[] num)
        {
            for (int j = 0; j < num.Length - 1; j++)
            {
                bool isSorted = true;
                for (int i = 0; i < num.Length - 1 - j; i++)
                {
                    if (num[i] > num[i + 1])
                    {
                        isSorted = false;
                        int tmp = num[i];
                        num[i] = num[i + 1];
                        num[i + 1] = tmp;
                    }
                }
                if (isSorted) return;
            }
        }

        static LinkedList<LinkedListNode<int>> CreateLinkedList(int size)
        {
            int[] values = CreateArray(size);
            LinkedList<LinkedListNode<int>> result = new LinkedList<LinkedListNode<int>>();
            foreach (var x in values)
            {
                result.AddLast(new LinkedListNode<int>(x));
            }
            return result;
        }
        static void BubbleSort(LinkedList<LinkedListNode<int>> list)
        {
            for (int j = 0; j < list.Count - 1; j++)
            {
                for (int i = 0; i < list.Count -1 - j ; i++)
                {
                    if (list.ElementAt(i).Value>list.ElementAt(i+1).Value)
                    {
                        int tmp = list.ElementAt(i).Value;
                        list.ElementAt(i).Value = list.ElementAt(i + 1).Value;
                        list.ElementAt(i + 1).Value = tmp;
                    }
                }
            }
        }

        static void PrintLinkedList(LinkedList<LinkedListNode<int>> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item.Value} ");
            }
        }
        static List<Person> persons = new List<Person>()
        {
            new Person("Victor", "Almeida", "Brazil"),
            new Person("Riddhi", "Amin", "India"),
            new Person("Varsha", "Chaudary", "India"),
            new Person("Manmeet", "Singh", "Canada"),
            new Person("Alnessa", "Villondo", "Canada"),
            new Person("Anju", "Thappa", "Nepal"),
            new Person("Yesol", "Lee", "Korea"),
            new Person("Min", "GiJang", "Korea")
        };
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            int size = 10;
            LinkedList<LinkedListNode<int>> values = CreateLinkedList(size);
            Console.WriteLine("\nunsorted list");
            PrintLinkedList(values);
            BubbleSort(values);

            Console.WriteLine("\nsorted list");
            PrintLinkedList(values);

            Console.ReadLine();

            //int[] values = CreateArray(size);
            //Console.WriteLine();
            //PrintArray(values);
            //watch.Start();
            //BubbleSearch(values);
            //watch.Stop();
            //Console.WriteLine();
            //PrintArray(values);


        }

        static int [] CreateArray(int size)
        {
            Random rnd = new Random(1234);//uses a seed 
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = rnd.Next(10, 100);
            }
            return result;
        }

        static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
        }
        static void DemoList()
        {

        }

        static void DemoDictionary()
        {
            Dictionary<string, Person> myDictionary = new Dictionary<string, Person>();
            foreach (var p in persons)
            {
                myDictionary.Add(p.FName, p);
            }
            foreach (var item in myDictionary)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
    class Person
    {
        public string FName;
        public string LName;
        public string Origin;

        public Person(string fname, string lname, string origin)
        {
            FName = fname; LName = lname;Origin = origin;
        }

        public override string ToString() => $"{FName} {LName} {Origin.Substring(0,3).ToUpper()}";

    }
}
