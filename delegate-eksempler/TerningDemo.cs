using System;
using System.Collections.Generic;
using System.Text;

namespace delegate_eksempler
{
    public delegate void ErSekserDelegate();

    class TerningDemo
    {
        private Random rnd = new Random();
        public int Værdi { get; set; }
        public ErSekserDelegate ErSekser { get; set; }


        public void Ryst() {
            this.Værdi = rnd.Next(1, 7);
            if (this.Værdi == 6)
                ErSekser?.Invoke();
        }

        public TerningDemo()
        {
            Ryst();
        }

        public override string ToString()
        {
            return "[" + Værdi + "]";
        }
    }

    class TerningTest {
        public static void Test() {
            TerningDemo t = new TerningDemo();
            t.ErSekser = NårDerKommerEnSekser;
            for (int i = 0; i < 12; i++)
            {
                t.Ryst();
                Console.WriteLine(t);
            }
        }

        private static void NårDerKommerEnSekser()
        {
            Console.WriteLine("SEKSER!!!!");
        }
    }
}
