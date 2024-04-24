namespace Zoo;

public interface IAction
{
    string Name { get; }
    void Run(ZooContext context);
    
    bool IsVisible(ZooContext context) => context.LoggedUser is not null;
}