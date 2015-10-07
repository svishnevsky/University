using System;

namespace GrSU.University.Domain.Model.Common
{
    public abstract class BaseModel : ICloneable
    {
        public int Id { get; set; }

        public abstract object Clone();

        public virtual void SetNullReferences()
        {
            
        }

        public abstract void Map(object objTo);
    }
}
