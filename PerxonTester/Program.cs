using PersonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerxonTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = Person.CreatePerson("Donald", "Trump");
            Console.WriteLine(person);

            Person person2 = Person.CreatePerson("Solanky", "Taraja");
            Console.WriteLine(person);
            Console.WriteLine(Person.CreatePerson("Sylvere","Ekponon"));
            person = Person.CreatePerson("Solanky", "Thareja");
            person = Person.CreatePerson("Solanky", "Thareja");
            person = Person.CreatePerson("Solanky", "Thareja");

            //Person person3 = new Person("Solanky", "Thareja");
        }
    }
}
