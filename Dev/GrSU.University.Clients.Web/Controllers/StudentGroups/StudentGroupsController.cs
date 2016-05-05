namespace GrSU.University.Clients.Web.Controllers.StudentGroups
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Domain.Model;
    using Models.StudentGroups;

    public class StudentGroupsController : BaseStudentGroupsController
    {
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get()
        {
            var groups = base.StudentGroupService.GetAsync()
                .Result
                .Select(r => new StudentGroupListModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    StudentCount = 0 //TODO: get student count in target group
                })
                .ToList();

            return View("Get", groups);
        }

        [HttpGet]
        [ActionName("New")]
        public ActionResult New(StudentGroupModel model)
        {
            return View("New", model);
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<ActionResult> SaveNew(StudentGroupModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("New", model);
            }

            var newGroup = await base.StudentGroupService.AddAsync(new StudentGroup
            {
                Name = model.Name
            });

            if (newGroup == null)
            {
                ModelState.AddModelError("form", "Не удалось сохранить новую группу.");
                return New(model);
            }

            return RedirectToAction("Index");
        }
	}
}