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
    public class StudentGroupConfiguration : BaseModelConfiguration<StudentGroup>
    {
        public StudentGroupConfiguration()
        {
            Property(p => p.Name).HasMaxLength(50).IsRequired();
        }
    }
}
