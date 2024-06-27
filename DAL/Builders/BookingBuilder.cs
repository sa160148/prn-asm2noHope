using DAL.Models;

namespace DAL.Builders;

public class BookingBuilder
{
    private Booking _booking;

    public BookingBuilder()
    {
        _booking = new ();
    }
    public BookingBuilder WithBookingReservationId(int bookingId)
    {
        _booking.Id = bookingId;
        return this;
    }
    public BookingBuilder WithBookingDate(DateTime bookingDate)
    {
        _booking.BookingDate = bookingDate;
        return this;
    }
    public BookingBuilder WithTotalPrice(double totalPrice)
    {
        _booking.TotalPrice = totalPrice;
        return this;
    }
    public BookingBuilder WithCustomerId(int customerId)
    {
        _booking.CustomerId = customerId;
        return this;
    }
    public BookingBuilder WithBookingStatus(bool bookingStatus)
    {
        _booking.Status = bookingStatus;
        return this;
    }
    public BookingBuilder WithBookingDetails(List<BookingDetail> bookingDetails)
    {
        _booking.BookingDetails = bookingDetails;
        return this;
    }
    public BookingBuilder WithCustomer(Customer customer)
    {
        _booking.Customer = customer;
        return this;
    }
    public Booking Build()
    {
        return _booking;
    }
}