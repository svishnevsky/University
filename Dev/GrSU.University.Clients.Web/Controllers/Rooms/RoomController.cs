using AutoMapper;

namespace GrSU.University.Clients.Web.Controllers.Rooms
{
    using Domain;
    using Domain.Model;
    using Models.Rooms;

    public class RoomController : BaseEntityController<IRoomServiceAsync, Room, RoomModel>
    {
        public RoomController(IRoomServiceAsync roomService, IMapper mapper)
            : base(roomService, mapper)
        {
        }
    }
}