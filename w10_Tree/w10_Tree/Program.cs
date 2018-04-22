using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w10_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree t = new Tree(25);
            t.Add(10);
            t.Add(40);
            t.Add(19);
            t.Add(30);
            t.Add(16);
            t.Add(29);
            Console.WriteLine(t);
            t.PrintInPreOrder();
            t.PostOrderTraversal();
            Console.WriteLine("There are {0} items in this tree", t.Count);
            int value = 30;
            Console.WriteLine("{0} is {1}present", value, t.Contains(value) ? "" : "not ");
            value = 17;
            Console.WriteLine("{0} is {1}present", value, t.Contains(value) ? "" : "not ");

        }
    }

    //The Node class
    public class Node
    {
        public Node Left;
        public Node Right;
        public int data;
        public Node(int data)
        {
            this.data = data;
        }
    }

    public class Tree
    {
        public Node root;

        //The ToString method
        public override string ToString()
        {
            //The ToStringHelper method (local method) illustrate tree traversal
            //This technique is called in-order traversal
            string ToStringHelper(Node branch)
            {
                if (branch == null)
                {
                    return "";
                }
                else
                {
                    return ToStringHelper(branch.Left) + " " + branch.data + " " + ToStringHelper(branch.Right);
                }
                //string left = (branch.Left != null) ? ToStringHelper(branch.Left) : "";
                //string right = (branch.Right != null) ? ToStringHelper(branch.Right) : "";
                //return left + branch.data + " " + right;
            }
            return ToStringHelper(root);
        }

        public void PrintInPreOrder()
        {

            void PreOrderTraversal(Node current)
            {

                if (current != null)
                {
                    Console.Write($"{current.data} ");
                    PreOrderTraversal(current.Left);
                    PreOrderTraversal(current.Right);
                }
            }
            PreOrderTraversal(root);
            Console.WriteLine();
        }

        public void PostOrderTraversal()
        {
            void PostOrder(Node node)
            {
                if (node != null)
                {
                    PostOrder(node.Left);
                    PostOrder(node.Right);
                    Console.Write($"{node.data} ");
                }
            }
            PostOrder(root);
            Console.WriteLine();
        }


        public Tree(int data)
        {
            root = new Node(data);
            Count++;
        }

        public void Add(int data)
        {
            Node node = new Node(data);
            Node current = root;
            while (true)
            {
                Node tmpCurrent = current;
                if (current.data > data)
                {
                    current = current.Left;
                    if (current==null)
                    {
                        tmpCurrent.Left = node;
                        Count++;
                        return;
                    }
                }
                else
                {
                    current = current.Right;
                    if (current==null)
                    {
                        tmpCurrent.Right = node;
                        Count++;
                        return;
                    }
                }
            }
          
        }

        public void AddR(int data)
        {
            Node node = new Node(data);
            Node current = root;
            if (current.data>data)
            {
                current = current.Left;
                if (current==null)
                {
                    
                }
            }
        }

        public bool Contains(int data)
        {
            Node node = root;
            int result;
            while (node!=null)
            {
                result = node.data.CompareTo(data);
                if (result==0)
                {
                    return true;
                }
                else if (result>0)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }           
            }
            return false;
        }

        public int Count
        {
            get; private set;         
            
        }

    }

}
