namespace GrSU.University.Data.EF.Configurations.Common
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Design.PluralizationServices;
    using System.Data.Entity.ModelConfiguration;
    using System.Globalization;
    using Model.Common;

    public abstract class BaseModelConfiguration<T> : EntityTypeConfiguration<T> where T : BaseModel
    {
        private static readonly PluralizationService PluralizationService =
            PluralizationService.CreateService(new CultureInfo("en-US"));

        protected BaseModelConfiguration()
        {
            ToTable(GetTableName());

            HasKey(m => m.Id).Property(p => p.Id).HasColumnName(GetKeyName()).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        private string GetTableName()
        {
            var typeName = typeof(T).Name;

            return PluralizationService.Pluralize(typeName);
        }

        private string GetKeyName()
        {
            return string.Format("{0}Id", typeof(T).Name);
        }
    }
}
