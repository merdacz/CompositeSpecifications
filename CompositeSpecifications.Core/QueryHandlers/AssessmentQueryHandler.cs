namespace CompositeSpecifications.Core.QueryHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using CompositeSpecifications.Core.Entities;
    using CompositeSpecifications.Core.Repositories;
    using CompositeSpecifications.Core.Specifications;

    public class AssessmentQueryHandler
    {
        public ICollection<Assessment> GetMatching(Specification<Assessment> specification)
        {
            return AssessmentRepository.All.Where(assessment => specification.IsSatisfiedBy(assessment)).ToList();
        }
    }
}
