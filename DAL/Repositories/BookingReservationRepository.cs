using DAL.Entities;

namespace DAL.Repositories;

public interface IBookingReservationRepository : IBaseRepository<BookingReservation>
{
    public int MaxId();
    public double TotalPrice(int roomId, int days);
}
public class BookingReservationRepository(FuminiHotelManagementContext context, IUnitOfWork? uow = null) : BaseRepository<BookingReservation>(context), IBookingReservationRepository
{
    public int MaxId()
    {
        return context.BookingReservations.Max(x => x.BookingReservationId);
    }

    public double TotalPrice(int roomId, int days)
    {
        double pricePerDay = uow.RoomInformations
            .Find(info => info.RoomId == roomId)
            .FirstOrDefault().RoomPricePerDay ?? 0.0;
        return pricePerDay * days;
    }
}