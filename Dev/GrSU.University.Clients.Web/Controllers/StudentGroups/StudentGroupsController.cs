using AutoMapper;

namespace GrSU.University.Clients.Web.Controllers.StudentGroups
{
    using Domain;
    using Domain.Model;
    using Models.StudentGroups;

    public class StudentGroupsController : BaseListController<IStudentGroupServiceAsync, StudentGroup, StudentGroupModel, StudentGroupListModel>
    {
        public StudentGroupsController(IStudentGroupServiceAsync studentGroupService, IMapper mapper)
            : base(studentGroupService, mapper)
        {
        }
    }
}