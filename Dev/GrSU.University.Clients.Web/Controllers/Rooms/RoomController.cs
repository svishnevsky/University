namespace GrSU.University.Clients.Web.Controllers.Rooms
{
    using Domain;
    using Domain.Model;
    using Models.Rooms;

    public class RoomController : BaseEntityController<IRoomServiceAsync, Room, RoomModel>
    {
        public RoomController(IRoomServiceAsync roomService)
            : base(roomService)
        {
        }

        protected override Room Map(RoomModel model)
        {
            return new Room
            {
                Id = model.Id,
                Number = model.Number,
                SitsCount = model.SitsCount
            };
        }

        protected override RoomModel Map(Room entity)
        {
            return new RoomModel
            {
                Id = entity.Id,
                Number = entity.Number,
                SitsCount = entity.SitsCount
            };
        }
    }
}