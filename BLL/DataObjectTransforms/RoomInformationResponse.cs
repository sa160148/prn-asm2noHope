using DAL.Models;

namespace BLL.DataObjectTransforms;

public class RoomInformationResponse : Room
{
    public ICollection<BookingDetail>? BookingDetails { get; set; } = null;
    public RoomType? RoomType { get; set; } = null;
    public string RoomTypeName => RoomType?.TypeName ?? "Unknown";
}

public class RoomsPageResponse
{
    public int Id { get; set; }
    public string RoomNumber { get; set; }
    public bool? Status { get; set; }
    public double? PricePerDay { get; set; }
    public string TypeName { get; set; }
}