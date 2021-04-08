using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = "";
            Console.WriteLine("请输入数组a，数字间用逗号隔开");
            s = Console.ReadLine();
            String[] strArray = s.Split('，',',');
            int[] intArray = StringToInt(strArray);
            Console.WriteLine("数组最大值"+maxNumber(intArray));
            Console.WriteLine("数组最小值" + minNumber(intArray));
            Console.WriteLine("数组平均值" + aveNumber(intArray));
            Console.WriteLine("数组总和" + sumNumber(intArray));
        }
        static int maxNumber(int[] a)
        {                
            int max=0;
            for(int i=0;i<=a.Length-1 ; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }
            return max;
        }

        static int minNumber(int[] a)
        {   
            int min = 127;
            for (int i = 0; i <= a.Length -1; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
            }
            return min;
        }

        static int sumNumber(int[] a)
        {
            int sum = 0;
            for (int i=0;i<=a.Length-1;i++)
            {
                sum = sum + a[i];
            }
            return sum;
        }

        static int aveNumber(int[] a)
        {  
           int ave=sumNumber(a)/a.Length;
            return ave;
        }

        static int[] StringToInt(String[] arrs)
        {

            int[] ints = new int[arrs.Length];

            for (int i = 0; i < arrs.Length; i++)
            {

                ints[i] = int.Parse(arrs[i]);

            }

            return ints;

        }
    }
}
