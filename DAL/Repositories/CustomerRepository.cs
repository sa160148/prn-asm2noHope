using DAL.Models;
using Customer = DAL.Models.Customer;

namespace DAL.Repositories;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    
}
public class CustomerRepository(FuminiHotelA2Context context) : BaseRepository<Customer>(context), ICustomerRepository
{
}