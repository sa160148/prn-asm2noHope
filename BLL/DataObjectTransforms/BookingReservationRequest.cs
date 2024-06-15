using DAL.Entities;

namespace BLL.DataObjectTransforms;

public class BookingReservationRequest
{
    
}

public class BookingRequest : BookingReservation
{
    public int? BookingReservationID { get; set; } = null;
    public int? CustomerId { get; set; } = null;
    public bool BookingStatus = true;
}