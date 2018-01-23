using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class Person
    {
        static int MAX_PERSON = 5, PERSON_COUNT = 0;
        public string FName { get; }
        public string LName { get; }

        Person(string fname, string lname)
        {
            FName = fname;
            LName = lname;
            PERSON_COUNT++;
        }

        public static Person CreatePerson(string fname, string lname)
        {
            if (PERSON_COUNT < MAX_PERSON)
            {
                return new Person(fname, lname);
            }
            throw new Exception("ERROR: Limit exceed");
        } 

        public override string ToString()
        {
            return $"{FName} {LName}";
        }

    }
}
