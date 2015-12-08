using System.Collections.Generic;
using GrSU.University.Domain.Model;
using GrSU.University.Domain.Services.Static.Common;
using GrSU.University.Audit;

namespace GrSU.University.Domain.Services.Static
{
    public class RoomService : DomainService<Room>, IRoomService
    {
        private readonly List<Room> entities = new List<Room>();

        public RoomService(IAuditManager auditManager) : base(auditManager)
        {

        }
        
        protected override List<Room> GetEntities()
        {
            return entities;
        }
    }
}
