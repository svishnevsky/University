namespace GrSU.University.Data.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection;
    using Configurations.Common;

    public class DataContext : DbContext
    {
        private static readonly Type[] TypesToRegister = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => !string.IsNullOrEmpty(t.Namespace)
                    && t.BaseType != null
                    && t.BaseType.IsGenericType
                    && t.BaseType.GetGenericTypeDefinition() == typeof(BaseModelConfiguration<>))
                .ToArray();

        public DataContext()
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());
            Database.Initialize(false);
        }

        public DataContext(string connectionString) : base(connectionString)
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            foreach (var configurationInstance in TypesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic) configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
