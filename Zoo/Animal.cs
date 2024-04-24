using System;

namespace Zoo;


// Define an abstract class Animal
public abstract class Animal
{
    // Define a constant for the standard mood value
    public const int StandardMood = 50;

    public virtual string Kind => GetType().Name;
    
    
    // Define properties for the animal's name, age, hunger status, activity status, mood, mood description, visitor fitness, race, origin, health, and energy
    public string Name { get; init; }
    public int Age { get; init; }
    public bool IsHungry { get; private set; }
    public bool IsActive { get; private set; }
    public int Mood { get; private set; }
    
    public bool IsFitForVisitor => Mood >= StandardMood;
    public int Health { get; private set; } = 100;
    public int Energy { get; private set; } = 100;

    public string Size { get; private set; } // New Size property

    // Define abstract properties for the animal's sound, favorite food, and best activity
    public abstract string Sound { get; }

    public abstract void MakeSound();
    public DietType  Diet { get; init; }
    public abstract string BestActivity { get; }
    public  enum DietType
    {
        Vegan,
        Fish,
        Meat,
        Veggie
    }
    // Define a method to feed the animal
    public void Feed(DietType food, int amountToFeed)
    {
        // If the food is the animal's favorite, increase its mood and health
        
            if (food == Diet)
            {
                Mood += 2;
                Health += 10;
            }
            // If the food is wrong for the animal, print a message indicating so
            else
            {
                Mood += 1;
                Health += 5;
            }
        
       
     
    }

    // Define a method for the animal to do its favorite activity
    public void DoActivity()
    {
        // Print a message indicating the animal is doing its favorite activity
        Console.WriteLine($"{Name} is now {BestActivity}.");
        // Increase the animal's mood, set it to hungry and active, and decrease its energy
        Mood += 1;
        IsHungry = true;
        IsActive = true;
        Energy -= 10;

        // Ensure the mood does not exceed 10
        Mood = Math.Min(Mood, 10);
    }

    // Define a method for the animal to sleep
    public void Sleep()
    {
        // Print a message indicating the animal is sleeping
        Console.WriteLine($"{Name} is now sleeping.");
        // Set the animal to inactive, increase its mood and energy
        IsActive = false;
        Mood += 1;
        Energy += 20;

        // Ensure the mood does not exceed 10
        Mood = Math.Min(Mood, 10);
    }
}
