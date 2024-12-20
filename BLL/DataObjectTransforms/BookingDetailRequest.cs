using System.ComponentModel.DataAnnotations;

namespace BLL.DataObjectTransforms;

public class BookingDetailRequest
{
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; }
    public RoomRequest? Room { get; set; }
}

public class Detail4BookingCreatingRequest : Detail4BookingCreatingResponse
{
    [Required(ErrorMessage = "end date is required")]
    public DateTime EndDate { get; set; }
}