using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] multArr = new int[11, 11];
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    multArr[i, j] = i * j;
                }
            }
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    if (multArr[i, j] < 10)
                    {
                        System.Console.Write("   ");
                        System.Console.Write(multArr[i, j]);
                    }
                    else if (multArr[i, j] >= 10 && multArr[i, j] < 100)
                    {
                        System.Console.Write("  ");
                        System.Console.Write(multArr[i, j]);
                    }
                    else
                    {
                        System.Console.Write(" ");
                        System.Console.Write(multArr[i, j]);
                    }

                }
                System.Console.WriteLine("\n");
            }
        }
    }
}
