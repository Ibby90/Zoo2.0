using System;
using System.Collections.Generic;
using Zoo.Actions;
using Zoo.Animals;
using Zoo.Users;

namespace Zoo;

class Program
{
    private static Booking _booking;

    public static void Main(string[] args)
    {
        var context = InitContext();
        
        DisplaWelcomeMessage();

        var menu = InitMenu();
        menu.Run(context);

        Console.WriteLine("Hej daa");
    }

    private static void DisplaWelcomeMessage()
    {
        Console.WriteLine("Välkommen!\nTryck Enter för att komma åt menyn!");
        Console.ReadKey();
    }

    private static ZooContext InitContext()
    {
        var context = new ZooContext();
        context.Users = InitUsers();
        context.Animals = InitAnimals();
        return context;
    }

    private static List<User> InitUsers()
    {
        return new List<User>
        {
            new ZooKeeper { Name = "Zoo Keepersson", Username = "keeper", Password = "1234" },
            new ZooOwner() { Name = "Foo Ownersson", Username = "owner", Password = "1234" }
        };
    }

    private static List<Animal> InitAnimals()
    {
        return new List<Animal>
    {
        new Lion("Simba", 5),
        new Lion("Scar", 15),
        new Lion("Muphasa", 15),
        new Penguin("Pingu", 5),
        new Penguin("Rosa", 4),
        new Giraffe("Giraffa", 10),
        new Giraffe("Giraffo", 12),
    };
    }
 

    private static Menu InitMenu()
    {
        var goBack = new GoBack();

        var menu = new Menu(
            "MainMenu",
            new Menu(
                "Animals",
                new ShowAnimals(),
                new AddAnimal(),
                goBack
            ),
            new Menu(
                "Visitors",
               new Booking(),
                new RemoveBooking(),
                new DisplayBookings(_booking),
                goBack
            ),
            new Login(),
            new Logout(),
            new Quit()
        );
        return menu;
    }


}