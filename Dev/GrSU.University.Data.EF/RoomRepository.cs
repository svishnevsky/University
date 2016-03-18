namespace GrSU.University.Data.EF
{
    using Common;
    using Model;

    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(DataContext context) : base(context)
        {

        }
    }
}
