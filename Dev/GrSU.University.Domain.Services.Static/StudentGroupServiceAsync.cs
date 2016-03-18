using System.Collections.Generic;
using GrSU.University.Domain.Model;
using GrSU.University.Domain.Services.Static.Common;
using GrSU.University.Audit;

namespace GrSU.University.Domain.Services.Static
{
    public class StudentGroupServiceAsync : DomainServiceAsync<StudentGroup>, IStudentGroupServiceAsync
    {
        private readonly List<StudentGroup> entities = new List<StudentGroup>();

        public StudentGroupServiceAsync(IAuditManager auditManager) : base (auditManager)
        {

        }

        protected override List<StudentGroup> GetEntities()
        {
            return entities;
        }
    }
}
