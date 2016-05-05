namespace GrSU.University.Clients.Web.Controllers.Rooms
{
    using System.Web.Mvc;
    using Data.EF;
    using Domain;
    using Domain.Services;

    public abstract class BaseRoomController : Controller
    {
        protected readonly IRoomServiceAsync RoomService;

        protected BaseRoomController()
        {
            this.RoomService = new RoomService(new RoomRepository(new DataContext("defaultconnection")));
        }
	}
}