using BLL.DataObjectTransforms;
using DAL.Builders;
using DAL.Models;

namespace BLL.Mappers;
public interface IRoomMapeer
{
    public List<RoomInformationResponse> Entity2RoomsResponse(List<Room> rooms);
    public IEnumerable<RoomsPageResponse> Entity2RoomsPage(IEnumerable<Room> rooms);
    public Task<IEnumerable<RoomsPageResponse>> Entity2RoomsPageAsync(IEnumerable<Room> rooms);
}
public class RoomMapper : IRoomMapeer
{
    public List<RoomInformationResponse> Entity2RoomsResponse(List<Room> rooms)
    {
        return rooms.Select(room => new BaseBuilder<RoomInformationResponse>()
            .With(roominfo => roominfo.Id, room.Id)
            .With(roominfo => roominfo.PricePerDay, room.PricePerDay)
            .With(roominfo => roominfo.RoomNumber, room.RoomNumber)
            .With(roominfo => roominfo.MaxCapacity, room.MaxCapacity ?? 0)
            .With(roominfo => roominfo.RoomTypeName, room.RoomType.TypeName ?? "Unknown")
            .With(roominfo => roominfo.Status, room.Status)
            .With(roominfo => roominfo.DetailDescription, room.DetailDescription)
            .With(roominfo => roominfo.RoomTypeId, room.RoomTypeId)
            .With(roominfo => roominfo.RoomType, room.RoomType)
            .With(roominfo => roominfo.BookingDetails, room.BookingDetails ?? null)
            .Build()
        ).ToList();
    }

    public IEnumerable<RoomsPageResponse> Entity2RoomsPage(IEnumerable<Room> rooms)
    {
        return rooms.Select(room => new BaseBuilder<RoomsPageResponse>()
            .With(roompage => roompage.Id, room.Id)
            .With(roompage => roompage.RoomNumber, room.RoomNumber)
            .With(roompage => roompage.Status, room.Status)
            .With(roompage => roompage.PricePerDay, room.PricePerDay)
            .With(roompage => roompage.TypeName, room.RoomType?.TypeName ?? "Unknown")
            .Build()
        ).ToList();
    }
    public async Task<IEnumerable<RoomsPageResponse>> Entity2RoomsPageAsync(IEnumerable<Room> rooms)
    {
        return await Task.Run(() => Entity2RoomsPage(rooms));
    }
}