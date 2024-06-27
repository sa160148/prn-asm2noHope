using BLL.Mappers;
using BLL.Services;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace VL.Extensions;

public static class StartupExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service)
    {
        /* From lower to upper is mean the lifetime service
         , lower is short lifetime and upper is long lifetime. */
        #region Singleton

        

        #endregion
        
        #region Scoped
        
        service.AddScoped<IUnitOfWork, UnitOfWork>();
        
        service.AddScoped<FuminiHotelA2Context>();

        service.AddScoped<ICustomerRepository, CustomerRepository>();
        
        service.AddScoped<IRoomRepository, RoomRepository>();
        
        service.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        
        service.AddScoped<IBookingRepository, BookingRepository>();
        
        service.AddScoped<IBookingDetailRepository, BookingDetailRepository>();
         
        
        service.AddScoped<ICustomerService, CustomerService>();

        service.AddScoped<IRoomService>(provider =>
            new RoomService(provider.GetRequiredService<IUnitOfWork>() , provider.GetService<IRoomMapeer>()));
        
        service.AddScoped<IRoomTypeService, RoomTypeService>();
        
        service.AddScoped<IBookingService>(serviceProvider =>
            new BookingServiceProxy(serviceProvider.GetRequiredService<IUnitOfWork>(),
                new BookingService(serviceProvider.GetRequiredService<IUnitOfWork>())));

        service.AddScoped<IBookingDetailService, BookingDetailService>();

        #endregion
        
        #region Transient

        service.AddTransient<IRoomMapeer, RoomMapper>();

        #endregion
        
        return service;
    }
}