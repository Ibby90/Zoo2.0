using System.Collections.Generic;

namespace Zoo;

public class ZooContext
{
    public int Price { get; set; }

    public Hours OpeningHours { get; set; }
    public List<Animal> Animals { get; set; } = new();
    public List<User> Users { get; set; } = new();
    public List<Visitor> Visitors { get; set; } = new();
    
    public User? LoggedUser { get; set; } = null;

    public bool HaltRequested { get; private set; } = false;
    public void RequestHalt() => HaltRequested = true;
    
    public Stack<Menu> MenuStack { get; } = new ();
}