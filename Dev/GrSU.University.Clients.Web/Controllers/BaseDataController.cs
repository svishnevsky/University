﻿namespace GrSU.University.Clients.Web.Controllers
{
    using System.Web.Mvc;
    using Domain.Common;
    using Domain.Model.Common;

    public abstract class BaseDataController<TService, TEntity, TModel> : Controller
        where TEntity : BaseModel
        where TService : IDomainServiceAsync<TEntity>
        where TModel : class 
    {
        protected readonly TService DataService;

        protected BaseDataController(TService dataService)
        {
            this.DataService = dataService;
        }

        protected abstract TEntity Map(TModel model);

        protected virtual TModel PrepairModel(TModel model = null)
        {
            return model;
        }
    }
}