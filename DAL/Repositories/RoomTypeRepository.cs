using DAL.Models;
using RoomType = DAL.Models.RoomType;

namespace DAL.Repositories;

public interface IRoomTypeRepository : IBaseRepository<RoomType>
{
    
}
public class RoomTypeRepository(FuminiHotelA2Context context) : BaseRepository<RoomType>(context), IRoomTypeRepository
{
    
}