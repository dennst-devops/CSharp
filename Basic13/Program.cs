using System;
using System.Collections.Generic;

namespace Basic13
{
    class Program
    {
        // Print 1-255
        public static void PrintNumbers()
        {
            // Print all of the integers from 1 to 255.
            System.Console.WriteLine("PrintNumbers");
            System.Console.WriteLine("======================================================");
            for (int i = 1; i <= 255; i++)
            {
                System.Console.WriteLine(i);
            }
        }

        // Print odd numbers between 1-255
        public static void PrintOdds()
        {
            // Print all of the odd integers from 1 to 255.
            System.Console.WriteLine("PrintOdds");
            System.Console.WriteLine("======================================================");
            for (int i = 1; i <= 255; i += 2)
            {
                System.Console.WriteLine(i);
            }
        }

        // Print Sum
        public static void PrintSum()
        {
            // Print all of the numbers from 0 to 255, 
            // but this time, also print the sum as you go. 
            // For example, your output should be something like this:

            // New number: 0 Sum: 0
            // New number: 1 Sum: 1
            // New Number: 2 Sum: 3
            System.Console.WriteLine("PrintSum");
            System.Console.WriteLine("======================================================");
            int sum = 0;
            for (int i = 1; i <= 255; i++)
            {
                sum += i;
                System.Console.Write("Number: ");
                System.Console.Write(i);
                System.Console.Write("   Total: ");
                System.Console.Write(sum);
                System.Console.Write("\n");
            }
        }

        // Iterating through an Array
        public static void LoopArray(int[] numbers)
        {
            // Write a function that would iterate through each item of the given integer array and 
            // print each value to the console. 
            System.Console.WriteLine("LoopArray");
            System.Console.WriteLine("======================================================");
            for (int i = 0; i < numbers.Length; i++)
            {
                System.Console.WriteLine(numbers[i]);
            }
        }

        // Find Max
        public static int FindMax(int[] numbers)
        {
            // Write a function that takes an integer array and prints and returns the maximum value in the array. 
            // Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), 
            // or even a mix of positive numbers, negative numbers and zero.
            System.Console.WriteLine("FindMax");
            System.Console.WriteLine("======================================================");
            int max = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            System.Console.WriteLine(max);
            return max;
        }

        // Get Average
        public static void GetAverage(int[] numbers)
        {
            // Write a function that takes an integer array and prints the AVERAGE of the values in the array.
            // For example, with an array [2, 10, 3], your program should write 5 to the console.
            System.Console.WriteLine("GetAverage");
            System.Console.WriteLine("======================================================");
            float myavg = 0;
            float mytotal = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                mytotal += (float)numbers[i];
            }
            myavg = mytotal / numbers.Length;
            System.Console.WriteLine(myavg);
        }

        // Array with Odd Numbers
        public static int[] OddArray()
        {
            // Write a function that creates, and then returns, an array that contains all the odd numbers between 1 to 255. 
            // When the program is done, this array should have the values of [1, 3, 5, 7, ... 255].
            System.Console.WriteLine("OddArray");
            System.Console.WriteLine("======================================================");
            int[] numArray = new int[128];
            numArray[0] = 1;
            for (int i = 1; i < numArray.Length; i++)
            {
                numArray[i] = numArray[i - 1] + 2;
            }
            for (int i = 0; i < numArray.Length; i++)
            {
                System.Console.WriteLine(numArray[i]);
            }
            return numArray;
        }

        // Greater than Y
        public static int GreaterThanY(int[] numbers, int y)
        {
            // Write a function that takes an integer array, and a integer "y" and returns the number of array values 
            // That are greater than the "y" value. 
            // For example, if array = [1, 3, 5, 7] and y = 3. Your function should return 2 
            // (since there are two values in the array that are greater than 3).
            System.Console.WriteLine("GreaterThanY");
            System.Console.WriteLine("======================================================");
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > y)
                {
                    count++;
                }
            }
            System.Console.WriteLine(count);
            return count;
        }

        // Square the Values
        public static void SquareArrayValues(int[] numbers)
        {
            // Write a function that takes an integer array "numbers", and then multiplies each value by itself.
            // For example, [1,5,10,-10] should become [1,25,100,100]
            System.Console.WriteLine("SquareArrayValues");
            System.Console.WriteLine("======================================================");
            for (int i = 0; i < numbers.Length; i++)
            {
                System.Console.WriteLine(numbers[i] * numbers[i]);
            }
        }

        // Eliminate Negative Numbers
        public static void EliminateNegatives(int[] numbers)
        {
            // Given an integer array "numbers", say [1, 5, 10, -2], create a function that replaces any negative number with the value of 0. 
            // When the program is done, "numbers" should have no negative values, say [1, 5, 10, 0].
            System.Console.WriteLine("EliminateNegatives");
            System.Console.WriteLine("======================================================");
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers[i] = 0;
                }
                System.Console.WriteLine(numbers[i]);
            }
        }

        // Min, Max, and Average
        public static void MinMaxAverage(int[] numbers)
        {
            // Given an integer array, say [1, 5, 10, -2], create a function that prints the maximum number in the array, 
            // the minimum value in the array, and the average of the values in the array.
            System.Console.WriteLine("MinMaxAverage");
            System.Console.WriteLine("======================================================");
            int max = numbers[0];
            int min = numbers[0];
            int sum = 0;
            double avg = 0.0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    max = numbers[i];
                }
                if (numbers[i] < numbers[i - 1])
                {
                    min = numbers[i];
                }
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            avg = (double)sum / numbers.Length;
            System.Console.WriteLine(min);
            System.Console.WriteLine(max);
            System.Console.WriteLine(avg);
        }

        // Shifting the values in an array
        public static void ShiftValues(int[] numbers)
        {
            // Given an integer array, say [1, 5, 10, 7, -2], 
            // Write a function that shifts each number by one to the front and adds '0' to the end. 
            // For example, when the program is done, if the array [1, 5, 10, 7, -2] is passed to the function, 
            // it should become [5, 10, 7, -2, 0].
            System.Console.WriteLine("ShiftValues");
            System.Console.WriteLine("======================================================");
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                numbers[i] = numbers[i + 1];
            }
            numbers[numbers.Length - 1] = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                System.Console.WriteLine(numbers[i]);
            }
        }

        // Number to String
        public static object[] NumToString(int[] numbers)
        {
            // Write a function that takes an integer array and returns an object array 
            // that replaces any negative number with the string 'Dojo'.
            // For example, if array "numbers" is initially [-1, -3, 2] 
            // your function should return an array with values ['Dojo', 'Dojo', 2].
            System.Console.WriteLine("NumToString");
            System.Console.WriteLine("======================================================");
            object[] newArr = new object[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 0)
                {
                    newArr[i] = numbers[i];
                }
                else
                {
                    newArr[i] = "Dojo";
                }
                System.Console.WriteLine(newArr[i]);
            }
            return newArr;
        }

        static void Main(string[] args)
        {
            PrintNumbers();
            PrintOdds();
            PrintSum();
            int[] numbers = { 1, 3, -5, 7, -9, 11 };
            LoopArray(numbers);
            FindMax(numbers);
            GetAverage(numbers);
            OddArray();
            GreaterThanY(numbers, 2);
            SquareArrayValues(numbers);
            EliminateNegatives(numbers);
            MinMaxAverage(numbers);
            ShiftValues(numbers);
            NumToString(numbers);
        }
    }
}
