using System.Linq.Expressions;

namespace DAL.Repositories;

public interface IBaseRepository<T> where T : class
{
    public List<T> All();
    public T GetId(int id);
    public void Add(T e);
    public void Update(T e);
    public void Delete(int id);
    public List<T> Find(Expression<Func<T, bool>> predic);
}
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    public List<T> All()
    {
        throw new NotImplementedException();
    }

    public T GetId(int id)
    {
        throw new NotImplementedException();
    }

    public void Add(T e)
    {
        throw new NotImplementedException();
    }

    public void Update(T e)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<T> Find(Expression<Func<T, bool>> predic)
    {
        throw new NotImplementedException();
    }
}