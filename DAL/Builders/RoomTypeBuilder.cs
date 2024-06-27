using DAL.Models;

namespace DAL.Builders;

public class RoomTypeBuilder
{
    private RoomType _roomType;

    public RoomTypeBuilder()
    {
        _roomType = new RoomType();
    }
    public RoomTypeBuilder WithRoomTypeId(int roomTypeId)
    {
        _roomType.Id = roomTypeId;
        return this;
    }
    public RoomTypeBuilder WithRoomTypeName(string typeName)
    {
        _roomType.TypeName = typeName;
        return this;
    }
    public RoomTypeBuilder WithTypeDescription(string description)
    {
        _roomType.Description = description;
        return this;
    }
    public RoomTypeBuilder WithTypeNote(string note)
    {
        _roomType.Note = note;
        return this;
    }
    public RoomTypeBuilder WithRoomInformations(List<Room> rooms)
    {
        _roomType.Rooms = rooms;
        return this;
    }
    public RoomType Build()
    {
        return _roomType;
    }
}