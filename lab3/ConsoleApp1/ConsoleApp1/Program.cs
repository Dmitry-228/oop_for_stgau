using System;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;
            var new_out = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(@"input.txt");
            Console.SetOut(new_out);
            Console.SetIn(new_in);

            int t = 0, N = 1;
            double X = 0, Y = 0, Z = 0;

            t = Convert.ToInt32(Console.ReadLine());
            N = Convert.ToInt32(Console.ReadLine());
            X = Convert.ToDouble(Console.ReadLine());
            Y = Convert.ToDouble(Console.ReadLine());

            if (t == 0)                      
            {
                double fact = 1.0;
                for (int n = 1; n <= N; n++)
                {
                    fact *= n; // n!
                    double num = (n % 2 == 1)
                        ? Math.Pow(Math.Cos(X), n) + Math.Abs(Y)
                        : Math.Pow(Math.Cos(Y), n) + Math.Abs(X);
                    double sign = (n % 2 == 1) ? 1.0 : -1.0;
                    Z += sign * (num / fact);
                }
            }

            if (t == 1)                       
            {
                int n = 1;
                double fact = 1.0;
                while (n <= N)
                {
                    fact *= n;
                    double num = (n % 2 == 1)
                        ? Math.Pow(Math.Cos(X), n) + Math.Abs(Y)
                        : Math.Pow(Math.Cos(Y), n) + Math.Abs(X);
                    double sign = (n % 2 == 1) ? 1.0 : -1.0;
                    Z += sign * (num / fact);
                    n++;
                }
            }

            if (t == 2)
            {
                if (N >= 1)
                {
                    int n = 1;
                    double fact = 1.0;
                    do
                    {
                        fact *= n;
                        double num = (n % 2 == 1)
                            ? Math.Pow(Math.Cos(X), n) + Math.Abs(Y)
                            : Math.Pow(Math.Cos(Y), n) + Math.Abs(X);
                        double sign = (n % 2 == 1) ? 1.0 : -1.0;
                        Z += sign * (num / fact);
                        n++;
                    } while (n <= N);
                }
            }

            Console.WriteLine(String.Format("{0:0.000000}", Z));

            Console.SetOut(save_out); new_out.Close();
            Console.SetIn(save_in); new_in.Close();
        }
    }
}
