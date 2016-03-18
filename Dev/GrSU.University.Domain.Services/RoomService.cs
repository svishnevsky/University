namespace GrSU.University.Domain.Services
{
    using Common;
    using Data;
    using Model;

    public class RoomService : DomainServiceAsync<Room, Data.Model.Room>, IRoomServiceAsync
    {
        public RoomService(IRoomRepository repository) : base(repository)
        {
        }
    }
}
