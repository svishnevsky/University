using AutoMapper;

namespace GrSU.University.Clients.Web.Controllers.StudentGroups
{
    using Domain;
    using Domain.Model;
    using Models.StudentGroups;

    public class StudentGroupController : BaseEntityController<IStudentGroupServiceAsync, StudentGroup, StudentGroupModel>
    {
        public StudentGroupController(IStudentGroupServiceAsync studentGroupService, IMapper mapper)
            : base(studentGroupService, mapper)
        {
        }
    }
}