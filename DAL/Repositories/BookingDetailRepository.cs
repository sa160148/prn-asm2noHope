using DAL.Models;
using BookingDetail = DAL.Entities.BookingDetail;

namespace DAL.Repositories;
public interface IBookingDetailRepository : IBaseRepository<BookingDetail>
{
    
}
public class BookingDetailRepository(FuminiHotelA2Context context) 
    : BaseRepository<BookingDetail>(context: context), IBookingDetailRepository
{
    
}