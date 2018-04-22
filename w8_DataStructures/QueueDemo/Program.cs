using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue("Centennial");
            queue.Enqueue("Seneca");
            queue.Enqueue("Lambton");
            queue.Enqueue("Humber");
            queue.Print();
            Console.WriteLine();

            Console.WriteLine($"Dequeue -> {queue.Dequeue()}");
            Console.WriteLine();

            queue.Print();
            
            Console.ReadLine();
        }
    }

    public class Node
    {
        public string Data { get; private set; }

        public Node Next { get; set; }

        public Node(string data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }

    public class Queue
    {
        private Node first;

        public Queue(string data)
        {
            first = new Node(data);
        }


        public void Enqueue(string data)
        {
            Node oldFirst = first;
            first = new Node(data);
            first.Next = oldFirst;
        }

        public void Peek()
        {
            if (this.isEmpty())
            {
                Console.WriteLine("The Queue is empty");
            }
            else
            {
                Node last = first;
                do
                {
                    if (last.Next == null)
                    {
                        Console.WriteLine(last);

                        return;
                    }
                    last = last.Next;
                } while (last != null);
            }
            
        }

        public void Print()
        {
            StringBuilder result = new StringBuilder();
            if (!this.isEmpty())
            {
                Node current = first;
                do
                {
                    result.Append(current.ToString() + " ");
                    current = current.Next;

                } while (current != null);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("the queue is empty");
            }
        }

        public Node Dequeue()
        {
            if (first.Next == null)
            {
                Node oldFirst = first;
                first = null;
                return oldFirst;
            }

            else
            {

                Node node = first;
                Node previous = node;
                while (node.Next != null)
                {
                    previous = node;
                    node = node.Next;
                }
                previous.Next = null;
                return node;

            }
        }

        public bool isEmpty()
        {
            return first == null;
        }
    }
}
