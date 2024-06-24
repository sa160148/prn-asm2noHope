using DAL.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace DAL.Repositories;

public interface IUnitOfWork : IDisposable
{
    public ICustomerRepository Customers { get; }
    public IRoomInformationRepository RoomInformations { get; }
    public IRoomTypeRepository RoomTypes { get; }
    public IBookingReservationRepository BookingReservations { get; }
    public IBookingDetailRepository BookingDetails { get; }
    public void BeginTransaction();
    public void Commit();
    public void Rollback();
    
    public int Save();
}
public class UnitOfWork : IUnitOfWork
{
    private readonly FuminiHotelManagementContext _context;
    private IDbContextTransaction _transaction;
    public ICustomerRepository Customers { get; private set; }
    public IRoomInformationRepository RoomInformations { get; private set; }
    public IRoomTypeRepository RoomTypes { get; private set; }
    public IBookingReservationRepository BookingReservations { get; private set; }
    public IBookingDetailRepository BookingDetails { get; private set; }

    public UnitOfWork(FuminiHotelManagementContext context)
    {
        _context = context;
        BookingDetails = new BookingDetailRepository(_context);
        Customers = new CustomerRepository(_context);
        RoomInformations = new RoomInformationRepository(_context);
        RoomTypes = new RoomTypeRepository(_context);
        BookingReservations = new BookingReservationRepository(_context);
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