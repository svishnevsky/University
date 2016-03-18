namespace GrSU.University.Data.Common
{
    using System.Threading.Tasks;

    using Model.Common;

    public interface IRepository<T> : IReadOnlyRepository<T> where T : BaseModel
    {
        Task<T> AddAsync(T entity);
        
        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(int id);
    }
}
