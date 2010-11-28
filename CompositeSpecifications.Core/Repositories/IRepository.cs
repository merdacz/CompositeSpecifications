namespace CompositeSpecifications.Core.Repositories
{
    using System;

    public interface IRepository<T> 
    {
        T Get(Guid id);

        Guid Save(T entity);

        void Delete(Guid id);
    }
}
