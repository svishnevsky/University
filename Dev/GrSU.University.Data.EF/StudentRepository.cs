namespace GrSU.University.Data.EF
{
    using Common;
    using Model;

    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DataContext context)
            : base(context)
        {

        }
    }
}
