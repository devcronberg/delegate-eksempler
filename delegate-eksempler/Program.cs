using System;

namespace delegate_eksempler
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Callback test");
            Console.WriteLine("-------------");
            ClassBackTest.Test();
            Console.WriteLine();

            Console.WriteLine("Log demo");
            Console.WriteLine("--------");
            LogDemoTest.Test();
            Console.WriteLine();

            Console.WriteLine("Regnemaskine demo");
            Console.WriteLine("-----------------");
            RegnemaskineTest.Test();
            Console.WriteLine();

            Console.WriteLine("Terning demo");
            Console.WriteLine("------------");
            TerningTest.Test();

        }



    }

    
}
