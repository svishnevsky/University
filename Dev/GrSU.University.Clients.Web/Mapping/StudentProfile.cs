using System.Web.Mvc;
using AutoMapper;
using GrSU.University.Clients.Web.Models.Students;
using GrSU.University.Domain;
using GrSU.University.Domain.Model;

namespace GrSU.University.Clients.Web.Mapping
{
    public class StudentProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Student, StudentModel>()
                .ReverseMap();

            CreateMap<Student, StudentListModel>()
                .ForMember(dst => dst.Group, src => src.MapFrom(s => DependencyResolver.Current.GetService<IStudentGroupServiceAsync>().GetAsync(s.GroupId).Result));

            CreateMap<StudentGroup, GroupModel>();
        }
    }
}
