using System.Collections.Generic;
using GrSU.University.Domain.Model;
using GrSU.University.Domain.Services.Static.Common;
using GrSU.University.Audit;

namespace GrSU.University.Domain.Services.Static
{
    public class StudentGroupService : DomainService<StudentGroup>, IStudentGroupService
    {
        private readonly List<StudentGroup> entities = new List<StudentGroup>();

        public StudentGroupService(IAuditManager auditManager) : base(auditManager)
        {

        }

        protected override List<StudentGroup> GetEntities()
        {
            return entities;
        }
    }
}
