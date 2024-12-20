using DAL.Models;

namespace BLL.DataObjectTransforms;

public class BookingResponse
{
    public int? Id { get; set; }
    public DateTime? BookingDate { get; set; }

    public double? TotalPrice { get; set; }
    public bool? Status { get; set; }
}

public class BookingCreatingResponse
{
    public DateTime? BookingDate { get; set; } = DateTime.Now;
    public double? TotalPrice { get; set; }
    public bool? Status { get; set; }
    public Detail4BookingCreatingResponse? BookingDetail { get; set; }
}

public class Booking4PageResponse
{
    public int? Id { get; set; }
    public DateTime? BookingDate { get; set; }

    public double? TotalPrice { get; set; }
    public bool? Status { get; set; }
    public Customer4PageRequest? Customer { get; set; }
}