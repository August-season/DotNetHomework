using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = { { 1, 2, 3, 4 }, { 5, 1, 2, 3 }, { 9, 5, 1, 2 } };
            Console.WriteLine(isToeplitzMatrix(a));
            static bool isToeplitzMatrix(int[,] matrix)
            {
                int m = matrix.GetLength(0);
                int n = matrix.GetLength(1);
                for (int i = 0; i < m - 1; i++)
                {
                    for (int j = 0; j < n - 1; j++)
                    {
                        if (matrix[i,j] != matrix[i + 1,j + 1]) return false;
                    }
                }
                return true;
            }
        }
    }
}
