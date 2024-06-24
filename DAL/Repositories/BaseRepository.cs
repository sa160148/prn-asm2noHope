using System.Linq.Expressions;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public interface IBaseRepository<T> where T : class
{
    public List<T> All();
    public Task<List<T>> AllAsync();
    public T Get<TKey>(TKey id);
    public IQueryable<T> Get();
    public IQueryable<T> Get(Expression<Func<T, bool>> predicate);
    public Task<T?> GetIdAsync(int id);
    public void Add(T e);
    public Task AddAsync(T e);
    public void Update(T e);
    public void Delete(int id);
    public Task DeleteAsync(int id);
    public List<T> Find(Expression<Func<T, bool>> predic);
    public Task<List<T>> FindAsync(Expression<Func<T, bool>> predic);
    public Task<T> FirstOrDefaultAsync();
    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    public TKey? Max<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> id);
    public Task<int> SaveAsync();
    public Task<IEnumerable<T>> GetPage(int pageNumber, int pageSize);
}
public class BaseRepository<T>(FuminiHotelManagementContext context, DbSet<T>? set = null) 
    
    : IBaseRepository<T> where T : class
{
    /*private readonly FuminiHotelManagementContext _context;
    private DbSet<T> set;
    public BaseRepository(FuminiHotelManagementContext context)
    {
        this._context = context;
        set = context.Set<T>();
    }*/
    public List<T> All()
    {
        return context.Set<T>().ToList();
    }

    public async Task<List<T>> AllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public T Get<TKey>(TKey id)
    {
        return context.Set<T>().Find((object) id) ?? throw new InvalidOperationException();
    }

    public IQueryable<T> Get()
    {
        return (IQueryable<T>) context.Set<T>();
    }

    public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
    {
        return context.Set<T>().Where(predicate);
    }

    public async Task<T?> GetIdAsync(int id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public void Add(T e)
    {
        context.Set<T>().Add(e);
    }

    public async Task AddAsync(T e)
    {
        await context.Set<T>().AddAsync(e);
    }
    
    public void Update(T e)
    {
        context.Set<T>().Update(e);
    }

    public void Delete(int id)
    {
        context.Set<T>().Remove(context.Set<T>().Find(id)!);
    }

    public async Task DeleteAsync(int id)
    {
        T entity = (await context.Set<T>().FindAsync(id))!;
        await Task.Run(() => context.Set<T>().Remove(entity));
    }
    
    public List<T> Find(Expression<Func<T, bool>> predic)
    {
        return context.Set<T>().Where(predic).ToList();
    }

    public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predic)
    {
        return await context.Set<T>().Where(predic).ToListAsync();
    }

    public async Task<T> FirstOrDefaultAsync()
    {
        return await context.Set<T>().FirstOrDefaultAsync() ?? null!;
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await context.Set<T>().FirstOrDefaultAsync(predicate) ?? null!;
    }

    public TKey? Max<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> id)
    {
        return context.Set<T>().Where(predicate).Max(id);
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetPage(int pageNumber, int pageSize)
    {
        return await context.Set<T>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
    }
}