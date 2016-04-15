
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrSU.University.Clients.Web.Controllers.Rooms
{
    using System.Threading.Tasks;
    using Data.EF;
    using Domain;
    using Domain.Model;
    using Domain.Services;
    using Models.Rooms;

    public class RoomController : Controller
    {
        private readonly IRoomServiceAsync roomService;

        public RoomController()
        {
            this.roomService = new RoomService(new RoomRepository(new DataContext("defaultconnection")));
        }
        //
        // GET: /Room/


        [HttpGet]
        [ActionName("Index")]

        public ActionResult Get(int id)
        {
            var room = this.roomService.GetAsync(id).Result;

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

            var newRoom = await this.roomService.UpdateAsync(new Room
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

            await this.roomService.DeleteAsync(id);
            return RedirectToAction("Index", "Rooms");
        }
	}
}