using System.Collections.Generic;
using GrSU.University.Domain.Model;
using GrSU.University.Domain.Services.Static.Common;
using GrSU.University.Audit;

namespace GrSU.University.Domain.Services.Static
{
    public class StudentService : DomainService<Student>, IStudentService
    {
        private readonly List<Student> entities = new List<Student>();

        private readonly IStudentGroupService studentGroupService;

        public StudentService(IStudentGroupService studentGroupService, IAuditManager auditManager) : base(auditManager)
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
