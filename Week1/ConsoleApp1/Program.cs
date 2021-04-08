using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "";
            string c = "";
            string b = "";
            Console.WriteLine("输入第一个数字");
            a = Console.ReadLine();
            Console.WriteLine("输入运算符号");
            c = Console.ReadLine();
            Console.WriteLine("输入第二个数字");
            b = Console.ReadLine();

            try
            {
                int A = int.Parse(a);
                int B = int.Parse(b);
                switch (c)
                {
                    case "+":
                        Console.WriteLine($"运算结果是{A + B}");
                        break;
                    case "-":
                        Console.WriteLine($"运算结果是{A - B}");
                        break;
                    case "*":
                        Console.WriteLine($"运算结果是{A * B}");
                        break;
                    case "/":
                        Console.WriteLine($"运算结果是{A / B}");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("解析错误" + e.Message);
            }

        }
    }
}
