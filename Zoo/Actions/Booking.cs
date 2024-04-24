using System.Collections.Generic;
using System;
using Zoo;

namespace Zoo.Actions
{
    public class Booking : IAction
    {
        // Implement the Name property from the IAction interface
        public string Name => "Booking";

        // Lista för att lagra bokningar
        private List<Visitor> Bookings { get; set; }

        // Konstruktor för Booking klassen
        public Booking()
        {
            Bookings = new List<Visitor>();
            
        }

        // Metod för att lägga till en bokning
        public void AddBooking(Visitor visitor)
        {
            Bookings.Add(visitor);
            Console.WriteLine($"Bokning skapad för besökare: {visitor.Name}");
        }

        // Implement the Run method from the IAction interface
        public void Run(ZooContext context)
        {
            var visitors = ReadVisitor();
            foreach (var visitor in visitors)
            {
                AddBooking(visitor);
            }
        }



        // Metod för att läsa in en besökare
        public static List<Visitor> ReadVisitor()
        {
            var name = Helpers.ReadString("Which Name you want to book in: ");

            var visitors = new List<Visitor>();
            var visitorTypes = Enum.GetValues(typeof(VisitorType));
            for (int j = 0; j < visitorTypes.Length; j++)
            {
                if ((VisitorType)visitorTypes.GetValue(j) == VisitorType.Family)
                {
                    Console.WriteLine("Are you a family? (yes/no): ");
                    var response = Console.ReadLine();
                    if (response?.ToLower() == "yes")
                    {
                        visitors.Add(new Visitor(name, 0, 1, VisitorType.Family)); // Age is set to 0 for family
                    }
                }
                else
                {
                    Console.WriteLine($"How many {visitorTypes.GetValue(j)} is it?: ");
                    var amount = Helpers.ReadInteger();
                    amount = Math.Min(7, amount);

                    for (int i = 0; i < amount; i++)
                    {
                        var age = Helpers.ReadInteger($"What is the age of {visitorTypes.GetValue(j)} number {i + 1}?: ");
                        visitors.Add(new Visitor(name, age, 1, (VisitorType)visitorTypes.GetValue(j)));
                    }
                }
            }

            return visitors;
        }


        public void ConfirmBooking(Visitor visitor)
        {
            Bookings.Add(visitor);
            Console.WriteLine($"Booking added for visitor: {visitor.Name}");
        }

        public void DisplayAllBookings()
        {
            Console.WriteLine("All Bookings:");
            foreach (var booking in Bookings)
            {
                Console.WriteLine($"Name: {booking.Name},  Type: {booking.Type}, Amount: {booking.Amount}");
            }
        }


    }
    public class RemoveBooking : IAction
    {
        // Implement the Name property from the IAction interface
        public string Name => "Remove Booking";

        public void Run(ZooContext context)
        {
            Console.WriteLine("Are you sure you want to remove a booking? (yes/no)");
            var response = Console.ReadLine();

            if (response?.ToLower() == "yes")
            {
                // Code to remove a booking...
                Console.WriteLine("Booking removed.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
    }
 

}