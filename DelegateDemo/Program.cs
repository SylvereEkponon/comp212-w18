using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    //STEP ONE
    public delegate void MyDelegate();

    class AnotherClass
    {
        public static void Clinton() { Console.WriteLine("Done By Clinton"); }

        public  void Justin() { Console.WriteLine("Done By Justine"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //STEP THREE
            MyDelegate Mydel = Eve;

            Mydel = AnotherClass.Clinton;

            Mydel = new AnotherClass().Justin;

            //STEP FOUR
            Mydel();
        }

        //STEP TWO  
        static void Eve() { Console.WriteLine("Done by Eve"); }
    }
}
