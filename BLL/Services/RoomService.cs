using DAL.Models;
using DAL.Repositories;

namespace BLL.Services;
public interface IRoomInformationService
{
    public Task<List<Room>> AllAsync();
    public Task<Room> GetId(int id);
    public Task<List<Room>> Find(string key);
    public Task<IEnumerable<Room>> Get(string key);
    public Task<IEnumerable<Room>> GetPage(int pageNumber, int pageSize);
}

public class RoomInformationServiceProxy(IUnitOfWork? uow, RoomService service) : IRoomInformationService
{
    public async Task<List<Room>> AllAsync()
    {
        return await service.AllAsync();
    }

    public async Task<Room> GetId(int id)
    {
        return await service.GetId(id);
    }

    public async Task<List<Room>> Find(string key)
    {
        return await service.Find(key);
    }

    public async Task<IEnumerable<Room>> Get(string key)
    {
        return await service.Get(key);
    }

    public async Task<IEnumerable<Room>> GetPage(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            throw new ArgumentException("Invalid page number or page size");
        }
        return await service.GetPage(pageNumber, pageSize);
    }
}
public class RoomService(IUnitOfWork uow) : IRoomInformationService
{
    public async Task<List<Room>> AllAsync()
    {
        return await uow.Rooms.AllAsync();
    }

    public async Task<Room> GetId(int id)
    {
        return await Task.Run(() => uow.Rooms.Get(id));
    }

    public async Task<List<Room>> Find(string key)
    {
        return await uow.Rooms.FindAsync(e => e.RoomNumber.Contains(key));
    }

    public async Task<IEnumerable<Room>> Get(string key)
    {
        return await uow.Rooms.FindAsync(room => room.RoomNumber == key);
    }

    public async Task<IEnumerable<Room>> GetPage(int pageNumber, int pageSize)
    {
        return await uow.Rooms.GetPage(pageNumber, pageSize);
    }
}