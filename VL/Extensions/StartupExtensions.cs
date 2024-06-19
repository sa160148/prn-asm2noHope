using BLL.Services;
using DAL.Repositories;

namespace VL.Extensions;

public static class StartupExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service)
    {
        #region Singleton

        

        #endregion
        
        #region Transient

        service.AddTransient<IUnitOfWork, UnitOfWork>();

        #endregion

        #region Scoped

        service.AddScoped<ICustomerRepository, CustomerRepository>();
        
        service.AddScoped<IRoomInformationRepository, RoomInformationRepository>();
        
        service.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        
        service.AddScoped<IBookingReservationRepository, BookingReservationRepository>();
        
        service.AddScoped<IBookingDetailRepository, BookingDetailRepository>();
         
        
        service.AddScoped<ICustomerService, CustomerService>();
        
        service.AddScoped<IRoomInformationService, RoomInformationService>();
        
        service.AddScoped<IRoomTypeService, RoomTypeService>();
        
        service.AddScoped<IBookingReservationService>(serviceProvider =>
            new BookingReservationServiceProxy(serviceProvider.GetRequiredService<IUnitOfWork>(),
                new BookingReservationService(serviceProvider.GetRequiredService<IUnitOfWork>())));

        service.AddScoped<IBookingDetailService, BookingDetailService>();

        #endregion
        
        return service;
    }
}