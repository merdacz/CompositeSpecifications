namespace CompositeSpecifications.Tests
{
    using System;
    using CompositeSpecifications.Core;
    using CompositeSpecifications.Core.Entities;
    using CompositeSpecifications.Core.Specifications;
    using NUnit.Framework;

    [TestFixture]
    public class AssessmentSpecificationTests
    {
        [Test]
        public void SimpleLevelSpecification()
        {
            var specification = new MinimalLevelAssessmentSpecification(Level.Medium);
            var easyAssessment = new Assessment(SystemTime.Now, Level.Easy);
            var mediumAssessment = new Assessment(SystemTime.Now, Level.Medium);
            var hardAssessment = new Assessment(SystemTime.Now, Level.Hard);

            Assert.IsFalse(specification.IsSatisfiedBy(easyAssessment));
            Assert.IsTrue(specification.IsSatisfiedBy(mediumAssessment));
            Assert.IsTrue(specification.IsSatisfiedBy(hardAssessment));
        }

        [Test]
        public void SimpleRecentSpecification()
        {
            var specification = new RecentAssessmentSpecification(TimeSpan.FromMinutes(10));
            var oldAssessment = new Assessment(new DateTime(2010, 1, 1, 10, 00, 00), Level.Easy);
            var newAssessment = new Assessment(new DateTime(2010, 1, 1, 10, 10, 00), Level.Easy);
            var newestAssessment = new Assessment(new DateTime(2010, 1, 1, 10, 20, 00), Level.Easy);
            var futureAssessment = new Assessment(new DateTime(2010, 1, 1, 10, 30, 00), Level.Easy);

            SystemTime.EvaluationFunction = () => new DateTime(2010, 1, 1, 10, 20, 00);

            Assert.IsFalse(specification.IsSatisfiedBy(oldAssessment));
            Assert.IsTrue(specification.IsSatisfiedBy(newAssessment));
            Assert.IsTrue(specification.IsSatisfiedBy(newestAssessment));
            Assert.IsFalse(specification.IsSatisfiedBy(futureAssessment));
        }

        [Test]
        public void CompositeLevelAndRecentSpecification()
        {
            var recentSpecification = new RecentAssessmentSpecification(TimeSpan.FromMinutes(10));
            var minimalLevelSpecification = new MinimalLevelAssessmentSpecification(Level.Medium);
            var specification = new ConjunctionSpecification<Assessment>();
            specification.AddComponent(recentSpecification);
            specification.AddComponent(minimalLevelSpecification);

            var oldAssessment = new Assessment(new DateTime(2010, 1, 1, 10, 00, 00), Level.Easy);
            var newAssessment = new Assessment(new DateTime(2010, 1, 1, 10, 10, 00), Level.Easy);
            var newestAssessment = new Assessment(new DateTime(2010, 1, 1, 10, 20, 00), Level.Hard);
            var futureAssessment = new Assessment(new DateTime(2010, 1, 1, 10, 30, 00), Level.Easy);

            SystemTime.EvaluationFunction = () => new DateTime(2010, 1, 1, 10, 20, 00);

            Assert.IsFalse(specification.IsSatisfiedBy(oldAssessment));
            Assert.IsFalse(specification.IsSatisfiedBy(newAssessment));
            Assert.IsTrue(specification.IsSatisfiedBy(newestAssessment));
            Assert.IsFalse(specification.IsSatisfiedBy(futureAssessment));
        }
    }
}
