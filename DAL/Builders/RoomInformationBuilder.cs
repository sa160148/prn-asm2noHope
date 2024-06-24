using DAL.Entities;

namespace DAL.Builders;

public class RoomInformationBuilder
{
    private RoomInformation _roomInformation;

    public RoomInformationBuilder()
    {
        _roomInformation = new RoomInformation();
    }
    public RoomInformationBuilder WithRoomId(int roomId)
    {
        _roomInformation.RoomId = roomId;
        return this;
    }
    public RoomInformationBuilder WithRoomNumber(string roomNumber)
    {
        _roomInformation.RoomNumber = roomNumber;
        return this;
    }
    public RoomInformationBuilder WithRoomDetailDescription(string roomDetailDescription)
    {
        _roomInformation.RoomDetailDescription = roomDetailDescription;
        return this;
    }
    public RoomInformationBuilder WithRoomMaxCapacity(int roomMaxCapacity)
    {
        _roomInformation.RoomMaxCapacity = roomMaxCapacity;
        return this;
    }
    public RoomInformationBuilder WithRoomTypeId(int roomTypeId)
    {
        _roomInformation.RoomTypeId = roomTypeId;
        return this;
    }
    public RoomInformationBuilder WithRoomStatus(bool roomStatus)
    {
        _roomInformation.RoomStatus = roomStatus;
        return this;
    }
    public RoomInformationBuilder WithRoomPricePerDay(double roomPricePerDay)
    {
        _roomInformation.RoomPricePerDay = roomPricePerDay;
        return this;
    }
    public RoomInformationBuilder WithBookingDetails(List<BookingDetail> bookingDetails)
    {
        _roomInformation.BookingDetails = bookingDetails;
        return this;
    }
    public RoomInformationBuilder WithRoomType(RoomType roomType)
    {
        _roomInformation.RoomType = roomType;
        return this;
    }
    public RoomInformation Build()
    {
        return _roomInformation;
    }
}