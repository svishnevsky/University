using GrSU.University.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.University.Data.EF.Configurations.Common
{
    public abstract class BaseModelConfiguration<T> : EntityTypeConfiguration<T> where T : BaseModel
    {
        public BaseModelConfiguration()
        {
            ToTable(GetTableName());

            HasKey(m => m.Id).Property(p => p.Id).HasColumnName(GetKeyName());
        }

        private string GetTableName()
        {
            var typeName = typeof(T).Name;

            //TODO: add all rules

            if (typeName.EndsWith("e"))
            {
                return string.Format("{0}s", typeName);
            }

            return string.Format("{0}es", typeName);
        }

        private string GetKeyName()
        {
            return string.Format("{0}Id", typeof(T).Name);
        }
    }
}
