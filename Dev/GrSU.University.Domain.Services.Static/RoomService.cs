using System.Collections.Generic;
using GrSU.University.Domain.Model;
using GrSU.University.Domain.Services.Static.Common;

namespace GrSU.University.Domain.Services.Static
{
    public class RoomService : DomainService<Room>, IRoomService
    {
        private readonly List<Room> entities = new List<Room>();
        
        protected override List<Room> GetEntities()
        {
            return entities;
        }
    }
}
