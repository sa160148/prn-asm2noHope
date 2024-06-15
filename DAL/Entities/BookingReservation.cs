
namespace DAL.Entities;

public partial class BookingReservation
{
    public int BookingReservationId { get; set; }

    public DateOnly? BookingDate { get; set; }

    public double? TotalPrice { get; set; }

    public int CustomerId { get; set; }

    public bool? BookingStatus { get; set; }

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual Customer Customer { get; set; } = null!;
}
