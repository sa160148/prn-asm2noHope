using System.Linq.Expressions;
using System.Text.Json;
using DAL.Models;
using Microsoft.Extensions.Caching.Distributed;

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

public class CacheBookingRepository(IBookingRepository bookingRepo, IDistributedCache cahe) : IBookingRepository
{
    public IQueryable<Booking> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<List<Booking>> AllAsync()
    {
        throw new NotImplementedException();
    }

    public Booking? Get<TKey>(TKey id)
    {
        var cacheBooking = cahe.GetString(id!.ToString()!);
        if (cacheBooking is not null)
        {
            return JsonSerializer.Deserialize<Booking>(cacheBooking);
        }
        
        var booking = bookingRepo.Get(id);
        cahe.SetString(id.ToString()!, JsonSerializer.Serialize(booking));
        
    }

    public IQueryable<Booking> Get()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Booking> Get(Expression<Func<Booking, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<Booking?> GetIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Add(Booking e)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Booking e)
    {
        throw new NotImplementedException();
    }

    public void Update(Booking e)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public List<Booking> Find(Expression<Func<Booking, bool>> predic)
    {
        throw new NotImplementedException();
    }

    public Task<List<Booking>> FindAsync(Expression<Func<Booking, bool>> predic)
    {
        throw new NotImplementedException();
    }

    public Task<Booking> FirstOrDefaultAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Booking> FirstOrDefaultAsync(Expression<Func<Booking, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public TKey? Max<TKey>(Expression<Func<Booking, TKey>> id)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Booking>> GetPage(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public int MaxId()
    {
        throw new NotImplementedException();
    }

    public double TotalPrice(int roomId, int days)
    {
        throw new NotImplementedException();
    }
}