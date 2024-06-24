using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;
public interface IRoomInformationService
{
    public Task<List<RoomInformation>> AllAsync();
    public Task<RoomInformation> GetId(int id);
    public Task<List<RoomInformation>> Find(string key);
    public Task<IEnumerable<RoomInformation>> Get(string key);
    public Task<IEnumerable<RoomInformation>> GetPage(int pageNumber, int pageSize);
}

public class RoomInformationServiceProxy(IUnitOfWork? uow, RoomInformationService service) : IRoomInformationService
{
    public async Task<List<RoomInformation>> AllAsync()
    {
        return await service.AllAsync();
    }

    public async Task<RoomInformation> GetId(int id)
    {
        return await service.GetId(id);
    }

    public async Task<List<RoomInformation>> Find(string key)
    {
        return await service.Find(key);
    }

    public async Task<IEnumerable<RoomInformation>> Get(string key)
    {
        return await service.Get(key);
    }

    public async Task<IEnumerable<RoomInformation>> GetPage(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            throw new ArgumentException("Invalid page number or page size");
        }
        return await service.GetPage(pageNumber, pageSize);
    }
}
public class RoomInformationService(IUnitOfWork uow) : IRoomInformationService
{
    public async Task<List<RoomInformation>> AllAsync()
    {
        return await uow.RoomInformations.AllAsync();
    }

    public async Task<RoomInformation> GetId(int id)
    {
        return await Task.Run(() => uow.RoomInformations.Get(id));
    }

    public async Task<List<RoomInformation>> Find(string key)
    {
        return await uow.RoomInformations.FindAsync(e => e.RoomNumber.Contains(key));
    }

    public async Task<IEnumerable<RoomInformation>> Get(string key)
    {
        return await uow.RoomInformations.FindAsync(room => room.RoomNumber == key);
    }

    public async Task<IEnumerable<RoomInformation>> GetPage(int pageNumber, int pageSize)
    {
        return await uow.RoomInformations.GetPage(pageNumber, pageSize);
    }
}