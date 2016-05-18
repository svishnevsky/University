namespace GrSU.University.Clients.Web.Controllers.StudentGroups
{
    using Domain;
    using Domain.Model;
    using Models.StudentGroups;

    public class StudentGroupController : BaseEntityController<IStudentGroupServiceAsync, StudentGroup, StudentGroupModel>
    {
        public StudentGroupController(IStudentGroupServiceAsync studentGroupService)
            : base(studentGroupService)
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