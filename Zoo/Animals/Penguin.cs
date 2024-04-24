using System;

namespace Zoo.Animals
{
    internal class Penguin : Animal
    {
        public Penguin(string name, int age)
        {
            Name = name;
            Age = age;
            Diet = DietType.Fish;
        }

        public override string Sound => "Squawk";

        public override string BestActivity => "Swimming";

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound}!");
        }
    }
}

