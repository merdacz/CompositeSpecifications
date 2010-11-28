namespace CompositeSpecifications.Core.Specifications
{
    using CompositeSpecifications.Core.Entities;

    public class ConjunctionSpecification<T> : CompositeSpecification<T> where T : Entity
    {
        public override bool IsSatisfiedBy(T entity)
        {
            foreach (var component in this.Components)
            {
                if (!component.IsSatisfiedBy(entity))
                {
                    return false;
                }
            }

            return true;
        }
    }
}