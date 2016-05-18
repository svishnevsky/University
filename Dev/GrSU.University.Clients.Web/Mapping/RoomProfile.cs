using AutoMapper;
using GrSU.University.Clients.Web.Models.Rooms;
using GrSU.University.Domain.Model;

namespace GrSU.University.Clients.Web.Mapping
{
    public class RoomProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Room, RoomModel>()
                .ReverseMap();

            CreateMap<Room, RoomListModel>();
        }
    }
}
