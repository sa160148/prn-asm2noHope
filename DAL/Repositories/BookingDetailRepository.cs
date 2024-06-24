using DAL.Entities;

namespace DAL.Repositories;
public interface IBookingDetailRepository : IBaseRepository<BookingDetail>
{
    
}
public class BookingDetailRepository(FuminiHotelManagementContext context) 
    : BaseRepository<BookingDetail>(context: context), IBookingDetailRepository
{
    
}