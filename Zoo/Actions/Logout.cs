namespace Zoo.Actions;

public class Logout : IAction
{
    public string Name => "Logout";
    
    public void Run(ZooContext context)
    {
        context.LoggedUser = null;
    }
}