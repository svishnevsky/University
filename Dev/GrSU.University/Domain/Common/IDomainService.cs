using System.Collections.Generic;
using GrSU.University.Domain.Model.Common;

namespace GrSU.University.Domain.Common
{
    public interface IDomainService<T> where T : BaseModel
    {
        T Add(T entity);

        T Get(int id);

        List<T> Get();

        T Update(T entity);

        void Delete(int id);
    }
}
