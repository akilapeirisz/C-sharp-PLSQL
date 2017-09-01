using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Resources;
using System.Reflection;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cultures = { "en-CA", "en-US", "fr-FR"};
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
            try
            {
                Thread.CurrentThread.CurrentUICulture  = new CultureInfo(cultures[2]);
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultures[2]);
                ResourceManager rm = new ResourceManager("ConsoleApplication2.Resource2", Assembly.GetExecutingAssembly());
                Console.WriteLine("Translated: {0}", rm.GetString("stringConst"));
            }
            catch (CultureNotFoundException e)
            {
                Console.WriteLine("Unable to instantiate culture{0}", e.InvalidCultureName);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
                Thread.CurrentThread.CurrentUICulture = originalCulture;
            } 
            Console.ReadKey();
        }
    }
}
