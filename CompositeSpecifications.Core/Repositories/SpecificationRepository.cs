namespace CompositeSpecifications.Core.Repositories
{
    using System;
    using CompositeSpecifications.Core.Entities;
    using CompositeSpecifications.Core.Specifications;

    public class SpecificationRepository : RepositoryBase<Specification>
    {
        public Specification<T> Get<T>(Guid id) where T : Entity
        {
            Specification untypedResult;
            Storage.TryGetValue(id, out untypedResult);
            var result = untypedResult as Specification<T>;
            if (result == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "Value found but it is of invalid type '{0}', ",
                        untypedResult.TargetObjectType.FullName));
            }

            return result;
        }
    }
}