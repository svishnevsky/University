using GrSU.University.Data.Common;
using GrSU.University.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.University.Data.EF.Common
{
    public class Repository<T> : ReadOnlyRepository<T>, IRepository<T> where T : BaseModel
    {
        public Repository(DataContext context) : base(context)
        {

        }

        public virtual Task<T> AddAsync(T entity)
        {
            return Task.Factory.StartNew(() => base.Set.Add(entity));
        }

        public virtual Task<T> UpdateAsync(T entity)
        {
            return Task.Factory.StartNew(() =>
            {
                if (context.Entry(entity).State != System.Data.Entity.EntityState.Added)
                {
                    base.Set.Attach(entity);
                    base.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                }

                return entity;
            });
        }

        public virtual Task DeleteAsync(int id)
        {
            return Task.Factory.StartNew(() => base.Set.Remove(base.GetAsync(id).Result));
        }
    }
}
