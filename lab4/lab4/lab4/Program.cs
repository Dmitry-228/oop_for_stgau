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

            int N = Convert.ToInt32(Console.ReadLine());
            string str_all = Console.ReadLine();
            string[] str_elem = str_all.Split(' ');

            int[] a = new int[N];
            for (int i = 0; i < N; i++)
                a[i] = Convert.ToInt32(str_elem[i]);

            bool hasOdd = false;
            int maxOdd = int.MinValue;

            long s = 0;

            for (int i = 0; i < N; i++)
            {
                int v = a[i];
                s += v;
                if (v % 2 != 0)
                {
                    if (!hasOdd || v > maxOdd) maxOdd = v;
                    hasOdd = true;
                }
            }

            double sa = 1.0 * s / N;

            if (hasOdd) Console.WriteLine(maxOdd);
            else Console.WriteLine("NO");

            Console.WriteLine(string.Format("{0:0.000000}", sa));

            bool hasEven = false;
            for (int i = 0; i < N; i++)
            {
                if (a[i] % 2 == 0)
                {
                    Console.Write(a[i] + " ");
                    hasEven = true;
                }
            }
            if (!hasEven) Console.Write("NO");
            Console.WriteLine();

            Console.SetOut(save_out); new_out.Close();
            Console.SetIn(save_in); new_in.Close();
        }
    }
}
