using System;

namespace Zoo;

// Enum för att definiera olika typer av besökare
public enum VisitorType
{
    Kids,
    Teenagers,
    Adults,
    Seniors,
    Family
}

public class Visitor
{
    // Namnet på besökaren
    public string Name { get; set; }
    public int Amount { get; set; }
    // Åldern på besökaren
    public int Age { get; set; }


    // Typen av besökaren (Child, Adult, Senior, Family)
    public VisitorType Type { get; set; }

    // Konstruktor för Visitor klassen
    public Visitor(string name,int Amount, int age, VisitorType type)
    {
        Name = name;
        Age = age;    
        Amount = Amount;
        Type = type;
    }
}
