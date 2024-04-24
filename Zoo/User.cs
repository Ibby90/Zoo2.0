namespace Zoo;

public abstract class User
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public override string ToString()
    {
        return Name;
    }
}