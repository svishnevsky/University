using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.University.Audit.Services
{
    public class AuditManager : IAuditManager
    {
        public event DataAccessDelegate OnAccess;

        private List<string> history;

        public AuditManager()
        {
            this.history = new List<string>();
        }

        public void Access(Type dataType, AccessType accessType)
        {
            history.Add(string.Format("[{0}]\tDataType: {1}; AccessType: {2}.", DateTime.UtcNow, dataType.Name, accessType));

            if (OnAccess == null)
            {
                return;
            }

            this.OnAccess(this, new DataAccessEventArgs
                    {
                        AccessType = accessType,
                        DataType = dataType
                    });
        }

        public string[] GetHostory()
        {
            return this.history.ToArray();
        }
    }
}
