using BLL.Services;
using DAL.Entities;
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
        
        service.AddScoped<FuminiHotelManagementContext>();

        service.AddScoped<ICustomerRepository, CustomerRepository>();
        
        service.AddScoped<IRoomInformationRepository, RoomInformationRepository>();
        
        service.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        
        service.AddScoped<IBookingReservationRepository, BookingReservationRepository>();
        
        service.AddScoped<IBookingDetailRepository, BookingDetailRepository>();
         
        
        service.AddScoped<ICustomerService, CustomerService>();
        
        service.AddScoped<IRoomInformationService>( provider => 
            new RoomInformationServiceProxy(provider.GetRequiredService<IUnitOfWork>(),
                new RoomInformationService(provider.GetRequiredService<IUnitOfWork>())));
        
        service.AddScoped<IRoomTypeService, RoomTypeService>();
        
        service.AddScoped<IBookingReservationService>(serviceProvider =>
            new BookingReservationServiceProxy(serviceProvider.GetRequiredService<IUnitOfWork>(),
                new BookingReservationService(serviceProvider.GetRequiredService<IUnitOfWork>())));

        service.AddScoped<IBookingDetailService, BookingDetailService>();

        #endregion
        
        #region Transient
        
        

        #endregion
        
        return service;
    }
}