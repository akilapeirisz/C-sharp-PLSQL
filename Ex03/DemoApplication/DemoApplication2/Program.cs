using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApplication2
{
    class Program
    {
        enum Operations { ADD, DIVIDE, SUBTRACT, MULTIPLY, INVALID }
        static void Main(string[] args)
        {
            double x = Convert.ToDouble(args[0]);
            double y = Convert.ToDouble(args[2]);
            Operations opr = Operations.INVALID;
            try
            {
                opr = (Operations) Enum.Parse(typeof(Operations), args[1]);
            }
            catch (ArgumentException)
            {
            }
            double z = PerformOperation(x, y, opr);
            
            Console.WriteLine(z);
            Console.ReadKey();
        }
        static double PerformOperation(double var1, double var2, Operations opr)
        {
            double z = 0.0;

            switch (opr)
            {
                case Operations.ADD:
                    z = var1 + var2;
                    break;
                case Operations.SUBTRACT:
                    z = var1 - var2;
                    break;
                case Operations.MULTIPLY:
                    z = var1 * var2;
                    break;
                case Operations.DIVIDE:
                    z = var1 / var2;
                    break;
                case Operations.INVALID:
                    Console.WriteLine("Invalid operation");
                    break;
            }
            return z;
        }
    }
}
