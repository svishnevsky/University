using System;
using System.Collections.Generic;
using System.Linq;
using GrSU.University.Domain.Common;
using GrSU.University.Domain.Model.Common;

namespace GrSU.University.Domain.Services.Static.Common
{
    public abstract class DomainService<T> : IDomainService<T> where T : BaseModel
    {
        public virtual T Add(T entity)
        {
            var newEntity = (T)entity.Clone();
            newEntity.Id = !GetEntities().Any() ? 1 : GetEntities().Max(item => item.Id) + 1;

            newEntity.SetNullReferences();

            GetEntities().Add(newEntity);

            return (T)newEntity.Clone();
        }

        public virtual T Get(int id)
        {
            var entity = GetEntities().SingleOrDefault(item => item.Id == id);

            if (entity == null)
            {
                return null;
            }

            var entityClone = (T) entity.Clone();
            Resolve(ref entityClone);

            return entityClone;
        }

        public virtual List<T> Get()
        {
            return GetEntities()
                .Select(item =>
                {
                    var clone = (T)item.Clone();
                    Resolve(ref clone);
                    return clone;
                })
                .ToList();
        }

        public virtual T Update(T entity)
        {
            var existsEntity = GetEntities().SingleOrDefault(item => item.Id == entity.Id);
            if (existsEntity == null)
            {
                throw new NullReferenceException();
            }

            entity.Map(existsEntity);
            existsEntity.SetNullReferences();

            var clone = (T)existsEntity.Clone();
            Resolve(ref clone);

            return clone;
        }

        public virtual void Delete(int id)
        {
            var existsEntity = GetEntities().SingleOrDefault(item => item.Id == id);
            if (existsEntity == null)
            {
                throw new NullReferenceException();
            }

            GetEntities().Remove(existsEntity);
        }

        protected abstract List<T> GetEntities();

        protected virtual void Resolve(ref T entity)
        {
        }
    }
}
