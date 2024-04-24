using System;

namespace Zoo.Actions;

public class ShowAnimals : IAction
{
    public string Name => "Show animals";
    
    public void Run(ZooContext context)
    {
        for (var i = 0; i < context.Animals.Count; i++)
        {
            var animal = context.Animals[i];
            Console.WriteLine($"{i+1}: [{animal.Kind}] { animal.Name }");
        }
        
        Helpers.WaitForAKey("Press any key to continue...");
    }
}