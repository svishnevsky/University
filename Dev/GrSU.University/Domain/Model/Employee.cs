using GrSU.University.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.University.Model
{
    public class Employee : BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }
    }
}
