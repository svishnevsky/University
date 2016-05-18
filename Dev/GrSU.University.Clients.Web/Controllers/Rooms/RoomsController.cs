using AutoMapper;

namespace GrSU.University.Clients.Web.Controllers.Rooms
{
    using Domain;
    using Domain.Model;
    using Models.Rooms;

    public class RoomsController : BaseListController<IRoomServiceAsync, Room, RoomModel, RoomListModel>
    {
        public RoomsController(IRoomServiceAsync roomService, IMapper mapper)
            : base(roomService, mapper)
        {
        }
    }
}