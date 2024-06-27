using DAL.Models;

namespace DAL.Builders;

public class BookingDetailBuilder
{
    private BookingDetail _bookingDetail;

    public BookingDetailBuilder()
    {
        _bookingDetail = new BookingDetail();
    }
    public BookingDetailBuilder WithBookingReservervationId(int bookingId)
    {
        _bookingDetail.BookingId = bookingId;
        return this;
    }
    public BookingDetailBuilder WithRoomId(int roomId)
    {
        _bookingDetail.RoomId = roomId;
        return this;
    }
    public BookingDetailBuilder WithStartDate(DateTime startDate)
    {
        _bookingDetail.StartDate = startDate;
        return this;
    }
    public BookingDetailBuilder WithEndDate(DateTime endDate)
    {
        _bookingDetail.EndDate = endDate;
        return this;
    }
    public BookingDetailBuilder WithActualPrice(double actualPrice)
    {
        _bookingDetail.ActualPrice = actualPrice;
        return this;
    }
    public BookingDetailBuilder WithBookingReservation(Booking bookingReservation)
    {
        _bookingDetail.Booking = bookingReservation;
        return this;
    }
    public BookingDetailBuilder WithRoom(Room room)
    {
        _bookingDetail.Room = room;
        return this;
    }
    public BookingDetail Build()
    {
        return _bookingDetail;
    }
}