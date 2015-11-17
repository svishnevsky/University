using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrSU.University.Domain.Common;
using GrSU.University.Domain.Model.Common;

namespace GrSU.University.Domain.Services.Static.Common
{
    public abstract class DomainServiceAsync<T> : DomainService<T>, IDomainServiceAsync<T> where T : BaseModel
    {
        private readonly int delay;

        public DomainServiceAsync() : this(5000)
        {

        }

        public DomainServiceAsync(int delay)
        {
            this.delay = delay;
        }

        public async Task<T> AddAsync(T entity)
        {
            await Task.Delay(delay);

            return base.Add(entity);
        }

        public async Task<T> GetAsync(int id)
        {
            await Task.Delay(delay);

            return base.Get(id);
        }

        public async Task<List<T>> GetAsync()
        {
            await Task.Delay(delay);

            return base.Get();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Delay(delay);

            return base.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Delay(delay);

            base.Delete(id);
        }
    }
}
