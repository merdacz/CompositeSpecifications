namespace CompositeSpecifications.Core.Entities
{
    using System;

    public abstract class Entity 
    {
        public Guid? Id { get; protected set; }
    }
}