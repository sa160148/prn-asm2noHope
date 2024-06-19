using BLL.DataObjectTransforms;
using BLL.Utilities;
using DAL.Builders;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;
public interface IBookingReservationService
{
    public Task<List<BookingReservation>> All();
    public Task<bool> BookRoom(BookingRequest request ,int customerId);
}

public class BookingReservationServiceProxy(IUnitOfWork uow, BookingReservationService service) : IBookingReservationService
{
    public async Task<List<BookingReservation>> All()
    {
        return await service.All();
    }

    public async Task<bool> BookRoom(BookingRequest request, int customerId)
    {
        return await service.BookRoom(request, customerId);
    }
}
public class BookingReservationService(IUnitOfWork uow) : IBookingReservationService
{
    public async Task<List<BookingReservation>> All()
    {
        return await uow.BookingReservations.AllAsync();
    }

    public async Task<bool> BookRoom(BookingRequest request,int customerId)
    {
        int roomId = request.RoomId;
        RoomInformation roomInfo =  uow.RoomInformations.Get(roomId);
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
        return uow.Save() != 0;
    }
}