namespace GrSU.University.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Model.Common;

    public interface IReadOnlyRepository<T> where T : BaseModel
    {
        Task<T> GetAsync(int id);

        Task<List<T>> GetAsync(Expression<Func<T, bool>> filter = null);
    }
}
