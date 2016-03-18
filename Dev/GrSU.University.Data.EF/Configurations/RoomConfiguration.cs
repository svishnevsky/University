namespace GrSU.University.Data.EF.Configurations
{
    using Common;
    using Model;

    public class RoomConfiguration : BaseModelConfiguration<Room>
    {
        public RoomConfiguration()
        {
            Property(p => p.Number).HasMaxLength(50).IsRequired();

            Property(p => p.SitsCount).IsRequired();
        }
    }
}
