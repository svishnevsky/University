using System;
using System.Collections.Generic;
using System.Linq;
using GrSU.University.Domain.Model;

namespace GrSU.University.Domain.Services.Static
{
    public class StudentService
    {
        private static List<Student> students = new List<Student>();

        private readonly StudentGroupService studentGroupService;

        public StudentService(StudentGroupService studentGroupService)
        {
            this.studentGroupService = studentGroupService;
        }

        public Student Get(int id)
        {
            var student = students.SingleOrDefault(item => item.Id == id);
            if (student == null)
            {
                return null;
            }

            student.Group = studentGroupService.Get(student.StudentGroupId);
            return student;
        }

        public List<Student> Get()
        {
            var studentList = students;
            studentList = studentList.Select(item =>
                                             {
                                                 item.Group = studentGroupService.Get(item.StudentGroupId);
                                                 return item;
                                             })
                                             .ToList();

            return studentList;
        }

        public Student Add(Student student)
        {
            student.Id = students.Any() ? students.Max(item => item.Id) + 1 : 1;
            students.Add(student);
            return student;
        }

        public Student Update(Student student)
        {
            var existsStudent = this.Get(student.Id);
            if (existsStudent == null)
            {
                throw new NullReferenceException();
            }

            existsStudent.FirstName = student.FirstName;
            existsStudent.LastName = student.LastName;

            if (studentGroupService.Get(student.StudentGroupId) == null)
            {
                throw  new NullReferenceException(string.Format("Group [Id:{0}] not found.", student.StudentGroupId));
            }

            existsStudent.StudentGroupId = student.StudentGroupId;

            return student;
        }

        public void Delete(int id)
        {
            var student = this.Get(id);
            if (student == null)
            {
                throw new NullReferenceException();
            }

            students.Remove(student);
        }
    }
}
