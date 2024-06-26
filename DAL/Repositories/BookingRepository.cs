using DAL.Models;

namespace DAL.Repositories;

public interface IBookingRepository : IBaseRepository<Booking>
{
    public int MaxId();
    public double TotalPrice(int roomId, int days);
}
public class BookingRepository(FuminiHotelA2Context context, IUnitOfWork? uow = null) : BaseRepository<Booking>(context), IBookingRepository
{
    public int MaxId()
    {
        return context.Bookings.Max(x => x.Id);
    }

    public double TotalPrice(int roomId, int days)
    {
        double pricePerDay = uow.Rooms
            .Find(info => info.Id == roomId)
            .FirstOrDefault().PricePerDay ?? 0.0;
        return pricePerDay * days;
    }
}