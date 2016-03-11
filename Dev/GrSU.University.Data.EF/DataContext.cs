using GrSU.University.Data.EF.Configurations;
using GrSU.University.Data.EF.Configurations.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.University.Data.EF
{
    public class DataContext : DbContext
    {
        private static Type[] typesToRegister = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => !string.IsNullOrEmpty(t.Namespace)
                    && t.BaseType != null
                    && t.BaseType.IsGenericType
                    && t.BaseType.GetGenericTypeDefinition() == typeof(BaseModelConfiguration<>))
                .ToArray();

        public DataContext()
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
