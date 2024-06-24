namespace BLL.DataObjectTransforms;

public class Booking
{
    
}
public class BookingRequest
{
    public int RoomId { get; set; }
    public bool BookingStatus = true;
    public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly EndDate { get; set; }
    public double RoomPricePerDay { get; set; }
}