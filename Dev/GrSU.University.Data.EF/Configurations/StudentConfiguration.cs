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
    public class StudentConfiguration : BaseModelConfiguration<Student>
    {
        public StudentConfiguration()
        {
            Property(p => p.FirstName).HasMaxLength(70).IsRequired();

            Property(p => p.LastName).HasMaxLength(70).IsRequired();

            Property(p => p.GroupId).IsRequired();

            HasRequired(m => m.Group).WithMany().HasForeignKey(m => m.GroupId);
        }
    }
}
