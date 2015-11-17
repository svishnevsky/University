using System.Collections.Generic;
using System.Threading.Tasks;
using GrSU.University.Domain.Model.Common;

namespace GrSU.University.Domain.Common
{
    public interface IDomainServiceAsync<T> where T : BaseModel
    {
        Task<T> AddAsync(T entity);

        Task<T> GetAsync(int id);

        Task<List<T>> GetAsync();

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(int id);
    }
}
