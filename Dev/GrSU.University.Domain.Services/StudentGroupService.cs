namespace GrSU.University.Domain.Services
{
    using Common;
    using Data;
    using Model;

    public class StudentGroupService : DomainServiceAsync<StudentGroup, Data.Model.StudentGroup>, IStudentGroupServiceAsync
    {
        public StudentGroupService(IStudentGroupRepository repository)
            : base(repository)
        {
        }
    }
}
