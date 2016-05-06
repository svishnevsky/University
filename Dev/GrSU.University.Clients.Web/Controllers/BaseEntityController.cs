namespace GrSU.University.Clients.Web.Controllers
{
    using System.Data.Entity.Design.PluralizationServices;
    using System.Globalization;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Domain.Common;
    using Domain.Model.Common;

    public abstract class BaseEntityController<TService, TEntity, TModel> : BaseDataController<TService, TEntity, TModel>
        where TEntity : BaseModel
        where TService : IDomainServiceAsync<TEntity>
    {

        private static readonly PluralizationService PluralizationService = PluralizationService.CreateService(new CultureInfo("en-US"));

        protected BaseEntityController(TService dataService)
            : base(dataService)
        {
            this.listControllerName = PluralizationService.Pluralize(typeof (TEntity).Name);
        }

        private readonly string listControllerName;

        [HttpGet]
        [ActionName("Index")]
        public async Task<ActionResult> Get(int id)
        {
            var entity = await base.DataService.GetAsync(id);

            if (entity == null)
            {
                return HttpNotFound();
            }

            var model = this.Map(entity);

            return View("Update", model);
        }

        [HttpPut]
        [ActionName("Index")]
        public async Task<ActionResult> Update(TModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }

            var updatedEntity = await base.DataService.UpdateAsync(this.Map(model));

            if (updatedEntity == null)
            {
                ModelState.AddModelError("form", "Не удалось сохранить изменения.");
                return View("Update", model);
            }

            return RedirectToAction("Index", this.listControllerName);
        }
        
        [HttpDelete]
        [ActionName("Index")]
        public async Task<ActionResult> Delete(int id)
        {
            await base.DataService.DeleteAsync(id);
            return RedirectToAction("Index", this.listControllerName);
        }

        protected abstract TModel Map(TEntity entity);
    }
}