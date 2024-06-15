using DAL.Entities;

namespace DAL.Repositories;

public interface IUnitOfWork : IDisposable
{
    public ICustomerRepository Customers { get; }
    public IRoomInformationRepository RoomInformations { get; }
    public IRoomTypeRepository RoomTypes { get; }
    public IBookingReservationRepository BookingReservations { get; }
    public IBookingDetailRepository BookingDetails { get; }
    int Complete();
}
public class UnitOfWork : IUnitOfWork
{
    private readonly FuminiHotelManagementContext _context;
    public ICustomerRepository Customers { get; private set; }
    public IRoomInformationRepository RoomInformations { get; private set; }
    public IRoomTypeRepository RoomTypes { get; private set; }
    public IBookingReservationRepository BookingReservations { get; private set; }
    public IBookingDetailRepository BookingDetails { get; private set; }

    public UnitOfWork(FuminiHotelManagementContext context, ICustomerRepository customer, IRoomInformationRepository roomInformations, IRoomTypeRepository roomTypes, IBookingReservationRepository bookingReservations, IBookingDetailRepository bookingDetails)
    {
        _context = context;
        BookingDetails = new BookingDetailRepository(context: _context);
        Customers = new CustomerRepository(_context);
        RoomInformations = new RoomInformationRepository(_context);
        RoomTypes = new RoomTypeRepository(_context);
        BookingReservations = new BookingReservationRepository(_context);
    }
    public int Complete()
    {
        return _context.SaveChanges();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}