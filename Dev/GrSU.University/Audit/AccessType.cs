using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.University.Audit
{
    [Flags]
    public enum AccessType
    {
        Undefined = 0,
        Read = 1,
        Add = 2,
        Update = 3,
        Delete = 4,
        Write = (Add | Update | Delete)
    }
}
