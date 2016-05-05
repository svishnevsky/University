namespace GrSU.University.Data.EF
{
    using Common;
    using Model;

    public class StudentGroupRepository : Repository<StudentGroup>, IStudentGroupRepository
    {
        public StudentGroupRepository(DataContext context)
            : base(context)
        {

        }
    }
}
