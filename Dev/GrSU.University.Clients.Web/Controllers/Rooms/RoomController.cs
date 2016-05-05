namespace GrSU.University.Clients.Web.Controllers.Rooms
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Domain.Model;
    using Models.Rooms;

    public class RoomController : BaseRoomController
    {
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(int id)
        {
            var room = base.RoomService.GetAsync(id).Result;

            if (room == null)
            {
                return HttpNotFound();
            }

            var model = new RoomModel
            {

                Id = room.Id,
                Number = room.Number,
                SitsCount = room.SitsCount
            };

            return View("Update", model);
        }

        [HttpPut]
        [ActionName("Index")]
        public async Task<ActionResult> Update(RoomModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }

            var newRoom = await base.RoomService.UpdateAsync(new Room
            {
                SitsCount = model.SitsCount,
                Number = model.Number,
                Id = model.Id
            });

            if (newRoom == null)
            {
                ModelState.AddModelError("form", "Не удалось сохранить новую аудиторию.");
                return View("Update", model);
            }

            return RedirectToAction("Index", "Rooms");
        }
        
        [HttpDelete]
        [ActionName("Index")]
        public async Task<ActionResult> Delete(int id)
        {
            await base.RoomService.DeleteAsync(id);
            return RedirectToAction("Index", "Rooms");
        }
	}
}