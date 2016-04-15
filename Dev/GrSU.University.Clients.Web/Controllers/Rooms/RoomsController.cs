using System.Web.Mvc;

namespace GrSU.University.Clients.Web.Controllers.Rooms
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data.EF;
    using Domain;
    using Domain.Model;
    using Domain.Services;
    using Models.Rooms;

    public class RoomsController : Controller
    {
        private readonly IRoomServiceAsync roomService;

        public RoomsController()
        {
            this.roomService = new RoomService(new RoomRepository(new DataContext("defaultconnection")));
        }

        //
        // GET: /Rooms/
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get()
        {
            var rooms = this.roomService.GetAsync()
                .Result
                .Select(r => new RoomModel
                {
                    Id = r.Id,
                    SitsCount = r.SitsCount,
                    Number = r.Number
                });

            return View("Get", rooms);
        }

        [HttpGet]
        public ActionResult New(RoomModel model)
        {
            return View(model);
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<ActionResult> SaveNew(RoomModel model)
        {
            if (!ModelState.IsValid)
            {
                return New(model);
            }

            var newRoom = await this.roomService.AddAsync(new Room
            {
                SitsCount = model.SitsCount,
                Number = model.Number
            });

            if (newRoom == null)
            {
                ModelState.AddModelError("form", "Не удалось сохранить новую аудиторию.");
                return New(model);
            }

            return RedirectToAction("Index");
        }
	}
}