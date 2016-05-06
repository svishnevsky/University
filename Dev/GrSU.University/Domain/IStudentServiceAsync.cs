using GrSU.University.Domain.Common;
using GrSU.University.Domain.Model;

namespace GrSU.University.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStudentServiceAsync : IDomainServiceAsync<Student>
    {
        Task<List<Student>> GetByGroupId(int groupId);
    }
}
