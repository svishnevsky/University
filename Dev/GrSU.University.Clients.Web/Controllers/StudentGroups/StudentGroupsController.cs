using AutoMapper;

namespace GrSU.University.Clients.Web.Controllers.StudentGroups
{
    using Domain;
    using Domain.Model;
    using Models.StudentGroups;

    public class StudentGroupsController : BaseListController<IStudentGroupServiceAsync, StudentGroup, StudentGroupModel, StudentGroupListModel>
    {
        private readonly IStudentServiceAsync studentService;

        public StudentGroupsController(IStudentGroupServiceAsync studentGroupService, IStudentServiceAsync studentService, IMapper mapper)
            : base(studentGroupService, mapper)
        {
            this.studentService = studentService;
        }

        protected override StudentGroupListModel MapListModel(StudentGroup entity)
        {
            var model = base.MapListModel(entity);
            model.StudentCount = studentService.GetByGroupId(entity.Id).Result.Count;

            return model;
        }
    }
}