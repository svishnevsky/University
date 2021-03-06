﻿using System.Collections.Generic;
using GrSU.University.Domain.Model;
using GrSU.University.Domain.Services.Static.Common;
using GrSU.University.Audit;

namespace GrSU.University.Domain.Services.Static
{
    using System.Threading.Tasks;

    public class StudentServiceAsync : DomainServiceAsync<Student>, IStudentServiceAsync
    {
        private readonly List<Student> entities = new List<Student>();

        private readonly IStudentGroupServiceAsync studentGroupService;

        public StudentServiceAsync(IStudentGroupServiceAsync studentGroupService, IAuditManager auditManager) : base (auditManager)
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
            entity.Group = entity.GroupId <= 0 ? null : studentGroupService.GetAsync(entity.GroupId).Result;
        }

        public Task<List<Student>> GetByGroupId(int groupId)
        {
            throw new System.NotImplementedException();
        }
    }
}
