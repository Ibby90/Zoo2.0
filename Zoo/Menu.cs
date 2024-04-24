using System;
using System.Linq;

namespace Zoo;

public class Menu : IAction
{
    private int _selectedOptionIndex;
    private static readonly string CursorStrOn = ">";
    private static readonly string CursorStrOff = new string(' ', CursorStrOn.Length);
    
    public string Name { get; }
    public IAction[] Options { get; }

    public Menu(string name, params IAction[] options)
    {
        Name = name;
        Options = options;
    }

    public void Run(ZooContext context)
    {
        context.MenuStack.Push(this);
        Console.Clear();
        
        while (!context.HaltRequested && context.MenuStack.Peek() == this)
        {
            Console.Clear();
            Console.CursorVisible = false;

            var visibleOptions = Options.Where(o => o.IsVisible(context)).ToArray();

            if (_selectedOptionIndex >= visibleOptions.Length)
                _selectedOptionIndex = 0;

            DisplayMenu(visibleOptions);
            
            var keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.CursorVisible = true;
                visibleOptions[_selectedOptionIndex].Run(context);
                continue;
            }

            if (keyPressed.Key == ConsoleKey.DownArrow)
            {
                MoveCursor(1, visibleOptions);
                continue;
            }

            if (keyPressed.Key == ConsoleKey.UpArrow)
            {
                MoveCursor(-1, visibleOptions);
                continue;
            }
        }
    }

    private void DisplayMenu(IAction[] options)
    {
        for (int i = 0; i < options.Length; i++)
        {
            var isChosen = i == _selectedOptionIndex;
            var arrow = isChosen ? CursorStrOn : CursorStrOff;
            Console.WriteLine("{1}{0}", options[i].Name, arrow);
        }
    }
    
    private void MoveCursor(int offset, IAction[] options)
    {
        var newPosition = (_selectedOptionIndex + offset + options.Length) % options.Length;

        Console.SetCursorPosition(0, _selectedOptionIndex);
        Console.Write(CursorStrOff);
        Console.SetCursorPosition(0, newPosition);
        Console.Write(CursorStrOn);

        _selectedOptionIndex = newPosition;
    }
}