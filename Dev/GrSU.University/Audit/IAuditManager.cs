using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.University.Audit
{
    public delegate void DataAccessDelegate(object sender, DataAccessEventArgs eventArgs);

    public interface IAuditManager
    {
        event DataAccessDelegate OnAccess;

        void Access();
    }
}
