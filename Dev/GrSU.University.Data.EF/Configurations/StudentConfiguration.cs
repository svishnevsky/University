namespace GrSU.University.Data.EF.Configurations
{
    using Common;
    using Model;

    public class StudentConfiguration : BaseModelConfiguration<Student>
    {
        public StudentConfiguration()
        {
            Property(p => p.FirstName).HasMaxLength(70).IsRequired();

            Property(p => p.LastName).HasMaxLength(70).IsRequired();

            Property(p => p.GroupId).IsRequired();
        }
    }
}
