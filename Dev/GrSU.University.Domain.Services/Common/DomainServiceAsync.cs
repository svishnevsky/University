namespace GrSU.University.Domain.Services.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Common;
    using Domain.Common;
    using Mapping;
    using Model.Common;

    public abstract class DomainServiceAsync<TModel, TEntity> : IDomainServiceAsync<TModel> where TModel : BaseModel where TEntity : Data.Model.Common.BaseModel
    {
        protected readonly IRepository<TEntity> Repository;

        protected DomainServiceAsync(IRepository<TEntity> repository)
        {
            this.Repository = repository;
        }

        public async Task<TModel> AddAsync(TModel model)
        {
            var entity = model.Map<TEntity>();
            entity = await this.Repository.AddAsync(entity);
            return entity.Map<TModel>();
        }

        public async Task<TModel> GetAsync(int id)
        {
            var entity = await this.Repository.GetAsync(id);
            return entity.Map<TModel>();
        }

        public async Task<List<TModel>> GetAsync()
        {
            var entities = await this.Repository.GetAsync();
            return entities.Select(e => e.Map<TModel>()).ToList();
        }

        public async Task<TModel> UpdateAsync(TModel model)
        {
            var entity = model.Map<TEntity>();
            entity = await this.Repository.UpdateAsync(entity);
            return entity.Map<TModel>();
        }

        public async Task DeleteAsync(int id)
        {
            await this.Repository.DeleteAsync(id);
        }
    }
}
