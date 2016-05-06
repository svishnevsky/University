namespace GrSU.University.Clients.Web.Controllers.StudentGroups
{
    using Data.EF;
    using Domain;
    using Domain.Model;
    using Domain.Services;
    using Models.StudentGroups;

    public class StudentGroupController : BaseEntityController<IStudentGroupServiceAsync, StudentGroup, StudentGroupModel>
    {
        public StudentGroupController()
            : base(new StudentGroupService(new StudentGroupRepository(new DataContext("defaultconnection"))))
        {
        }

        protected override StudentGroup Map(StudentGroupModel model)
        {
            return new StudentGroup
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        protected override StudentGroupModel Map(StudentGroup entity)
        {
            return new StudentGroupModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}