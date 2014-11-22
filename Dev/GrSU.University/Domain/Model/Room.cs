using GrSU.University.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.University.Model
{
    public class Room : BaseModel
    {
        public string Number { get; set; }

        public int SitsCount { get; set; }
    }
}
