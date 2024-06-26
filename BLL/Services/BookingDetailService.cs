using DAL.Models;
using DAL.Repositories;

namespace BLL.Services;

public interface IBookingDetailService
{
    public List<BookingDetail> All();
    
}
public class BookingDetailService(IUnitOfWork uow) : IBookingDetailService
{
    public List<BookingDetail> All()
    {
        return uow.BookingDetails.All();
    }

}