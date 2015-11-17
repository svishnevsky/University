using System.Collections.Generic;
using GrSU.University.Domain.Model;
using GrSU.University.Domain.Services.Static.Common;

namespace GrSU.University.Domain.Services.Static
{
    public class StudentService : DomainService<Student>, IStudentService
    {
        private readonly List<Student> entities = new List<Student>();

        private readonly IStudentGroupService studentGroupService;

        public StudentService(IStudentGroupService studentGroupService)
        {
            this.studentGroupService = studentGroupService;
        }

        protected override List<Student> GetEntities()
        {
            return entities;
        }

        protected override void Resolve(ref Student entity)
        {
            base.Resolve(ref entity);
            entity.Group = entity.GroupId <= 0 ? null : studentGroupService.Get(entity.GroupId);
        }
    }
}
