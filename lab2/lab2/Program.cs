using System;

class Program
{
    static void Main()
    {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double d = double.Parse(Console.ReadLine());
            double e = double.Parse(Console.ReadLine());

            double numS = 4 * d - b + 1;      
            double denS_inside = a - 2 * c;   
            double insideK = b - c;           

            if (numS < 0 || denS_inside < 0 || insideK < 0 || e == 0)
            {
                Console.WriteLine("ERROR");
                return;
            }

            double denS = Math.Sqrt(denS_inside) + 1; // знаменатель для s
            if (denS == 0)
            {
                Console.WriteLine("ERROR");
                return;
            }

            double insideK2 = a - Math.Sqrt(insideK);
            if (insideK2 < 0)
            {
                Console.WriteLine("ERROR");
                return;
            }

            double s = Math.Sqrt(numS) / denS;
            double k = Math.Sqrt(insideK2) / e;

            Console.WriteLine($"{s:F4} {k:F4}");
    }
}
