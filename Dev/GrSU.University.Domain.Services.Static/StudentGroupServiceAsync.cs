using System.Collections.Generic;
using GrSU.University.Domain.Model;
using GrSU.University.Domain.Services.Static.Common;

namespace GrSU.University.Domain.Services.Static
{
    public class StudentGroupServiceAsync : DomainServiceAsync<StudentGroup>, IStudentGroupServiceAsync
    {
        private readonly List<StudentGroup> entities = new List<StudentGroup>();

        protected override List<StudentGroup> GetEntities()
        {
            return entities;
        }
    }
}
