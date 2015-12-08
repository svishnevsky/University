using System.Collections.Generic;
using GrSU.University.Domain.Model;
using GrSU.University.Domain.Services.Static.Common;
using GrSU.University.Audit;

namespace GrSU.University.Domain.Services.Static
{
    public class RoomServiceAsync : DomainServiceAsync<Room>, IRoomServiceAsync
    {
        private readonly List<Room> entities = new List<Room>();

        public RoomServiceAsync(IAuditManager auditManager) : base (auditManager)
        {

        }
        
        protected override List<Room> GetEntities()
        {
            return entities;
        }
    }
}
