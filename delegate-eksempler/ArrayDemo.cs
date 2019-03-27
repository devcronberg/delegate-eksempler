using System;

namespace delegate_eksempler
{
    public class ArrayTest
    {
        public static void Test()
        {
            Person[] p = new Person[4];
            p[0] = new Person { Navn = "a", Alder = 10, Postnummer = 1100 };
            p[1] = new Person { Navn = "b", Alder = 15, Postnummer = 5270 };
            p[2] = new Person { Navn = "c", Alder = 5, Postnummer = 2300 };
            p[3] = new Person { Navn = "d", Alder = 20, Postnummer = 2600 };

            Person FindPerson1(Person[] a)
            {
                foreach (Person item in a)
                {
                    if (item.Alder == 15 && item.Postnummer == 5270)
                    {
                        return item;
                    }
                }
                return null;
            }
            Person res1 = FindPerson1(p);
            Console.WriteLine($"Har fundet {res1.Navn}");

            bool FindPerson2(Person a)
            {
                return a.Alder == 15 && a.Postnummer == 5270;
            }
            Person res2 = System.Array.Find(p, FindPerson2);
            Console.WriteLine($"Har fundet {res2.Navn}");

            Person res3 = System.Array.Find(p, i => i.Alder == 15 && i.Postnummer == 5270);
            Console.WriteLine($"Har fundet {res3.Navn}");

        }


    }

    internal class Person
    {
        public string Navn { get; set; }
        public int Alder { get; set; }
        public int Postnummer { get; set; }
    }
}
