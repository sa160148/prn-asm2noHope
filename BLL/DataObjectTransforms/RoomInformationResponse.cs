using DAL.Entities;

namespace BLL.DataObjectTransforms;

public class RoomInformationResponse : RoomInformation
{
    public ICollection<BookingDetail>? BookingDetails { get; set; } = null;
    public RoomType? RoomType { get; set; } = null;
    public string RoomTypeName => RoomType?.RoomTypeName ?? "Unknown";
}

public class RoomsPageResponse
{
    public int RoomId { get; set; }
    public string RoomNumber { get; set; }
    public bool? RoomStatus { get; set; }
    public double? RoomPricePerDay { get; set; }
    public string RoomTypeName { get; set; }
}