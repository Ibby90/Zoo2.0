using static Zoo.Animal;
using System.Xml.Linq;
using System;
using Zoo;

public class Lion : Animal
{
    public Lion(string name, int age)
    {
        Name = name;
        Age = age;
        Diet = DietType.Meat;
    }

    public override string Sound => "Roar";

    public override string BestActivity => "Hunting";

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says {Sound}!");
    }
}
