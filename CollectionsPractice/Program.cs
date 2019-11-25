using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {


            // Three Basic Arrays
            // Create an array to hold integer values 0 through 9
            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            // Create an array of length 10 that alternates between true and false values, starting with true
            int[] numArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] nameArray = { "Tim", "Martin", "Nikki", "Sara" };
            bool[] boolArray = { true, false, true, false, true, false, true, false, true, false };

            // List of Flavors
            // Create a list of ice cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
            // Output the length of this list after building it
            // Output the third flavor in the list, then remove this value
            // Output the new length of the list (It should just be one fewer!)
            List<string> flavors = new List<string>();
            flavors.Add("vanilla");
            flavors.Add("rocky road");
            flavors.Add("strawberry");
            flavors.Add("mint");
            flavors.Add("matcha");
            flavors.Add("cherry");
            Console.WriteLine($"There are {flavors.Count} flavors.");
            Console.WriteLine(flavors[3]);
            flavors.Remove(flavors[3]);
            Console.WriteLine($"There are {flavors.Count} flavors.");

            // User Info Dictionary
            // Create a dictionary that will store both string keys as well as string values
            // Add key/value pairs to this dictionary where:
            // each key is a name from your names array
            // each value is a randomly select a flavor from your flavors list.
            // Loop through the dictionary and print out each user's name and their associated ice cream flavor
            Dictionary<string, string> profile = new Dictionary<string, string>();
            profile.Add("Name", "Flavor");
            for (int i = 0; i < 4; i++)
            {
                profile.Add(nameArray[i], flavors[i]);
            }
            foreach (KeyValuePair<string, string> entry in profile)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
