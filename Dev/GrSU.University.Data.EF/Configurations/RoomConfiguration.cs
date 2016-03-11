using GrSU.University.Data.EF.Configurations.Common;
using GrSU.University.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.University.Data.EF.Configurations
{
    public class RoomConfiguration : BaseModelConfiguration<Room>
    {
        public RoomConfiguration()
        {
            Property(p => p.Number).HasMaxLength(50).IsRequired();

            Property(p => p.SitsCount).IsRequired();
        }
    }
}
