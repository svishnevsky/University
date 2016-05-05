namespace GrSU.University.Clients.Web.Controllers.Rooms
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Domain.Model;
    using Models.Rooms;

    public class RoomsController : BaseRoomController
    {
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get()
        {
            var rooms = base.RoomService.GetAsync()
                .Result
                .Select(r => new RoomModel
                {
                    Id = r.Id,
                    SitsCount = r.SitsCount,
                    Number = r.Number
                })
                .ToList();

            return View("Get", rooms);
        }

        [HttpGet]
        [ActionName("New")]
        public ActionResult New(RoomModel model)
        {
            return View("New", model);
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<ActionResult> SaveNew(RoomModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("New", model);
            }

            var newRoom = await base.RoomService.AddAsync(new Room
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