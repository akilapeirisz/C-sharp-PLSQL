using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            double [] arr= new double[args.Length - 1];
            for(int i = 1; i < args.Length; i++)
            {
                arr[i-1] = Convert.ToDouble(args[i]);
            }

            double z = PerformOperation(args[0], arr);
            
            Console.WriteLine(z);
            Console.ReadKey();
        }

        static double PerformOperation(String opr, double []arr)
        {
            double z = arr[0];
            if (arr.Length > 0)
            {
                for (int i = 1; i < arr.Length; i++ )
                {
                    double y = arr[i];
                    switch (opr)
                    {
                        case "+":
                            z += y;
                            continue;
                        case "-":
                            z -= y;
                            continue;
                        case "*":
                            z *= y;
                            continue;
                        case "/":
                            z /= y;
                            continue;
                        default:
                            Console.WriteLine("Invalid operation");
                            break;
                    }
                }
            }
            return z;
        }
    }
}
