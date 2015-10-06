using System;
using System.Collections.Generic;
using System.Linq;
using GrSU.University.Domain.Model;

namespace GrSU.University.Domain.Services.Static
{
    public class StudentGroupService
    {
        private static List<StudentGroup> studentGroups = new List<StudentGroup>(); 

        public StudentGroup Get(int id)
        {
            return studentGroups.SingleOrDefault(item => item.Id == id);
        }

        public List<StudentGroup> Get()
        {
            return studentGroups;
        }

        public StudentGroup Add(StudentGroup studentGroup)
        {
            studentGroup.Id = studentGroups.Any() ? studentGroups.Max(item => item.Id) + 1 : 1;
            studentGroups.Add(studentGroup);
            return studentGroup;
        }

        public StudentGroup Update(StudentGroup studentGroup)
        {
            var group = this.Get(studentGroup.Id);
            if (group == null)
            {
                throw new NullReferenceException();
            }

            group.Name = studentGroup.Name;

            return group;
        }

        public void Delete(int id)
        {
            var group = this.Get(id);
            if (group == null)
            {
                throw new NullReferenceException();
            }

            studentGroups.Remove(group);
        }
    }
}
