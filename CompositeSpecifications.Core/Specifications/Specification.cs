namespace CompositeSpecifications.Core.Specifications
{
    using System;
    using CompositeSpecifications.Core.Entities;

    public abstract class Specification<T> : Specification where T : Entity
    {
        public override Type TargetObjectType
        {
            get { return typeof(T); }
        }

        public abstract bool IsSatisfiedBy(T entity);
    }

    public abstract class Specification : Entity
    {
        public abstract Type TargetObjectType { get; }
    }
}
