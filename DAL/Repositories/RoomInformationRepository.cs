using DAL.Entities;

namespace DAL.Repositories;

public interface IRoomInformationRepository : IBaseRepository<RoomInformation>
{
    
}
public class RoomInformationRepository(FuminiHotelManagementContext context) : BaseRepository<RoomInformation>(context), IRoomInformationRepository
{
    
}