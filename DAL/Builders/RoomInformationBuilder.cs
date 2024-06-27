using DAL.Models;

namespace DAL.Builders;

public class RoomInformationBuilder
{
    private Room _roomInformation;

    public RoomInformationBuilder()
    {
        _roomInformation = new Room();
    }
    public RoomInformationBuilder WithRoomId(int roomId)
    {
        _roomInformation.Id = roomId;
        return this;
    }
    public RoomInformationBuilder WithRoomNumber(string roomNumber)
    {
        _roomInformation.RoomNumber = roomNumber;
        return this;
    }
    public RoomInformationBuilder WithRoomDetailDescription(string detailDescription)
    {
        _roomInformation.DetailDescription = detailDescription;
        return this;
    }
    public RoomInformationBuilder WithRoomMaxCapacity(int maxCapacity)
    {
        _roomInformation.MaxCapacity = maxCapacity;
        return this;
    }
    public RoomInformationBuilder WithRoomTypeId(int roomTypeId)
    {
        _roomInformation.RoomTypeId = roomTypeId;
        return this;
    }
    public RoomInformationBuilder WithRoomStatus(bool status)
    {
        _roomInformation.Status = status;
        return this;
    }
    public RoomInformationBuilder WithRoomPricePerDay(double pricePerDay)
    {
        _roomInformation.PricePerDay = pricePerDay;
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
    public Room Build()
    {
        return _roomInformation;
    }
}