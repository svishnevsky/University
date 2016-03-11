using GrSU.University.Data.Common;
using GrSU.University.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.University.Data.EF.Common
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : BaseModel
    {
        protected readonly DataContext context;

        protected DbSet<T> Set
        {
            get { return this.context.Set<T>(); }
        }

        public ReadOnlyRepository(DataContext context)
        {
            this.context = context;
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await Task.FromResult(this.Set.FirstOrDefault(e => e.Id == id));
        }

        public virtual async Task<List<T>> GetAsync()
        {
            return await Task.FromResult(this.Set.ToList());
        }
    }
}
