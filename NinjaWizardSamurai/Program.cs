using System;

namespace human
{
    class Program
    {

        //  Wizard should have a default health of 50 and Intelligence of 25
        //  Ninja should have a default dexterity of 175
        //  Samurai should have a default health of 200
        //  Provide an override Attack method to Wizard, which reduces the target by 5 * Intelligence and heals the Wizard by the amount of damage dealt
        //  Provide an override Attack method to Ninja, which reduces the target by 5 * Dexterity and a 20% chance of dealing an additional 10 points of damage.
        //  Provide an override Attack method to Samurai, which calls the base Attack and reduces the target to 0 if it has less than 50 remaining health points.
        //  Wizard should have a method called Heal, which when invoked, heals a target Human by 10 * Intelligence
        //  Samurai should have a method called Meditate, which when invoked, heals the Samurai back to full health
        //  Ninja should have a method called Steal, reduces a target Human's health by 5 and adds this amount to its own health.
        class Human
        {
            public string Name;
            public int Strength;
            public int Intelligence;
            public int Dexterity;
            protected int hp;

            public int Health
            {
                get { return hp; }
                set { hp = value; }
            }


            public Human(string name)
            {
                Name = name;
                Strength = 3;
                Intelligence = 3;
                Dexterity = 3;
                hp = 100;
            }

            public Human(string name, int str, int intel, int dex, int hitpoints)
            {
                Name = name;
                Strength = str;
                Intelligence = intel;
                Dexterity = dex;
                hp = hitpoints;
            }

            // Build Attack method
            public virtual int Attack(Human target)
            {
                int dmg = Strength * 3;
                target.hp -= dmg;
                Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
                return target.hp;
            }
        }
        class Wizard : Human
        {
            public Wizard(string name) : base(name)
            {
                Name = name;
                hp = 50;
                Intelligence = 25;
            }
            public override int Attack(Human target)
            {
                int dmg = Intelligence * 5;
                target.Health -= dmg;
                hp += dmg;
                Console.WriteLine($"Wizard {Name} attacked {target.Name} for {dmg} Intelligence damage and Wizard {Name} gained {dmg} hp!");
                System.Console.WriteLine($"Wizard {Name} has {hp} health, {target.Name} has {target.Health} hp.");
                return target.Health;
            }
            public void Heal(Human target)
            {
                target.Health += (Intelligence * 10);
            }
        }
        class Ninja : Human
        {
            public Ninja(string name) : base(name)
            {
                Name = name;
                Dexterity = 175;
            }
            public override int Attack(Human target)
            {
                int i = 0;
                Random rand = new Random();
                i = rand.Next(0, 11);
                int dmg = Dexterity * 5;
                if (i > 8)
                {
                    dmg += 10;
                }
                target.Health -= dmg;
                Console.WriteLine($"Ninja {Name} attacked {target.Name} for {dmg} Dexterity damage!");
                if (i > 8)
                {
                    Console.WriteLine("10 additional damage points were deducted!");
                }
                System.Console.WriteLine($"Wizard {Name} has {hp} health, {target.Name} has {target.Health} hp.");
                return target.Health;
            }
            public void Steal(Human target)
            {
                target.Health -= 5;
                hp += 5;
                System.Console.WriteLine($"Samurai {Name} has stolen 5 hp from {target.Name}, which has {target.Health} hp, and {Name} has {Health} hp.");
            }
        }
        class Samurai : Human
        {
            public Samurai(string name) : base(name)
            {
                Name = name;
                hp = 200;
            }
            public override int Attack(Human target)
            {
                bool critHit = false;
                base.Attack(target);
                if (target.Health <= 50)
                {
                    target.Health = 0;
                    critHit = true;
                }
                Console.WriteLine($"Samurai {Name} attacked {target.Name}!");
                if (critHit)
                {
                    Console.WriteLine($"{target.Name} had less than 50 hp and is now 0hp!");
                }

                System.Console.WriteLine($"Samurai {Name} has {hp} health, {target.Name} has {target.Health} hp.");
                return target.Health;
            }
            public void Meditate()
            {
                hp = 200;
                System.Console.WriteLine("Meditating...");
            }
        }

        static void Main(string[] args)
        {
            // Human myhuman1 = new Human("The Name");
            // Human myhuman2 = new Human("Human2 Name", 50, 25, 75, 95);
            // myhuman1.Attack(myhuman2);
            // myhuman1.Attack(myhuman2);
            // myhuman1.Attack(myhuman2);
            // myhuman1.Attack(myhuman2);
            Samurai myhuman1 = new Samurai("P1");
            Samurai myhuman2 = new Samurai("p2");
            Wizard mywiz2 = new Wizard("w2");
            Ninja mysamurai2 = new Ninja("s2");
            myhuman1.Attack(myhuman2);
            myhuman1.Attack(myhuman2);
            myhuman1.Attack(myhuman2); myhuman1.Attack(myhuman2); myhuman1.Attack(myhuman2); myhuman1.Attack(myhuman2);
            myhuman1.Attack(myhuman2); myhuman1.Attack(myhuman2); myhuman1.Attack(myhuman2); myhuman1.Attack(myhuman2);
            myhuman1.Attack(myhuman2); myhuman1.Attack(myhuman2); myhuman1.Attack(myhuman2); myhuman1.Attack(myhuman2);
            myhuman1.Attack(myhuman2); myhuman1.Attack(myhuman2); myhuman1.Attack(myhuman2); myhuman1.Attack(myhuman2);
            myhuman2.Meditate();
            myhuman1.Attack(myhuman2);
            mysamurai2.Steal(myhuman1);
            mysamurai2.Steal(myhuman1);
            mysamurai2.Steal(myhuman1);
            mysamurai2.Steal(myhuman1);
            mysamurai2.Steal(myhuman1);
            mysamurai2.Steal(myhuman1);
            mysamurai2.Steal(myhuman1);
            mysamurai2.Steal(myhuman1);
            mysamurai2.Steal(myhuman1);
            mysamurai2.Steal(myhuman1);
            myhuman1.Attack(myhuman2);
            System.Console.WriteLine("done");

        }
    }
}
