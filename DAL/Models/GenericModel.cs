using DAL.Builders;

namespace DAL.Models;

public abstract class GenericModel
{
    public int Id { get; set; }
}

public class ModelFactory
{
    public GenericModel CreateModel(string modelType)
    {
        if (modelType.Equals("Customer", StringComparison.InvariantCultureIgnoreCase))
        {
            return new CustomerFactory().CreateCustomer();
        }
        else if(modelType.Equals("Booking", StringComparison.InvariantCultureIgnoreCase))
        {
            return new BookingFactory().CreateBooking();
        }
        /*else if(modelType.Equals("BookingDetail", StringComparison.InvariantCultureIgnoreCase))
        {
            return BookingDetailFactory().CreateBookingDetail();
        }*/
        else
        {
            throw new ArgumentException("Invalid model type");
        }
    }
}

public class CustomerFactory
{
    public Customer CreateCustomer() => new ();
}
public class BookingFactory
{
    public Booking CreateBooking(Booking booking)
    {
        return new BaseBuilder<Booking>()
            .With(br => br.BookingDate, booking.BookingDate)
            .With(br => br.Status, booking.Status)
            .With(br => br.Id, booking.Id)
            .With(br => br.CustomerId, booking.CustomerId)
            .With(br => br.TotalPrice, booking.TotalPrice)
            .With(br => br.BookingDetails, booking.BookingDetails)
            .With(br => br.Customer, booking.Customer)
            .Build();
    }
    public Booking CreateBooking() => new();
}
public class BookingDetailFactory
{
    public BookingDetail CreateBookingDetail(BookingDetail bookingDetail)
    {
        return new BaseBuilder<BookingDetail>()
            .With(bd => bd.ActualPrice, bookingDetail.ActualPrice)
            .With(bd => bd.Booking, bookingDetail.Booking)
            .With(bd => bd.BookingId, bookingDetail.BookingId)
            .With(bd => bd.EndDate, bookingDetail.EndDate)
            .With(bd => bd.Room, bookingDetail.Room)
            .With(bd => bd.RoomId, bookingDetail.RoomId)
            .With(bd => bd.StartDate, bookingDetail.StartDate)
            .Build();
    }
    public BookingDetail CreateBookingDetail() => new();
}