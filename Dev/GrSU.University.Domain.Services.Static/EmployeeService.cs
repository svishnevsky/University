using System.Collections.Generic;
using GrSU.University.Domain.Model;
using GrSU.University.Domain.Services.Static.Common;
using GrSU.University.Audit;

namespace GrSU.University.Domain.Services.Static
{
    public class EmployeeService : DomainService<Employee>, IEmployeeService
    {
        private readonly List<Employee> entities = new List<Employee>();

        public EmployeeService(IAuditManager auditManager) : base(auditManager)
        {

        }

        protected override List<Employee> GetEntities()
        {
            return entities;
        }
    }
}
