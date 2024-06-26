using DAL.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace DAL.Repositories;

public interface IUnitOfWork : IDisposable
{
    public ICustomerRepository Customers { get; }
    public IRoomRepository Rooms { get; }
    public IRoomTypeRepository RoomTypes { get; }
    public IBookingRepository Bookings { get; }
    public IBookingDetailRepository BookingDetails { get; }
    public void BeginTransaction();
    public void Commit();
    public void Rollback();
    
    public int Save();
}
public class UnitOfWork : IUnitOfWork
{
    private readonly FuminiHotelA2Context _context;
    private IDbContextTransaction _transaction;
    public ICustomerRepository Customers { get; private set; }
    public IRoomRepository Rooms { get; private set; }
    public IRoomTypeRepository RoomTypes { get; private set; }
    public IBookingRepository Bookings { get; private set; }
    public IBookingDetailRepository BookingDetails { get; private set; }

    public UnitOfWork(FuminiHotelA2Context context)
    {
        _context = context;
        BookingDetails = new BookingDetailRepository(_context);
        Customers = new CustomerRepository(_context);
        Rooms = new RoomRepository(_context);
        RoomTypes = new RoomTypeRepository(_context);
        Bookings = new BookingRepository(_context);
    }
    public int Save()
    {
        return _context.SaveChanges();
    }
    public void BeginTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
    }
    
    public void Commit()
    {
        try
        
        {
            _transaction.Commit();
        }
        catch
        {
            _transaction.Rollback();
            throw;
        }
        finally
        
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
    }
    public void Rollback()
    {
        _transaction.Rollback();
        _transaction.Dispose();
        _transaction = null;
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}