using System;
using System.Linq;
using System.Text;

namespace Zoo.Actions;

public class Login : IAction
{
    public string Name => "Login";

    public bool IsVisible(ZooContext context) => context.LoggedUser is null;

    public void Run(ZooContext context)
    {
        if (context.LoggedUser is not null)
        {
            throw new InvalidOperationException("Already logged in");
        }

        while (true)
        {
            var username = Helpers.ReadString("username: ");
            var password = Helpers.ReadPassword("password: ");

            var user = context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);

            if (user is null)
            {
                Console.WriteLine("Invalid username or password");
                continue;
            }

            context.LoggedUser = user;
            Helpers.WaitForAKey($"Welcome, {user.Name}! Press any key to continue...");
            return;
        }
    }
}