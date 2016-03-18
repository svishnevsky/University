namespace GrSU.University.Data.EF.Common
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Common;
    using Model.Common;

    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : BaseModel
    {
        protected readonly DataContext Context;

        protected DbSet<T> Set
        {
            get { return this.Context.Set<T>(); }
        }

        public ReadOnlyRepository(DataContext context)
        {
            this.Context = context;
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
