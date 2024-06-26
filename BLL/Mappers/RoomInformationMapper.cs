using BLL.DataObjectTransforms;
using DAL.Builders;
using DAL.Entities;

namespace BLL.Mappers;

public class RoomInformationMapper
{
    public List<RoomInformationResponse> Entity2RoomsResponse(List<RoomInformation> rooms)
    {
        return rooms.Select(room => new BaseBuilder<RoomInformationResponse>()
            .With(roominfo => roominfo.RoomId, room.RoomId)
            .With(roominfo => roominfo.RoomPricePerDay, room.RoomPricePerDay)
            .With(roominfo => roominfo.RoomNumber, room.RoomNumber)
            .With(roominfo => roominfo.RoomMaxCapacity, room.RoomMaxCapacity ?? 0)
            .With(roominfo => roominfo.RoomTypeName, room.RoomType.RoomTypeName ?? "Unknown")
            .With(roominfo => roominfo.RoomStatus, room.RoomStatus)
            .With(roominfo => roominfo.RoomDetailDescription, room.RoomDetailDescription)
            .With(roominfo => roominfo.RoomTypeId, room.RoomTypeId)
            .With(roominfo => roominfo.RoomType, room.RoomType)
            .With(roominfo => roominfo.BookingDetails, room.BookingDetails ?? null)
            .Build()
        ).ToList();
    }

    public IEnumerable<RoomsPageResponse> Entity2RoomsPage(List<RoomInformation> rooms)
    {
        return rooms.Select(room => new BaseBuilder<RoomsPageResponse>()
            .With(roompage => roompage.RoomId, room.RoomId)
            .With(roompage => roompage.RoomNumber, room.RoomNumber)
            .With(roompage => roompage.RoomStatus, room.RoomStatus)
            .With(roompage => roompage.RoomPricePerDay, room.RoomPricePerDay)
            .With(roompage => roompage.RoomTypeName, room.RoomType.RoomTypeName ?? "Unknown")
            .Build()
        ).ToList();
    }
}