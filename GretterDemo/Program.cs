using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GretterDemo
{
    public enum GreeterEnum { HI, BYE}

    public delegate void Greeter(GreeterEnum greeting = GreeterEnum.HI);

    class Europe
    {
        public void France (GreeterEnum greeting)
        {
            Console.WriteLine("{0}", greeting == GreeterEnum.HI ? "Bonjour" : "Au revoir");
        }

        public static void Germany(GreeterEnum greeting)
        {
            Console.WriteLine("{0}", greeting == GreeterEnum.HI ? "Hallo" : "Tschüss");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ///step III - instantiating the delegate
            Greeter canadian = Canada;
            Greeter punjabi = new Greeter(Punjab);
            Greeter french = new Europe().France;
            Greeter german = Europe.Germany;


            Greeter all = german;
            all += delegate (GreeterEnum greeting)
            {
                Console.WriteLine("{0}", greeting == GreeterEnum.HI ? "Ciao" : "Ciao");
            };

            all += (GreeterEnum greeting)=> Console.WriteLine("{0}", greeting == GreeterEnum.HI ? "Hola" : "Adio");
            Console.WriteLine("\n\nEuropeans saying Hi");
            all();

            Console.WriteLine("\n\nEuropeans saying Bye");
            all(GreeterEnum.BYE);

            //step IV - invoking the method
            Console.WriteLine("\n\n");
            canadian();
            punjabi(GreeterEnum.BYE);
            //french();
            //german(GreeterEnum.BYE);
            
        }

        //Step I - code the method
        static void Canada(GreeterEnum greeting)
        {
            Console.WriteLine("{0}", greeting == GreeterEnum.HI ? "Hi" : "Bye");
        }
        static void Punjab(GreeterEnum greeting)
        {
            Console.WriteLine("{0}", greeting == GreeterEnum.HI ? "Saat Shri Akal" : "Saat Shri Akal");
        }
    }
}
