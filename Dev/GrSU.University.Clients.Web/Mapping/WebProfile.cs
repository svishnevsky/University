using AutoMapper;
using GrSU.University.Clients.Web.Models.Rooms;
using GrSU.University.Clients.Web.Models.StudentGroups;
using GrSU.University.Clients.Web.Models.Students;
using GrSU.University.Domain.Model;

namespace GrSU.University.Clients.Web.Mapping
{
    public class WebProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Room, RoomModel>()
                .ReverseMap();

            CreateMap<Room, RoomListModel>();

            CreateMap<StudentGroup, StudentGroupModel>()
                .ReverseMap();

            CreateMap<StudentGroup, StudentGroupListModel>();

            CreateMap<Student, StudentModel>()
                .ReverseMap();

            CreateMap<Student, StudentListModel>();

            CreateMap<StudentGroup, GroupModel>();
        }
    }
}
