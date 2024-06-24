using DAL.Entities;

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
        _roomType.RoomTypeId = roomTypeId;
        return this;
    }
    public RoomTypeBuilder WithRoomTypeName(string roomTypeName)
    {
        _roomType.RoomTypeName = roomTypeName;
        return this;
    }
    public RoomTypeBuilder WithTypeDescription(string typeDescription)
    {
        _roomType.TypeDescription = typeDescription;
        return this;
    }
    public RoomTypeBuilder WithTypeNote(string typeNote)
    {
        _roomType.TypeNote = typeNote;
        return this;
    }
    public RoomTypeBuilder WithRoomInformations(List<RoomInformation> roomInformations)
    {
        _roomType.RoomInformations = roomInformations;
        return this;
    }
    public RoomType Build()
    {
        return _roomType;
    }
}