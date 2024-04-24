using System;

namespace Zoo;

// Enum f�r att definiera olika typer av bes�kare
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
    // Namnet p� bes�karen
    public string Name { get; set; }
    public int Amount { get; set; }
    // �ldern p� bes�karen
    public int Age { get; set; }


    // Typen av bes�karen (Child, Adult, Senior, Family)
    public VisitorType Type { get; set; }

    // Konstruktor f�r Visitor klassen
    public Visitor(string name,int Amount, int age, VisitorType type)
    {
        Name = name;
        Age = age;    
        Amount = Amount;
        Type = type;
    }
}
