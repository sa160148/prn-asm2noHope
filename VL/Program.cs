using AutoMapper;
using DAL.Models;
using DAL.Repositories;
using VL.Extensions;
using VL.Hubs;
using Mapper = BLL.AMappers.Mapper;

namespace VL;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddApplicationService();
        builder.Services.AddSignalR();
        builder.Services.AddSession();
        var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new Mapper()); });
        IMapper mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();
        app.UseSession();

        app.UseAuthorization();
        app.MapHub<SystemR>("/systemr");
        app.MapRazorPages();

        app.Run();
    }
}