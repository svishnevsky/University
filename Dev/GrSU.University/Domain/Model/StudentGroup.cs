namespace GrSU.University.Domain.Model
{
    using System.Collections.Generic;
    using Common;

    public class StudentGroup : BaseModel
    {
        public string Name { get; set; }

        public List<Student> StudentList { get; set; }

        public StudentGroup()
        {
            this.StudentList = new List<Student>();
        }
    }
}
