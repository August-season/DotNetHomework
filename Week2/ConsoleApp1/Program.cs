using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            Console.WriteLine("请输入想要分解成素数因子的整数：");
            s = Console.ReadLine();
            Console.WriteLine("素数因子有：");
            try
            {
                int n = int.Parse(s);
                Console.WriteLine(1);
                for(int i = 2; i <= n;i++)
                {
                    while (n % i == 0)
                    {
                        n /= i;
                        Console.WriteLine(i);
                    }
                }

            }catch(Exception e)
            {
                Console.WriteLine("输入错误"+e.Message);
            }
        }
    }
}
