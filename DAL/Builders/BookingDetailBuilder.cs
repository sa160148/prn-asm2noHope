using DAL.Entities;

namespace DAL.Builders;

public class BookingDetailBuilder
{
    private BookingDetail _bookingDetail;

    public BookingDetailBuilder()
    {
        _bookingDetail = new BookingDetail();
    }
    public BookingDetailBuilder WithBookingReservervationId(int bookingReservationId)
    {
        _bookingDetail.BookingReservationId = bookingReservationId;
        return this;
    }
    public BookingDetailBuilder WithRoomId(int roomId)
    {
        _bookingDetail.RoomId = roomId;
        return this;
    }
    public BookingDetailBuilder WithStartDate(DateOnly startDate)
    {
        _bookingDetail.StartDate = startDate;
        return this;
    }
    public BookingDetailBuilder WithEndDate(DateOnly endDate)
    {
        _bookingDetail.EndDate = endDate;
        return this;
    }
    public BookingDetailBuilder WithActualPrice(double actualPrice)
    {
        _bookingDetail.ActualPrice = actualPrice;
        return this;
    }
    public BookingDetailBuilder WithBookingReservation(BookingReservation bookingReservation)
    {
        _bookingDetail.BookingReservation = bookingReservation;
        return this;
    }
    public BookingDetailBuilder WithRoom(RoomInformation room)
    {
        _bookingDetail.Room = room;
        return this;
    }
    public BookingDetail Build()
    {
        return _bookingDetail;
    }
}