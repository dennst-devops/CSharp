using System;
using System.Collections.Generic;

namespace HungryNinja
{
    class Program
    {
        class Food
        {
            public string Name;
            public int Calories;
            // Foods can be Spicy and/or Sweet
            public bool IsSpicy;
            public bool IsSweet;
            // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
            public Food(string name, int cals, bool spicy, bool sweet)
            {
                Name = name;
                Calories = cals;
                IsSpicy = spicy;
                IsSweet = sweet;
            }
        }


        class Buffet
        {
            public List<Food> Menu;

            //constructor
            public Buffet()
            {
                Menu = new List<Food>()
                {
                    new Food("Snapple", 200, false, true),
                    new Food("Burger", 800, false, false),
                    new Food("Spicy Wasabi", 50, true, false),
                    new Food("Ice cream", 900, false, true),
                    new Food("Chicken Masala", 1200, false, false),
                    new Food("Fries & Shake", 1000, true, true),
                    new Food("Diet Dr Pepper", 10, false, true)
                };
            }
            public Food Serve()
            {
                int i = 0;
                Random rand = new Random();
                i = rand.Next(0, 7);
                return Menu[i];
            }
        }

        class Ninja
        {
            private int calorieIntake;
            public List<Food> FoodHistory;

            // add a constructor
            public Ninja()
            {
                calorieIntake = 0;
                FoodHistory = new List<Food>();
            }
            // add a public "getter" property called "IsFull"
            public bool IsFull
            {
                get
                {
                    if (calorieIntake > 1200)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            // build out the Eat method
            public void Eat(Food item)
            {
                if (calorieIntake < 1200)
                {
                    this.calorieIntake += item.Calories;
                    FoodHistory.Add(item);
                    System.Console.WriteLine(item.Name);
                    if (item.IsSpicy)
                    {
                        System.Console.WriteLine("This item is spicy!!!!!!!!!!!!");
                    }
                    if (item.IsSweet)
                    {
                        System.Console.WriteLine("This item is sweet.");
                    }
                }
                else
                {
                    System.Console.WriteLine("Ninja is full and cannot eat any more.");
                }
                System.Console.WriteLine(this.calorieIntake);
                System.Console.WriteLine("\n");
            }
        }
        static void Main(string[] args)
        {
            Buffet mybuffet = new Buffet();
            Ninja myNinja = new Ninja();
            while (myNinja.IsFull == false)
            {
                myNinja.Eat(mybuffet.Serve());
            }
            System.Console.WriteLine("Done!");
        }
    }
}
