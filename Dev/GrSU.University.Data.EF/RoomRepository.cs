using GrSU.University.Data.EF.Common;
using GrSU.University.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.University.Data.EF
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(DataContext context) : base(context)
        {

        }
    }
}
