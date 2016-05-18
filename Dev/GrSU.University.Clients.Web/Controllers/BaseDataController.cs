using AutoMapper;

namespace GrSU.University.Clients.Web.Controllers
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

        protected readonly IMapper Mapper;

        protected BaseDataController(TService dataService, IMapper mapper)
        {
            this.DataService = dataService;
            this.Mapper = mapper;
        }

        protected virtual TEntity Map(TModel model)
        {
            return this.Mapper.Map<TModel, TEntity>(model);
        }

        protected virtual TModel PrepairModel(TModel model = null)
        {
            return model;
        }
    }
}