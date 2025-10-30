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

            // Размеры матрицы: N — строки, M — столбцы
            int N = Convert.ToInt32(Console.ReadLine());
            int M = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("*** Input matrix ***");
            int[,] mas = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                string str_all = Console.ReadLine();
                string[] str_elem = str_all.Split(' ');
                for (int j = 0; j < M; j++)
                {
                    mas[i, j] = Convert.ToInt32(str_elem[j]);
                    Console.Write(mas[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("---Среднее арифмитическое---");
            double[] avg = new double[N];
            for (int i = 0; i < N; i++)
            {
                long s = 0;
                for (int j = 0; j < M; j++) s += mas[i, j];
                avg[i] = 1.0 * s / M;
                Console.WriteLine(string.Format("{0:0.000}", avg[i]));
            }

 
            Console.WriteLine("---Модифицированная матрица---");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (mas[i, j] > avg[i]) Console.Write("u ");
                    else Console.Write("x ");
                }
                Console.WriteLine();
            }

            Console.SetOut(save_out); new_out.Close();
            Console.SetIn(save_in); new_in.Close();
        }
    }
}
