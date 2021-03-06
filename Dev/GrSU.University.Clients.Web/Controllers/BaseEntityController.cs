﻿using AutoMapper;

namespace GrSU.University.Clients.Web.Controllers
{
    using System.Data.Entity.Design.PluralizationServices;
    using System.Globalization;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Domain.Common;
    using Domain.Model.Common;
    using Resources;

    public abstract class BaseEntityController<TService, TEntity, TModel> : BaseDataController<TService, TEntity, TModel>
        where TEntity : BaseModel
        where TService : IDomainServiceAsync<TEntity>
        where TModel : class
    {

        private static readonly PluralizationService PluralizationService = PluralizationService.CreateService(new CultureInfo("en-US"));

        protected BaseEntityController(TService dataService, IMapper mapper)
            : base(dataService, mapper)
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
                return View("Update", PrepairModel(model));
            }

            var updatedEntity = await base.DataService.UpdateAsync(this.Map(model));

            if (updatedEntity == null)
            {
                ModelState.AddModelError("form", Errors.Update);
                return View("Update", PrepairModel(model));
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

        protected virtual TModel Map(TEntity entity)
        {
            return base.Mapper.Map<TEntity, TModel>(entity);
        }
    }
}