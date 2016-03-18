namespace GrSU.University.Domain.Model.Common
{
    using System;
    using System.Linq;
    using System.Reflection;

    public abstract class BaseModel : ICloneable
    {
        public int Id { get; set; }

        public virtual object Clone()
        {
            var type = this.GetType();
            var newObj = Activator.CreateInstance(type);

            Map(newObj);

            return newObj;
        }

        public virtual void SetNullReferences()
        {
            var type = this.GetType();
            var properies = type.GetProperties(BindingFlags.SetProperty & BindingFlags.GetProperty)
                .Where(p => p.PropertyType.IsSubclassOf(typeof(BaseModel)));

            foreach (var propInfo in properies)
            {
                propInfo.SetValue(this, null);
            }            
        }

        public virtual void Map(object objTo)
        {
            if (objTo == null)
            {
                throw new ArgumentNullException("objTo");
            }

            var type = this.GetType();
            
            if (type != objTo.GetType())
            {
                return;
            }

            var properies = type.GetProperties()
                .Where(p => p.CanRead && p.CanWrite);

            foreach (var propInfo in properies)
            {
                var propValue = propInfo.GetValue(this);
                propInfo.SetValue(objTo, propValue is ICloneable ? ((ICloneable)propValue).Clone() : propInfo.GetValue(this));
            }

            MapPrivate(objTo);
        }

        protected virtual void MapPrivate(object objTo)
        {

        }
    }
}
