using AutoMapper;
using BLL.DataObjectTransforms;
using DAL.Models;

namespace BLL.AMappers;

public class Mapper : Profile
{
    public Mapper()
    {
        #region Room

        CreateMap<Room, RoomsPageResponse>().ReverseMap();
        CreateMap<Room, RoomResponse>().ReverseMap();

        #endregion

        #region RoomType

        CreateMap<RoomType, RoomTypeResponse>().ReverseMap();

        #endregion

        #region Booking

        CreateMap<Booking, Room4BookingCreatingResponse>().ReverseMap();
        CreateMap<Booking, BookingCreatingResponse>().ReverseMap();
        
        CreateMap<BookingRequest, Booking>().ReverseMap();

        #endregion

        #region BookingDetail

        CreateMap<BookingDetail, Detail4BookingCreatingResponse>().ReverseMap();
        CreateMap<BookingDetail, BookingDetailResponse>().ReverseMap();
        
        #endregion
    }
}