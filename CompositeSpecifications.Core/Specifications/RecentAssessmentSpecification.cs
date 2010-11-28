namespace CompositeSpecifications.Core.Specifications
{
    using System;
    using CompositeSpecifications.Core.Entities;

    public class RecentAssessmentSpecification : Specification<Assessment>
    {
        public RecentAssessmentSpecification(TimeSpan threshold)
        {
            this.Threshold = threshold;
        }

        public TimeSpan Threshold { get; private set; }

        public override bool IsSatisfiedBy(Assessment assessment)
        {
            var currentTime = SystemTime.Now;

            return
                assessment.CreatedDate <= currentTime
                &&
                currentTime - assessment.CreatedDate <= this.Threshold;
        }
    }
}