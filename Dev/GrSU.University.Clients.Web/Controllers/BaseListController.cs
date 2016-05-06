namespace GrSU.University.Clients.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Domain.Common;
    using Domain.Model;
    using Domain.Model.Common;
    using Models.StudentGroups;

    public abstract class BaseListController<TService, TEntity, TModel, TListModel> : BaseDataController<TService, TEntity, TModel>
        where TEntity : BaseModel
        where TService : IDomainServiceAsync<TEntity>
    {
        protected BaseListController(TService dataService) : base(dataService)
        {
        }

        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get()
        {
            var data = base.DataService.GetAsync()
                .Result
                .Select(MapListModel)
                .ToList();

            return View("Get", data);
        }

        [HttpGet]
        [ActionName("New")]
        public ActionResult New(TModel model)
        {
            return View("New", model);
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<ActionResult> SaveNew(TModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("New", model);
            }

            var newEntity = await base.DataService.AddAsync(this.Map(model));

            if (newEntity == null)
            {
                ModelState.AddModelError("form", "Не удалось сохранить новую запись.");
                return New(model);
            }

            return RedirectToAction("Index");
        }

        protected abstract TListModel MapListModel(TEntity entity);
    }
}