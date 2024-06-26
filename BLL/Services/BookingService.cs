using BLL.DataObjectTransforms;
using BLL.Utilities;
using DAL.Builders;
using DAL.Models;
using DAL.Repositories;
using Booking = DAL.Models.Booking;

namespace BLL.Services;

public interface IBookingService
{
    public Task<List<Booking>> All();
    public Task<bool> BookRoom(BookingRequest request, int customerId);
    public Task<IEnumerable<Booking>> GetPage(int pageNumber, int pageSize);
}

public class BookingServiceProxy(IUnitOfWork uow, BookingService service)
    : IBookingService
{
    public async Task<List<Booking>> All()
    {
        return await service.All();
    }

    public async Task<bool> BookRoom(BookingRequest request, int customerId)
    {
        Customer customer = uow.Customers.Get(customerId);
        Room room = uow.Rooms.Get(request.RoomId);
        if (customer is not null && room is not null)
        {
            return await service.BookRoom(request, customerId);
        }

        return false;
    }

    public async Task<IEnumerable<Booking>> GetPage(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            throw new ArgumentException("Invalid page number or page size");
        }

        return await service.GetPage(pageNumber, pageSize);
    }
}

public class BookingService(IUnitOfWork uow) : IBookingService
{
    public async Task<List<Booking>> All()
    {
        return await uow.Bookings.AllAsync();
    }

    public async Task<bool> BookRoom(BookingRequest request, int customerId)
    {
        try
        {
            uow.BeginTransaction();
            
            int roomId = request.RoomId;
            Room roomInfo = uow.Rooms.Get(roomId);
            Customer customer = uow.Customers.Get(customerId);
            double totalPrice = uow.Bookings
                .TotalPrice(roomId, Utility.DayNumberCaculator(request.EndDate, request.StartDate));

            var bookingReservationBuilder =
                new BaseBuilder<Booking>()
                    .With(br => br.Id, uow.Bookings.MaxId() + 1)
                    .With(br => br.BookingDate, DateTime.Now)
                    .With(br => br.CustomerId, customerId)
                    .With(br => br.Status, true)
                    .With(br => br.TotalPrice, totalPrice)
                    .With(br => br.Customer, customer)
                    .Build();

            var bookingDetailBuilder =
                new BaseBuilder<BookingDetail>()
                    .With(bd => bd.RoomId, roomId)
                    .With(bd => bd.Booking, bookingReservationBuilder)
                    .With(bd => bd.StartDate, DateTime.Now)
                    .With(bd => bd.EndDate, request.EndDate)
                    .With(bd => bd.ActualPrice, roomInfo.PricePerDay)
                    .With(bd => bd.Room, roomInfo)
                    .Build();

            bookingReservationBuilder.BookingDetails.Add(bookingDetailBuilder);

            await uow.Bookings.AddAsync(bookingReservationBuilder);
            await uow.BookingDetails.AddAsync(bookingDetailBuilder);
            
            uow.Commit();
            
            return uow.Save() != 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<Booking>> GetPage(int pageNumber, int pageSize)
    {
        return await uow.Bookings.GetPage(pageNumber, pageSize);
    }
}