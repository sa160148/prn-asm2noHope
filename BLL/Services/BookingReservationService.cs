using BLL.DataObjectTransforms;
using DAL.Builders;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;
public interface IBookingReservationService
{
    public List<BookingReservation> All();
    public bool BookRoom(BookingRequest bookingReservation, int userId, int roomInfoId);
}
public class BookingReservationService(IUnitOfWork uow) : IBookingReservationService
{
    public List<BookingReservation> All()
    {
        return uow.BookingReservations.All();
    }

    public bool BookRoom(BookingRequest bookingReservation, int userId, int roomInfoId)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        if (uow.RoomInformations.GetId(roomInfoId) is not null)
        {
            var bookingReservationBuilder =
                new BaseBuilder<BookingReservation>()
                    .With(br => br.BookingDate, DateOnly.FromDateTime(DateTime.Now))
                    .With(br => br.CustomerId, userId)
                    .With(br => br.BookingStatus, true)
                    .With(br => br.BookingDetails, null)
                    .With(br => br.Customer, uow.Customers.GetId(userId))
                    .Build();
        }
        return false;
    }
}