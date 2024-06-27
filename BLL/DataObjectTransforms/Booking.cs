using DAL.Models;

namespace BLL.DataObjectTransforms;

public class Booking
{
    
}
public class BookingRequest : GenericModel
{
    public bool BookingStatus = true;
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; }
    public double RoomPricePerDay { get; set; }
}