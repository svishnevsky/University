﻿using AutoMapper;

namespace GrSU.University.Clients.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Domain.Common;
    using Domain.Model.Common;
    using Resources;

    public abstract class BaseListController<TService, TEntity, TModel, TListModel> : BaseDataController<TService, TEntity, TModel>
        where TEntity : BaseModel
        where TService : IDomainServiceAsync<TEntity>
        where TModel : class
    {
        protected BaseListController(TService dataService, IMapper mapper) : base(dataService, mapper)
        {
        }

        [HttpGet]
        [ActionName("Index")]
        public async Task<ActionResult> Get()
        {
            var data = (await base.DataService.GetAsync())
                .Select(MapListModel)
                .ToList();

            return View("Get", data);
        }

        [HttpGet]
        [ActionName("New")]
        public ActionResult New()
        {
            return View("New", PrepairModel());
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<ActionResult> SaveNew(TModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("New", PrepairModel(model));
            }

            var newEntity = await base.DataService.AddAsync(this.Map(model));

            if (newEntity == null)
            {
                ModelState.AddModelError("form", Errors.Create);
                return View("New", PrepairModel(model));
            }

            return RedirectToAction("Index");
        }

        protected virtual TListModel MapListModel(TEntity entity)
        {
            return base.Mapper.Map<TEntity, TListModel>(entity);
        }
    }
}