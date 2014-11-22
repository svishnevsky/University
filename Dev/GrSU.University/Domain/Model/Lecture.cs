using GrSU.University.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.University.Model
{
    public class Lecture : BaseModel
    {
        public Employee Lector { get; set; }

        public StudentGroup Group { get; set; }

        public Room Room { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
