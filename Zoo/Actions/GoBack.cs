using System;

namespace Zoo.Actions;

public class GoBack : IAction
{
    public string Name => "Go back";

    public void Run(ZooContext context)
    {
        if (context.MenuStack.Count == 1)
            throw new Exception("Go back action can't be placed at the main menu");

        context.MenuStack.Pop();
        context.MenuStack.Pop().Run(context);
    }
}