namespace CompositeSpecifications.Core.Repositories
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using CompositeSpecifications.Core.Entities;

    public abstract class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        private static IDictionary<Guid, T> storage = new Dictionary<Guid, T>();

        public static IQueryable<T> All
        {
            get { return storage.Values.AsQueryable(); }    
        }

        protected static IDictionary<Guid, T> Storage
        {
            get { return storage; }
        }

        public T Get(Guid id)
        {
            T result;
            storage.TryGetValue(id, out result);
            return result;
        }

        public Guid Save(T entity)
        {
            if (entity.Id == null)
            {
                var type = typeof(T);
                var field = type.GetField("Id", BindingFlags.NonPublic);
                Assume.That(() => field != null);
                field.SetValue(entity, Guid.NewGuid());
            }

            Assume.That(() => entity.Id.HasValue);
            storage.Add(entity.Id.Value, entity);
            return entity.Id.Value;
        }

        public void Delete(Guid id)
        {
            var syncRoot = ((ICollection)Storage).SyncRoot;
            lock (syncRoot)
            {
                if (storage.ContainsKey(id))
                {
                    storage.Remove(id);
                }
            }
        }
    }
}