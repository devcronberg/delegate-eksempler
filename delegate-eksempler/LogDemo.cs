using System;
using System.Collections.Generic;
using System.Text;

namespace delegate_eksempler
{
    public delegate void LogDelegate(string txt);

    class LogDemo
    {
        private readonly LogDelegate log;

        public LogDemo(LogDelegate log)
        {
            this.log = log;
        }
        public void Start() {
            log?.Invoke("Starter");
            // kode
        }
        public void Stop() {
            log?.Invoke("Stopper");
            // kode
        }

    }

    

    public class LogDemoTest {

        public static void Test() {

            LogDelegate l = new LogDelegate(SkrivTilConsole);
            l += SkrivTilFil;
            LogDemo demo1 = new LogDemo(l);
            demo1.Start();
            demo1.Stop();
        }

        private static void SkrivTilConsole(string text) {
            Console.WriteLine(text);
        }
        private static void SkrivTilFil(string text) {
            System.IO.File.WriteAllText(@"c:\temp\log.txt", text);
        }


    }
}
