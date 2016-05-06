namespace GrSU.University.Domain.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Data;
    using Mapping;
    using Model;

    public class StudentService : DomainServiceAsync<Student, Data.Model.Student>, IStudentServiceAsync
    {
        public StudentService(IStudentRepository repository)
            : base(repository)
        {
        }

        public async Task<List<Student>> GetByGroupId(int groupId)
        {
            return (await base.Repository.GetAsync(s => s.GroupId == groupId))
                .Select(s => s.Map<Student>())
                .ToList();
        }
    }
}
