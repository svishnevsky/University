using System.Web.Mvc;
using AutoMapper;
using GrSU.University.Clients.Web.Models.StudentGroups;
using GrSU.University.Domain;
using GrSU.University.Domain.Model;

namespace GrSU.University.Clients.Web.Mapping
{
    public class StudentGroupProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<StudentGroup, StudentGroupModel>()
                .ReverseMap();

            CreateMap<StudentGroup, StudentGroupListModel>()
                .ForMember(dst => dst.StudentCount, src => src.MapFrom(sg => DependencyResolver.Current.GetService<IStudentServiceAsync>().GetByGroupId(sg.Id).Result.Count));
        }
    }
}
