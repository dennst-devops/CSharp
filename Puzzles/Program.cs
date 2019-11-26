using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {


        // Create a function called RandomArray() that returns an integer array
        // Place 10 random integer values between 5-25 into the array
        // Print the min and max values of the array
        // Print the sum of all the values
        public static int[] RandomArray()
        {
            int[] arr = new int[10];
            Random rand = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(6, 26);
            }
            int min = arr[0];
            int max = 0;
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                System.Console.WriteLine(arr[i]);
            }

            System.Console.WriteLine("+++++++++++++");
            System.Console.WriteLine(min);
            System.Console.WriteLine(max);
            System.Console.WriteLine(sum);
            return arr;
        }

        // Coin Flip
        // Create a function called TossCoin() that returns a string
        // Have the function print "Tossing a Coin!"
        // Randomize a coin toss with a result signaling either side of the coin 
        // Have the function print either "Heads" or "Tails"
        // Finally, return the result
        public static int TossCoin()
        {
            int flip = -1;
            string result = "";
            Random rand = new Random();

            System.Console.WriteLine("Tossing a Coin!");
            flip = rand.Next(0, 2);
            // System.Console.WriteLine(flip);
            if (flip == 1)
            {
                result = "Heads";
            }
            else
            {
                result = "Tails";
            }
            System.Console.WriteLine(result);
            System.Console.WriteLine("\n");
            if (result == "Heads")
            {
                return 1;
            }
            else
            {
                return 0;
            }

            // return result;
        }

        // Create another function called TossMultipleCoins(int num) that returns a Double
        // Have the function call the tossCoin function multiple times based on num value
        // Have the function return a Double that reflects the ratio of head toss to total toss
        public static double TossMultipleCoins(int num)
        {
            double ratio = 0;
            int headsCount = 0;
            for (int i = 0; i < num; i++)
            {
                headsCount += TossCoin();
            }
            ratio = (double)headsCount / num;
            System.Console.WriteLine(headsCount);
            System.Console.WriteLine(num);
            System.Console.WriteLine(ratio);
            System.Console.WriteLine("\n");
            return ratio;
        }

        // Names
        // Build a function Names that returns a list of strings.  In this function:
        // Create a list with the values: Todd, Tiffany, Charlie, Geneva, Sydney
        // Shuffle the list and print the values in the new order
        // Return a list that only includes names longer than 5 characters
        public static List<string> Names()
        {
            List<string> longNames = new List<string>();
            List<string> myNames = new List<string>();
            myNames.Add("Todd");
            myNames.Add("Tiffany");
            myNames.Add("Charlie");
            myNames.Add("Geneva");
            myNames.Add("Sydney");

            for (int i = 0; i < myNames.Count; i++)
            {
                System.Console.WriteLine(myNames[i]);
            }
            Random rng = new Random();
            int n = myNames.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = myNames[k];
                myNames[k] = myNames[n];
                myNames[n] = value;
            }
            System.Console.WriteLine("\n+++++++++++++\n");
            for (int i = 0; i < myNames.Count; i++)
            {
                System.Console.WriteLine(myNames[i]);
            }
            System.Console.WriteLine("\n-------------\n");
            for (int i = 0; i < myNames.Count; i++)
            {
                if (myNames[i].Length > 5)
                {
                    longNames.Add(myNames[i]);
                }
            }
            for (int i = 0; i < longNames.Count; i++)
            {
                System.Console.WriteLine(longNames[i]);
            }
            return myNames;
        }

        static void Main(string[] args)
        {
            RandomArray();
            TossCoin();
            TossMultipleCoins(9);
            Names();
        }
    }
}
