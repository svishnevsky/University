using GrSU.University.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.University.Data.Common
{
    public interface IReadOnlyRepository<T> where T : BaseModel
    {
        Task<T> GetAsync(int id);

        Task<List<T>> GetAsync();
    }
}
