namespace GrSU.University.Data.EF.Configurations
{
    using Common;
    using Model;

    public class StudentGroupConfiguration : BaseModelConfiguration<StudentGroup>
    {
        public StudentGroupConfiguration()
        {
            Property(p => p.Name).HasMaxLength(50).IsRequired();
        }
    }
}
