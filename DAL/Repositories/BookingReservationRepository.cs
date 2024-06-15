using DAL.Entities;

namespace DAL.Repositories;

public interface IBookingReservationRepository : IBaseRepository<BookingReservation>
{
    
}
public class BookingReservationRepository(FuminiHotelManagementContext context) : BaseRepository<BookingReservation>, IBookingReservationRepository
{
    
}