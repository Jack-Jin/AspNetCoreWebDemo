using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using MyLocalization.Resources;

namespace MyLocalization
{
    class Program
    {
        static void Main(string[] args)
        {
            ResourceManager rm = new ResourceManager("MyLocalization.Resources.rs1",  typeof(Program).Assembly);
            //ResourceManager rm = new ResourceManager("MyLocalization.Resources.rs1",  Assembly.GetExecutingAssembly());

            string day = rm.GetString("Hello");
            Console.WriteLine("MyLocalization.Resources.rs1: " + day);

            CultureInfo ci = new CultureInfo("fr-FR");

            string day1 = rm.GetString("Hello", ci);
            Console.WriteLine("MyLocalization.Resources.rs1 (fr-FR): " + day1);

            //Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            rs1.Culture = new CultureInfo("fr-FR");
            Console.WriteLine(rs1.Hello);

            ResourceManager rm2 = new ResourceManager("MyLocalization.Resources.rs2", typeof(Program).Assembly);
            Console.WriteLine(rm2.GetString("Hello"));
            Console.WriteLine(rm2.GetString("Hello",new CultureInfo("fr-FR")));

            Console.ReadKey();
        }
    }
}
