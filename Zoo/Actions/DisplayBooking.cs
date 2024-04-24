using Zoo.Actions;
using Zoo;

public class DisplayBookings : IAction
{
    private readonly Booking _booking;

    public DisplayBookings(Booking booking)
    {
        _booking = booking;
    }

    public string Name => "Display Bookings";

    public bool IsVisible(ZooContext context) => true;

    public void Run(ZooContext context)
    {
        _booking.DisplayAllBookings();
    }
}
