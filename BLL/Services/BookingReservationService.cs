using BLL.DataObjectTransforms;
using BLL.Utilities;
using DAL.Builders;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public interface IBookingReservationService
{
    public Task<List<BookingReservation>> All();
    public Task<bool> BookRoom(BookingRequest request, int customerId);
    public Task<IEnumerable<BookingReservation>> GetPage(int pageNumber, int pageSize);
}

public class BookingReservationServiceProxy(IUnitOfWork uow, BookingReservationService service)
    : IBookingReservationService
{
    public async Task<List<BookingReservation>> All()
    {
        return await service.All();
    }

    public async Task<bool> BookRoom(BookingRequest request, int customerId)
    {
        Customer customer = uow.Customers.Get(customerId);
        RoomInformation room = uow.RoomInformations.Get(request.RoomId);
        if (customer is not null && room is not null)
        {
            return await service.BookRoom(request, customerId);
        }

        return false;
    }

    public async Task<IEnumerable<BookingReservation>> GetPage(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            throw new ArgumentException("Invalid page number or page size");
        }

        return await service.GetPage(pageNumber, pageSize);
    }
}

public class BookingReservationService(IUnitOfWork uow) : IBookingReservationService
{
    public async Task<List<BookingReservation>> All()
    {
        return await uow.BookingReservations.AllAsync();
    }

    public async Task<bool> BookRoom(BookingRequest request, int customerId)
    {
        try
        {
            uow.BeginTransaction();
            
            int roomId = request.RoomId;
            RoomInformation roomInfo = uow.RoomInformations.Get(roomId);
            Customer customer = uow.Customers.Get(customerId);
            double totalPrice = uow.BookingReservations
                .TotalPrice(roomId, Utility.DayNumberCaculator(request.EndDate, request.StartDate));

            var bookingReservationBuilder =
                new BaseBuilder<BookingReservation>()
                    .With(br => br.BookingReservationId, uow.BookingReservations.MaxId() + 1)
                    .With(br => br.BookingDate, Utility.CurrentDate())
                    .With(br => br.CustomerId, customerId)
                    .With(br => br.BookingStatus, true)
                    .With(br => br.TotalPrice, totalPrice)
                    .With(br => br.Customer, customer)
                    .Build();

            var bookingDetailBuilder =
                new BaseBuilder<BookingDetail>()
                    .With(bd => bd.RoomId, roomId)
                    .With(bd => bd.BookingReservation, bookingReservationBuilder)
                    .With(bd => bd.StartDate, Utility.CurrentDate())
                    .With(bd => bd.EndDate, request.EndDate)
                    .With(bd => bd.ActualPrice, roomInfo.RoomPricePerDay)
                    .With(bd => bd.Room, roomInfo)
                    .Build();

            bookingReservationBuilder.BookingDetails.Add(bookingDetailBuilder);

            await uow.BookingReservations.AddAsync(bookingReservationBuilder);
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

    public async Task<IEnumerable<BookingReservation>> GetPage(int pageNumber, int pageSize)
    {
        return await uow.BookingReservations.GetPage(pageNumber, pageSize);
    }
}