using System;
using System.Collections.Generic;

namespace delegate_eksempler
{
    internal class RegnemaskineDemo
    {

        private Dictionary<string, BeregnDelegate> beregninger = new Dictionary<string, BeregnDelegate>();

        public void TilføjBeregning(string navn, BeregnDelegate beregning)
        {
            beregninger.Add(navn, beregning);
        }

        public void VisBeregninger()
        {
            Console.WriteLine("Følgende beregninger er tilgængelige:");

            if (beregninger.Count == 0)
            {
                Console.WriteLine("Ingen beregninger fundet");
            }
            else
            {
                foreach (KeyValuePair<string, BeregnDelegate> item in beregninger)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }

        public double Beregn(string navn, double a1, double a2)
        {
            return beregninger[navn].Invoke(a1, a2);
        }


    }

    public delegate double BeregnDelegate(double arg1, double arg2);

    internal class RegnemaskineTest
    {
        public static void Test()
        {

            RegnemaskineDemo r = new RegnemaskineDemo();
            BeregnDelegate p = new BeregnDelegate(Plus);
            r.VisBeregninger();
            r.TilføjBeregning("Plus", p);
            r.TilføjBeregning("Minus", Minus);
            r.VisBeregninger();
            Console.WriteLine("Tilføjer gange");
            r.TilføjBeregning("Gange", Gange);
            r.VisBeregninger();
            Console.WriteLine("Beregner med Minus");
            double res = r.Beregn("Minus", 10, 5);
            Console.WriteLine($"10 - 5 = {res}");

        }

        public static double Plus(double a, double b)
        {
            return a + b;
        }

        public static double Minus(double a, double b)
        {
            return a - b;
        }

        public static double Gange(double a, double b)
        {
            return a * b;
        }

    }

}
