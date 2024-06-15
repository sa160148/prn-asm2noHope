using DAL.Entities;

namespace DAL.Repositories;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    
}
public class CustomerRepository(FuminiHotelManagementContext context) : BaseRepository<Customer>, ICustomerRepository
{
}