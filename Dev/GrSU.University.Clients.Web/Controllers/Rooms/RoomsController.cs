namespace GrSU.University.Clients.Web.Controllers.Rooms
{
    using Domain;
    using Domain.Model;
    using Models.Rooms;

    public class RoomsController : BaseListController<IRoomServiceAsync, Room, RoomModel, RoomListModel>
    {
        public RoomsController(IRoomServiceAsync roomService)
            : base(roomService)
        {
        }

        protected override Room Map(RoomModel model)
        {
            return new Room
            {
                Number = model.Number,
                SitsCount = model.SitsCount
            };
        }

        protected override RoomListModel MapListModel(Room entity)
        {
            return new RoomListModel
            {
                Id = entity.Id,
                Number = entity.Number,
                SitsCount = entity.SitsCount
            };
        }
    }
}