using System;
using System.IO;

namespace Lab
{
    class Test
    {
        private string topic = "";
        private string question = "";
        private string answer = "";

        private Test() { }

        public Test(string t, string q, string a)
        {
            topic = t; question = q; answer = a;
        }

        public static Test ReadFrom(TextReader input)
        {
            string t = input.ReadLine() ?? "";
            string q = input.ReadLine() ?? "";
            string a = input.ReadLine() ?? "";
            return new Test(t, q, a);
        }

        public void WriteFields(TextWriter output)
        {
            output.WriteLine("Тема: {0}", topic);
            output.WriteLine("Вопрос: {0}", question);
            output.WriteLine("Ответ: {0}", answer);
        }

        public void ShowQuestion(TextWriter output)
        {
            output.WriteLine("*** Вопрос ***");
            output.WriteLine("Тема: {0}", topic);
            output.WriteLine(question);
        }

        public bool Check(string userAnswer)
        {
            if (userAnswer == null) return false;
            string ua = userAnswer.Trim();
            string ca = (answer ?? "").Trim();
            return string.Equals(ua, ca, StringComparison.OrdinalIgnoreCase);
        }

        public void WriteInfo(TextWriter output)
        {
            output.WriteLine("*** Инфо об объекте ***");
            output.WriteLine("topic = {0}", topic);
            output.WriteLine("question = {0}", question);
            output.WriteLine("answer = {0}", answer);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;
            var new_out = new StreamWriter("output.txt");
            var new_in = new StreamReader("input.txt");
                        // input.txt:
            // 1: тема
            // 2: вопрос
            // 3: правильный ответ
            // 4: ответ пользователя
            Console.SetOut(new_out);
            Console.SetIn(new_in);
            Test t = Test.ReadFrom(Console.In);
            Console.WriteLine("*** Поля данных ***");
            t.WriteFields(Console.Out);
            Console.WriteLine();
            t.ShowQuestion(Console.Out);
            string user = Console.ReadLine();           
            Console.WriteLine("Ваш ответ: {0}", user);
            bool ok = t.Check(user);
            Console.WriteLine(ok ? "Результат: верно" : "Результат: неверно");
            Console.WriteLine();
            t.WriteInfo(Console.Out);
            Console.SetOut(save_out); new_out.Close();
            Console.SetIn(save_in); new_in.Close();
        }
    }
}
