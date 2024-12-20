using AutoMapper;
using BLL.DataObjectTransforms;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services;

public interface IBookingDetailService
{
    public Task<List<BookingDetailResponse>> GetAll();
}

public class BookingDetailService(IUnitOfWork uow, IMapper? mapper = null) : IBookingDetailService
{
    public async Task<List<BookingDetailResponse>> GetAll()
    {
        IQueryable<BookingDetail> query = uow.BookingDetails.GetAll()
            .Include(bd => bd.Booking).ThenInclude(buk => buk.Customer)
            .Include(bd => bd.Room);
        return await query.Select(bd => mapper.Map<BookingDetailResponse>(bd)).ToListAsync();
    }
}