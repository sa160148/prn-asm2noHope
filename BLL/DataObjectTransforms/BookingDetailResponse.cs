namespace BLL.DataObjectTransforms;

public class BookingDetailResponse : Detail4BookingCreatingResponse
{
    public int? Id { get; set; }
    public Booking4PageResponse? Booking { get; set; }
    
}
public class Detail4BookingCreatingResponse
{
    public DateTime? StartDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; } = null;
    public Room4BookingCreatingResponse? Room { get; set; }
}