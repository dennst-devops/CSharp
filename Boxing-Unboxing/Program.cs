using System;
using System.Collections.Generic;

namespace Boxing_Unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> things = new List<object>();
            things.Add(7);
            things.Add(28);
            things.Add(-1);
            things.Add(true);
            things.Add("chair");

            for (int i = 0; i < things.Count; i++)
            {
                System.Console.WriteLine(things[i]);
            }

            int sum = 0;
            for (int i = 0; i < things.Count; i++)
            {
                if (things[i] is int) {
                    sum += (int) things[i];
                }
            }
            System.Console.WriteLine(sum);
        }
    }
}
