namespace CompositeSpecifications.Core.Specifications
{
    using System.Collections.Generic;
    using CompositeSpecifications.Core.Entities;

    public abstract class CompositeSpecification<T> : Specification<T> where T : Entity
    {
        private IList<Specification<T>> components = new List<Specification<T>>();        

        protected IEnumerable<Specification<T>> Components
        {
            get
            {
                foreach (var component in this.components)
                {
                    yield return component;
                }
            }
        }

        public void AddComponent(Specification<T> component)
        {
            this.components.Add(component);
        }
    }
}