using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApplication
{
    class Program
    {
        enum Colors {green, red, blue}
        static void Main(string[] args)
        {
            double x = Convert.ToDouble(args[0]);
            double y = Convert.ToDouble(args[2]);
            double z = 0.0;
            switch(args[1])
            {
	            case "+":
                    z = x + y;
                    break;
                case "-":
                    z = x - y;
                    break;
                case "*":
                    z = x * y;
                    break;
                case "/":
                    z = x / y;
                    break; 
            }
            Console.WriteLine(z);
            Colors col = Colors.blue;
            Console.WriteLine(col);
            Console.ReadKey();
        }
    }
}
