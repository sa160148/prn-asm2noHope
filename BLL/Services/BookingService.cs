using AutoMapper;
using BLL.DataObjectTransforms;
using BLL.Utilities;
using DAL.Builders;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services;

public interface IBookingService
{
    /*public Task<List<BookingCreatingResponse>> AllAsync();*/
    public Task<bool> BookRoom(BookingRequest request, int customerId);
    public Task BookARoom(int roomId, int userId, string endDate);
    public BookingCreatingResponse CreatingBookARoom(int roomId);
}

public class BookingServiceProxy(IUnitOfWork uow, BookingService service)
    : IBookingService
{
    /*public async Task<List<BookingCreatingResponse>> AllAsync()
    {
        return await service.AllAsync();
    }*/

    public async Task<bool> BookRoom(BookingRequest request, int customerId)
    {
        if (request.BookingDetail!.StartDate < DateTime.Now ||
            request.BookingDetail!.EndDate < request.BookingDetail!.StartDate)
        {
            return false;
        }

        if (request.BookingDetail!.StartDate.Hour > request.BookingDetail!.EndDate.Hour)
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

    public async Task BookARoom(int roomId, int userId, string endDate)
    {
        DateTime? end = endDate is null ? null : DateTime.Parse(endDate);
        if (end is null)
            throw new ArgumentNullException($"{end}");
        await service.BookARoom(roomId, userId, endDate);
    }

    public BookingCreatingResponse CreatingBookARoom(int roomId)
    {
        if (uow.Rooms.Find(room => room.Id == roomId).FirstOrDefault() is not null)
        {
            return service.CreatingBookARoom(roomId);
        }

        return null;
    }
}

public class BookingService(IUnitOfWork uow, IMapper? mapper = null) : IBookingService
{
    /*public async Task<List<BookingCreatingResponse>> AllAsync()
    {
        IQueryable<Booking> query = uow.Bookings.GetAll().Where(buk => buk.Status == true).Include(book => book.BookingDetails.Where(bd => bd.BookingId == book.Id))
            .ThenInclude(bd => bd.Room);
        return await mapper!.Map<List<BookingCreatingResponse>>(query.ToList());
    }*/

    public async Task<bool> BookRoom(BookingRequest request, int customerId)
    {
        try
        {
            uow.BeginTransaction();

            int roomId = request.Id;
            Room? roomInfo = uow.Rooms.Get(roomId);
            Customer? customer = uow.Customers.Get(customerId);
            double totalPrice = uow.Bookings
                .TotalPrice(roomId,
                    Utility.DayNumberCaculator(request.BookingDetail!.EndDate, request.BookingDetail!.StartDate));

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
                    .With(bd => bd.EndDate, request.BookingDetail!.EndDate)
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

    public async Task BookARoom(int roomId, int userId, string endDate)
    {
        Room? room = uow.Rooms.Get(room => room.Id == roomId) as Room;

        BookingDetail bookingDetail = new BaseBuilder<BookingDetail>()
            .With(bd => bd.Id, uow.BookingDetails.Max(detail => detail.Id) + 1)
            .With(bd => bd.StartDate, DateTime.Now)
            .With(bd => bd.EndDate, DateTime.Parse(endDate))
            .With(bd => bd.RoomId, room?.Id)
            .With(bd => bd.ActualPrice, room?.PricePerDay ?? 0)
            .Build();

        Booking booking = new BaseBuilder<Booking>()
            .With(book => book.Id, uow.Bookings.Max(booking => booking.Id) + 1)
            .With(book => book.BookingDate, DateTime.Now)
            .With(book => book.CustomerId, userId)
            .With(book => book.Status, true)
            .With(book => book.TotalPrice,
                Utility.DayNumberCaculator(DateTime.Now, DateTime.Parse(endDate)) * (room?.PricePerDay ?? 0))
            .Build();
        bookingDetail.BookingId = booking.Id;
        await uow.BookingDetails.AddAsync(bookingDetail);
        await uow.Bookings.AddAsync(booking);
        int res = await uow.SaveAsync();
        if (res == 0)
        {
            throw new Exception("Cannot book a room as some problems occur!");
        }
    }

    public BookingCreatingResponse CreatingBookARoom(int roomId)
    {
        int dayNumber = 0;
        Room? eRoom = uow.Rooms.Get(room => room.Id == roomId) as Room;
        dayNumber = Utility.DayNumberCaculator(DateTime.Now, DateTime.Now.AddDays(1));

        Detail4BookingCreatingResponse resDetail = new BaseBuilder<Detail4BookingCreatingResponse>()
            .With(det => det.StartDate, DateTime.Now)
            .With(det => det.EndDate, null)
            .Build();
        Room4BookingCreatingResponse resRoom = new BaseBuilder<Room4BookingCreatingResponse>()
            .With(rum => rum.PricePerDay, eRoom?.PricePerDay ?? 0)
            .With(rum => rum.RoomNumber, eRoom?.RoomNumber)
            .With(rum => rum.MaxCapacity, eRoom?.MaxCapacity)
            .Build();
        BookingCreatingResponse resBook = new BaseBuilder<BookingCreatingResponse>()
            .With(buk => buk.TotalPrice, dayNumber * (eRoom?.PricePerDay ?? 0))
            .With(buk => buk.BookingDate, DateTime.Now)
            .With(buk => buk.Status, true)
            .With(buk => buk.BookingDetail.Room, resRoom)
            .With(buk => buk.BookingDetail, resDetail)
            .Build();
        return resBook;
    }
}