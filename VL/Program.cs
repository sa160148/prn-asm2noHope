using BLL.Services;
using DAL.Repositories;
using BookingReservationRepository = DAL.Repositories.BookingReservationRepository;
using IBookingReservationRepository = DAL.Repositories.IBookingReservationRepository;

namespace VL;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }

        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<IRoomInformationRepository, RoomInformationRepository>();
        builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        builder.Services.AddScoped<IBookingReservationRepository, BookingReservationRepository>();
        builder.Services.AddScoped<IBookingDetailRepository, BookingDetailRepository>();
        
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddScoped<IRoomInformationService, RoomInformationService>();
        builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();
        builder.Services.AddScoped<IBookingReservationService, BookingReservationService>();
        builder.Services.AddScoped<IBookingDetailService, BookingDetailService>();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}