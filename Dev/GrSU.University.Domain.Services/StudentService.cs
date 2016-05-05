namespace GrSU.University.Domain.Services
{
    using Common;
    using Data;
    using Model;

    public class StudentService : DomainServiceAsync<Student, Data.Model.Student>, IStudentServiceAsync
    {
        public StudentService(IStudentRepository repository)
            : base(repository)
        {
        }
    }
}
