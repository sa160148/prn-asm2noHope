using System.Linq.Expressions;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;
public interface IRoomInformationService
{
    public List<RoomInformation> All();
    public RoomInformation GetId(int id);
    public List<RoomInformation> Find(string key);
}
public class RoomInformationService(IUnitOfWork uow) : IRoomInformationService
{
    public List<RoomInformation> All()
    {
        return uow.RoomInformations.All();
    }

    public RoomInformation GetId(int id)
    {
        return uow.RoomInformations.Get(id);
    }

    public List<RoomInformation> Find(string key)
    {
        return uow.RoomInformations.Find(e => e.RoomNumber.Contains(key));
    }

}