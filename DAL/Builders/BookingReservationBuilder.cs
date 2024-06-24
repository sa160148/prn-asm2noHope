using DAL.Entities;

namespace DAL.Builders;

public class BookingReservationBuilder
{
    private BookingReservation _bookingReservation;

    public BookingReservationBuilder()
    {
        _bookingReservation = new BookingReservation();
    }
    public BookingReservationBuilder WithBookingReservationId(int bookingReservationId)
    {
        _bookingReservation.BookingReservationId = bookingReservationId;
        return this;
    }
    public BookingReservationBuilder WithBookingDate(DateOnly bookingDate)
    {
        _bookingReservation.BookingDate = bookingDate;
        return this;
    }
    public BookingReservationBuilder WithTotalPrice(double totalPrice)
    {
        _bookingReservation.TotalPrice = totalPrice;
        return this;
    }
    public BookingReservationBuilder WithCustomerId(int customerId)
    {
        _bookingReservation.CustomerId = customerId;
        return this;
    }
    public BookingReservationBuilder WithBookingStatus(bool bookingStatus)
    {
        _bookingReservation.BookingStatus = bookingStatus;
        return this;
    }
    public BookingReservationBuilder WithBookingDetails(List<BookingDetail> bookingDetails)
    {
        _bookingReservation.BookingDetails = bookingDetails;
        return this;
    }
    public BookingReservationBuilder WithCustomer(Customer customer)
    {
        _bookingReservation.Customer = customer;
        return this;
    }
    public BookingReservation Build()
    {
        return _bookingReservation;
    }
}