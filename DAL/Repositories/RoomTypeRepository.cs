using DAL.Entities;

namespace DAL.Repositories;

public interface IRoomTypeRepository : IBaseRepository<RoomType>
{
    
}
public class RoomTypeRepository(FuminiHotelManagementContext context) : BaseRepository<RoomType>(context), IRoomTypeRepository
{
    
}