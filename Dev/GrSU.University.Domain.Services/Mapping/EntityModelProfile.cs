namespace GrSU.University.Domain.Services.Mapping
{
    using AutoMapper;
    using Data.Model;

    public class EntityModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Room, Model.Room>();
            CreateMap<Student, Model.Student>();
            CreateMap<Lecture, Model.Lecture>();
            CreateMap<StudentGroup, Model.StudentGroup>();
            CreateMap<Employee, Model.Employee>();
        }
    }
}
