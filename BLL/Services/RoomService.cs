using BLL.DataObjectTransforms;
using BLL.Mappers;
using DAL.Builders;
using DAL.Models;
using DAL.Repositories;
using Booking = DAL.Models.Booking;

namespace BLL.Services;
public interface IRoomService
{
    public Task<List<Room>> AllAsync();
    public Task<Room> GetIdAsync(int id);
    public Room GetId(int id);
    public Task<List<Room>> Find(string key);
    public Task<IEnumerable<Room>> Get(string key);
    public Task<IEnumerable<RoomsPageResponse>> GetPage(int pageNumber, int pageSize);
    public void Add(RoomCreateRequest room);
}

public class RoomServiceProxy(RoomService service, IUnitOfWork uow/*, IRoomMapeer? roomMapeer = null*/) : IRoomService
{
    public async Task<List<Room>> AllAsync()
    {
        return await service.AllAsync();
    }

    public async Task<Room> GetIdAsync(int id)
    {
        return await service.GetIdAsync(id);
    }

    public Room GetId(int id)
    {
        return service.GetId(id);
    }

    public async Task<List<Room>> Find(string key)
    {
        return await service.Find(key);
    }

    public async Task<IEnumerable<Room>> Get(string key)
    {
        return await service.Get(key);
    }

    public async Task<IEnumerable<RoomsPageResponse>> GetPage(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            throw new ArgumentException("Invalid page number or page size");
        }
        return await service.GetPage(pageNumber, pageSize);
    }

    public void Add(RoomCreateRequest room)
    {
        if (room is null)
        {
            throw new NotImplementedException();
        }
        service.Add(room);
    }
}
public class RoomService(IUnitOfWork uow, IRoomMapeer? roomMapeer = null) : IRoomService
{
    public async Task<List<Room>> AllAsync()
    {
        return await uow.Rooms.AllAsync();
    }

    public async Task<Room> GetIdAsync(int id)
    {
        return await Task.Run(() => uow.Rooms.Get(id));
    }

    public Room GetId(int id)
    {
        return uow.Rooms.Get(id);
    }

    public async Task<List<Room>> Find(string key)
    {
        return await uow.Rooms.FindAsync(e => e.RoomNumber.Contains(key));
    }

    public async Task<IEnumerable<Room>> Get(string key)
    {
        return await uow.Rooms.FindAsync(room => room.RoomNumber == key);
    }

    public async Task<IEnumerable<RoomsPageResponse>> GetPage(int pageNumber, int pageSize)
    {
        var rooms = await uow.Rooms.GetPage(pageNumber, pageSize);
        return await roomMapeer.Entity2RoomsPageAsync(rooms);
    }

    public void Add(RoomCreateRequest room)
    {
        try
        {
            Room eroom = new BaseBuilder<Room>()
                .With(r => r.RoomNumber, room.RoomNumber)
                .With(r => r.PricePerDay, room.PricePerDay)
                .With(r => r.MaxCapacity, room.MaxCapacity)
                .With(r => r.RoomTypeId, room.RoomTypeId)
                .With(r => r.Status, true)
                .With(r => r.DetailDescription, "No description")
                .With(r => r.RoomType, uow.RoomTypes.Get(room.RoomTypeId))
                .Build();
            uow.Rooms.Add(eroom);
            if (uow.Save() == 0)
            {
                throw new ();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}