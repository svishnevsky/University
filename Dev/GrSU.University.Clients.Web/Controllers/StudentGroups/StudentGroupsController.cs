namespace GrSU.University.Clients.Web.Controllers.StudentGroups
{
    using Domain;
    using Domain.Model;
    using Models.StudentGroups;

    public class StudentGroupsController : BaseListController<IStudentGroupServiceAsync, StudentGroup, StudentGroupModel, StudentGroupListModel>
    {
        private readonly IStudentServiceAsync studentService;

        public StudentGroupsController(IStudentGroupServiceAsync studentGroupService, IStudentServiceAsync studentService)
            : base(studentGroupService)
        {
            this.studentService = studentService;
        }

        protected override StudentGroupListModel MapListModel(StudentGroup entity)
        {
            return new StudentGroupListModel
            {
                Id = entity.Id,
                Name = entity.Name,
                StudentCount = studentService.GetByGroupId(entity.Id).Result.Count
            };
        }

        protected override StudentGroup Map(StudentGroupModel model)
        {
            return new StudentGroup
            {
                Name = model.Name
            };
        }
    }
}