namespace GrSU.University.Clients.Web.Controllers.StudentGroups
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Domain.Model;
    using Models.StudentGroups;

    public class StudentGroupController : BaseStudentGroupsController
    {
        [HttpGet]
        [ActionName("Index")]
        public async Task<ActionResult> Get(int id)
        {
            var group = await base.StudentGroupService.GetAsync(id);

            if (group == null)
            {
                return HttpNotFound();
            }

            var model = new StudentGroupModel
            {

                Id = group.Id,
                Name = group.Name,
            };

            return View("Update", model);
        }

        [HttpPut]
        [ActionName("Index")]
        public async Task<ActionResult> Update(StudentGroupModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }

            var newGroup = await base.StudentGroupService.UpdateAsync(new StudentGroup
            {
                Id = model.Id,
                Name = model.Name,
            });

            if (newGroup == null)
            {
                ModelState.AddModelError("form", "Не удалось сохранить группу.");
                return View("Update", model);
            }

            return RedirectToAction("Index", "StudentGroups");
        }
        
        [HttpDelete]
        [ActionName("Index")]
        public async Task<ActionResult> Delete(int id)
        {
            await base.StudentGroupService.DeleteAsync(id);
            return RedirectToAction("Index", "StudentGroups");
        }
	}
}