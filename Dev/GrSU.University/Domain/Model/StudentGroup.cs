using GrSU.University.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.University.Model
{
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
