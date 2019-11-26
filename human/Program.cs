using System;

namespace human
{
    class Program
    {


        class Human
        {
            // Fields for Human
            //  Create a Human class with four public fields: Name (string) , Strength (int), Intelligence (int), Dexterity (int)
            public string Name;
            public int Strength;
            public int Intelligence;
            public int Dexterity;

            //  Add an additional private field for health (int), and a public property to access or "get" health
            private int health;

            // add a public "getter" property to access health
            public int HealthStatus
            {
                get
                {
                    return this.health;
                }
            }

            // Add a constructor that takes a value to set Name, and set the remaining fields to default values
            //  Add a constructor method that takes a string to initialize Name - and that will initialize 
            //  Strength, Intelligence, and Dexterity to a default value of 3, and health to default value of 100
            public Human(string name)
            {
                Name = name;
                Strength = 3;
                Intelligence = 3;
                Dexterity = 3;
                health = 100;
                // return Human;
            }

            // Add a constructor to assign custom values to all fields
            //  Let's create an additional constructor that accepts 5 parameters, so we can set custom values for every field.
            public Human(string name, int str, int intel, int dex, int theheath)
            {
                Name = name;
                Strength = str;
                Intelligence = intel;
                Dexterity = dex;
                this.health = theheath;
                // return Human;
            }
            // Build Attack method
            /* Now add a new method called Attack, which when invoked, should reduce the health of a Human object that is passed as a parameter. 
            The damage done should be 5 * strength (5 points of damage to the attacked, for each 1 point of strength of the attacker). 
            This method should return the remaining health of the target object. */
            public int Attack(Human target)
            {
                target.health -= this.Strength * 5;
                return this.health;
            }
        }
        static void Main(string[] args)
        {
            Human myhuman1 = new Human("The Name");
            Human myhuman2 = new Human("Human2 Name", 50, 25, 75, 95);
            myhuman1.Attack(myhuman2);
            myhuman1.Attack(myhuman2);
            myhuman1.Attack(myhuman2);
            myhuman1.Attack(myhuman2);
            System.Console.WriteLine("done");

        }
    }
}
