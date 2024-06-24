using DAL.Builders;

namespace DAL.Entities;

public abstract class BaseModel
{
    /*public int Id { get; set; }*/
}

public class ModelFactory
{
    public BaseModel CreateModel(string modelType)
    {
        if (modelType.Equals("Customer", StringComparison.InvariantCultureIgnoreCase))
        {
            return new CustomerFactory().CreateCustomer();
        }
        else if(modelType.Equals("BookingReservation ", StringComparison.InvariantCultureIgnoreCase))
        {
            return new BookingReservationFactory().CreateBookingReservation();
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
    public Customer CreateCustomer() => new();
}
public class BookingReservationFactory
{
    public BookingReservation CreateBookingReservation(BookingReservation bookingReservation)
    {
        return new BaseBuilder<BookingReservation>()
            .With(br => br.BookingDate, bookingReservation.BookingDate)
            .With(br => br.BookingStatus, bookingReservation.BookingStatus)
            .With(br => br.BookingReservationId, bookingReservation.BookingReservationId)
            .With(br => br.CustomerId, bookingReservation.CustomerId)
            .With(br => br.TotalPrice, bookingReservation.TotalPrice)
            .With(br => br.BookingDetails, bookingReservation.BookingDetails)
            .With(br => br.Customer, bookingReservation.Customer)
            .Build();
    }
    public BookingReservation CreateBookingReservation() => new();
}
public class BookingDetailFactory
{
    public BookingDetail CreateBookingDetail(BookingDetail bookingDetail)
    {
        return new BaseBuilder<BookingDetail>()
            .With(bd => bd.ActualPrice, bookingDetail.ActualPrice)
            .With(bd => bd.BookingReservation, bookingDetail.BookingReservation)
            .With(bd => bd.BookingReservationId, bookingDetail.BookingReservationId)
            .With(bd => bd.EndDate, bookingDetail.EndDate)
            .With(bd => bd.Room, bookingDetail.Room)
            .With(bd => bd.RoomId, bookingDetail.RoomId)
            .With(bd => bd.StartDate, bookingDetail.StartDate)
            .Build();
    }
    public BookingDetail CreateBookingDetail() => new();
}