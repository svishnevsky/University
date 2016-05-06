namespace GrSU.University.Clients.Web.Controllers.StudentGroups
{
    using Data.EF;
    using Domain;
    using Domain.Model;
    using Domain.Services;
    using Models.StudentGroups;

    public class StudentGroupsController : BaseListController<IStudentGroupServiceAsync, StudentGroup, StudentGroupModel, StudentGroupListModel>
    {
        public StudentGroupsController()
            : base(new StudentGroupService(new StudentGroupRepository(new DataContext("defaultconnection"))))
        {
        }

        protected override StudentGroupListModel MapListModel(StudentGroup entity)
        {
            return new StudentGroupListModel
            {
                Id = entity.Id,
                Name = entity.Name,
                StudentCount = 0 // TODO: calculate student count in group
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