using System;
using System.IO;

namespace Test
{
    class Sphere
    {
        private double r = 1;

        public double Radius
        {
            get { return r; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("R");
                r = value;
            }
        }

        public void ReadFrom(TextReader input)
        {
            Radius = Convert.ToDouble(input.ReadLine());
        }

        public void WriteFields(TextWriter output)
        {   
            output.WriteLine("R = {0:0.00}", r);
        }

        public double Diameter() { return 2 * r; }
        public double SurfaceArea() { return 4 * Math.PI * r * r; }
        public double Volume() { return 4.0 / 3.0 * Math.PI * r * r * r; }

        public void WriteInfo(TextWriter output)
        {
            output.WriteLine("Сфера");
            output.WriteLine("R = {0:0.00}", r);
            output.WriteLine("D = {0:0.00}", Diameter());
            output.WriteLine("S = {0:0.00}", SurfaceArea());
            output.WriteLine("V = {0:0.00}", Volume());
        }
    }

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

            var s = new Sphere();
            try
            {
                s.ReadFrom(Console.In);

                Console.WriteLine("Поля");
                s.WriteFields(Console.Out);

                Console.WriteLine("Информация о полях");
                s.WriteInfo(Console.Out);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            Console.SetOut(save_out); new_out.Close();
            Console.SetIn(save_in); new_in.Close();
        }
    }
}
