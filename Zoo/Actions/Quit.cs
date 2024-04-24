namespace Zoo.Actions;

public class Quit : IAction
{
    public string Name => "Quit";

    public bool IsVisible(ZooContext context) => true;

    public void Run(ZooContext context)
    {
        context.RequestHalt();
    }
}