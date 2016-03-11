using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrSU.University.Domain.Common;
using GrSU.University.Domain.Model.Common;
using GrSU.University.Data.Common;

namespace GrSU.University.Domain.Services.Common
{
    public abstract class DomainServiceAsync<T> : IDomainServiceAsync<T> where T : BaseModel
    {
        private readonly IRepository<T> repository;

        public DomainServiceAsync(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public async Task<T> AddAsync(T entity)
        {
            return await this.repository.AddAsync(entity);
        }

        public async Task<T> GetAsync(int id)
        {
            return await this.repository.GetAsync(id);
        }

        public async Task<List<T>> GetAsync()
        {
            return await this.repository.GetAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await this.repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await this.repository.DeleteAsync(id);
        }
    }
}
