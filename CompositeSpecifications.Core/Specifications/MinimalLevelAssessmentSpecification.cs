namespace CompositeSpecifications.Core.Specifications
{
    using CompositeSpecifications.Core.Entities;

    public class MinimalLevelAssessmentSpecification : Specification<Assessment>
    {
        private Level minimalLevel;

        public MinimalLevelAssessmentSpecification(Level minimalLevel)
        {
            this.minimalLevel = minimalLevel;
        }

        public override bool IsSatisfiedBy(Assessment assessment)
        {
            return assessment.Level >= this.minimalLevel;
        }
    }
}