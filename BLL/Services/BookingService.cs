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
        if (request.StartDate < DateTime.Now || request.EndDate < request.StartDate)
        {
            return false;
        }
        if (request.StartDate.Hour > request.EndDate.Hour)
        {
            return false;
        }
        Customer? customer = uow.Customers.Get(customerId);
        Room? room = uow.Rooms.Get(request.Id);
        if (customer is not null && room is not null)
        {
            if (room.Status == true)
            {
                return false;
            }
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
            
            int roomId = request.Id;
            Room? roomInfo = uow.Rooms.Get(roomId);
            Customer? customer = uow.Customers.Get(customerId);
            double totalPrice = uow.Bookings
                .TotalPrice(roomId, Utility.DayNumberCaculator(request.EndDate, request.StartDate));

            var bookingBuilder =
                new BaseBuilder<Booking>()
                    .With(br => br.Id, uow.Bookings.Max(booking => booking.Id) + 1)
                    .With(br => br.BookingDate, DateTime.Now)
                    .With(br => br.CustomerId, customerId)
                    .With(br => br.Status, true)
                    .With(br => br.TotalPrice, totalPrice)
                    .With(br => br.Customer, customer)
                    .Build();

            var bookingDetailBuilder =
                new BaseBuilder<BookingDetail>()
                    .With(bd => bd.Id, uow.BookingDetails.Max(detail => detail.Id) + 1)
                    .With(bd => bd.RoomId, roomId)
                    .With(bd => bd.Booking, bookingBuilder)
                    .With(bd => bd.StartDate, DateTime.Now)
                    .With(bd => bd.EndDate, request.EndDate)
                    .With(bd => bd.ActualPrice, roomInfo?.PricePerDay ?? 0)
                    .With(bd => bd.Room, roomInfo)
                    .Build();

            bookingBuilder.BookingDetails.Add(bookingDetailBuilder);

            await uow.Bookings.AddAsync(bookingBuilder);
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