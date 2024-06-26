namespace BLL.DataObjectTransforms;

public class Booking
{
    
}
public class BookingRequest
{
    public int RoomId { get; set; }
    public bool BookingStatus = true;
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; }
    public double RoomPricePerDay { get; set; }
}