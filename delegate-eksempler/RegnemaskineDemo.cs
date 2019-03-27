using System;
using System.Collections.Generic;

namespace delegate_eksempler
{
    internal class RegnemaskineDemo
    {

        private Dictionary<string, BeregnDelegate> beregninger = new Dictionary<string, BeregnDelegate>();

        public RegnemaskineDemo()
        {
            TilføjBeregning("Plus", P);
            TilføjBeregning("Minus", M);

            double P(double a, double b)
            {
                return a + b;
            }
            double M(double a, double b)
            {
                return a - b;
            }

        }

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
            r.VisBeregninger();
            Console.WriteLine("Tilføjer gange og divider");
            r.TilføjBeregning("Gange", Gange);
            r.TilføjBeregning("Divider", Divider);
            r.VisBeregninger();
            Console.WriteLine("Beregner med Gange");
            double res = r.Beregn("Gange", 10, 5);
            Console.WriteLine($"10 * 5 = {res}");

            Console.WriteLine("Beregner med Divider");
            res = r.Beregn("Divider", 10, 5);
            Console.WriteLine($"10 / 5 = {res}");

        }


        public static double Gange(double a, double b)
        {
            return a * b;
        }

        public static double Divider(double a, double b)
        {
            return a / b;
        }


    }

}
