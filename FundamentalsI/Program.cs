using System;

namespace FundamentalsI
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create a Loop that prints all values from 1 - 255
            for (int i = 1; i < 256; i++)
            {
                Console.WriteLine(i);
            }

            // Create a new loop that prints all values from 1 - 100 that are divisible by 3 or 5, but not both
            for (int i = 1; i <= 100; i++)
            {
                if ((i % 3 == 0 || i % 5 == 0) && i % 15 != 0)
                {
                    Console.WriteLine(i);
                }
            }
            // Modify the previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            // (Optional) If you used "for" loops for your solution, try doing the same with "while" loops.Vice - versa if you used "while" loops!
            // Create a Loop that prints all values from 1 - 255
            int j = 1;
            while (j < 256)
            {
                Console.WriteLine(j);
                j++;
            }
            // Create a new loop that prints all values from 1 - 100 that are divisible by 3 or 5, but not both
            j = 1;
            while (j <= 100)
            {
                if ((j % 3 == 0 || j % 5 == 0) && j % 15 != 0)
                {
                    Console.WriteLine(j);
                }
                j++;
            }
            // Modify the previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5
            j = 1;
            while (j <= 100)
            {
                if (j % 3 == 0 && j % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (j % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (j % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(j);
                }
                j++;
            }
        }
    }
}
