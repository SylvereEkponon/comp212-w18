using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w8_DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Print();
            stack.Pop();
            stack.Pop();
            stack.Print();
            stack.Pop();
            stack.Print();
        }
    }

    public class Node
    {
        public int Data { get; private set; }

        public Node Next { get; set; }

        public Node (int data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }

    public class Stack
    {
        private Node first;
        public Stack(int data)
        {
            first = new Node(data);
        }

        public void Push(int data)
        {
            Node oldFirst = first;
            first = new Node(data);
            first.Next = oldFirst;
        }

        public void Pop()
        {
            try
            {
                
                Node previous = first;

                first = first.Next;

                Console.WriteLine(previous);
            }
            catch (Exception)
            {

                Console.WriteLine("the stack is empty");
            }
            
        }

        public void Print()
        {
            if (!this.isEmpty())
            {
                Node current = first;
                do
                {
                    Console.Write($"{current} ");
                    current = current.Next;

                } while (current != null);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("the stack is empty");
            }
            

        }
        public bool isEmpty()
        {
            return first==null;
        }
    }
}
