using DAL.Models;

namespace DAL.Repositories;

public interface IRoomRepository : IBaseRepository<Room>
{
    
}
public class RoomRepository(FuminiHotelA2Context context) : BaseRepository<Room>(context), IRoomRepository
{
    
}