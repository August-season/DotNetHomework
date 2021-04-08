using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2-100的素数");
            int N = 100;
            bool[] a = new bool[N + 1];
            for (int i = 0; i <= N; i++) a[i] = true;

            for (int i = 2; i <= N; i++)
            {
                for (int j = 2 * i; j <= N; j += i)
                {
                    a[j] = false;
                }
            }

            for (int i = 2; i <= N; i++)
            {
                if (a[i]) Console.WriteLine(i);
            }
        }
    }
}
