using System;

namespace Zoo.Animals
{
    internal class Giraffe : Animal
    {
        public Giraffe(string name, int age)
        {
            Name = name;
            Age = age;
            Diet = DietType.Vegan;
        }

        public override string Sound => "Bleat";

        public override string BestActivity => "Grazing";

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound}!");
        }
    }
}
