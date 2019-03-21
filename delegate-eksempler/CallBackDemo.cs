using System;
using System.Collections.Generic;
using System.Text;

namespace delegate_eksempler
{

    public delegate void GørNogetPåTidSuccesDelegate(int ms);
    public delegate void GørNogetPåTidFejlDelegate(Exception ex);

    class CallBackDemo
    {
        public static void GørNogetPåTid(GørNogetPåTidSuccesDelegate færdig, GørNogetPåTidFejlDelegate fejl) {

            try
            {
                int t = new Random().Next(0, 1000);
                System.Threading.Thread.Sleep(t);
                færdig?.Invoke(t);
            }
            catch (Exception ex)
            {
                fejl?.Invoke(ex);
            }
        }

    }

    

    class ClassBackTest
    {
        public static void Test()
        {


            // Oprettelse af delegate-objekter
            GørNogetPåTidSuccesDelegate s = new GørNogetPåTidSuccesDelegate(VisTid);
            GørNogetPåTidFejlDelegate f = new GørNogetPåTidFejlDelegate(VisFejl);
            CallBackDemo.GørNogetPåTid(s, f);

            // Lad compileren selv skabe delegate objekter
            CallBackDemo.GørNogetPåTid(VisTid, VisFejl);

            // Brug lambda (anonyme metoder) - og lad compileren selv skabe delegate objekter
            CallBackDemo.GørNogetPåTid(
                ms => Console.WriteLine("Det tog " + ms + " ms"),
                ex => Console.WriteLine("Hov - fejl - " + ex.Message)
            );
        }


        static void VisTid(int ms)
        {
            Console.WriteLine("Det tog " + ms + " ms");
        }

        static void VisFejl(Exception ex)
        {
            Console.WriteLine("Hov - fejl - " + ex.Message);
        }

        


    }
}
