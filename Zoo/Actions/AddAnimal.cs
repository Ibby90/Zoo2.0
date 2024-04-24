using System;
using System.Collections.Generic;
using Zoo.Animals;
using Zoo.Users;

namespace Zoo.Actions;

public class AddAnimal : IAction
{
    private static List<(string type, string displayName, Func<Animal> reader)> AnimalTypes = new ()
    {
        ("lion", "Lion", ReadLion),
        ("Giraffe", "Giraffe", ReadGiraffe),
        ("Penguin", "Penguin", ReadPenguin),
    };

    public bool IsVisible(ZooContext context) => context.LoggedUser is ZooKeeper;
    
    public string Name => "Add animal";
    
    public void Run(ZooContext context)
    {
        var reader = GetAnimalReader();
        var animal = reader();
        context.Animals.Add(animal);
    }

    private Func<Animal> GetAnimalReader()
    {
        while (true)
        {
            Console.Clear();
            ShowListOfAnimals();

            var option = Helpers.ReadInteger("Your choice: ");
            if (option < 1 || option > AnimalTypes.Count)
            {
                Helpers.WaitForAKey("Not a valid choice. Press any key to continue...");
                continue;
            }

            return AnimalTypes[option - 1].reader;
        }
    }

    private void ShowListOfAnimals()
    {
        for (var i = 0; i < AnimalTypes.Count; i++)
            Console.WriteLine($"{i+1}: {AnimalTypes[i].displayName}");

        Console.WriteLine();
    }


    private static Animal ReadLion()
    {
        var name = Helpers.ReadString("Name: ");
        var age = Helpers.ReadInteger("Age: ");
        return new Lion(name, age);
    }

    private static Animal ReadGiraffe()
    {
        var name = Helpers.ReadString("Name: ");
        var age = Helpers.ReadInteger("Age: ");
        return new Giraffe(name, age);
    }

    private static Animal ReadPenguin()
    {
        var name = Helpers.ReadString("Name: ");
        var age = Helpers.ReadInteger("Age: ");
        return new Penguin(name, age);
    }
}