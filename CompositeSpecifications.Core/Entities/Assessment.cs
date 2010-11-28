namespace CompositeSpecifications.Core.Entities
{
    using System;

    public class Assessment : Entity
    {
        public Assessment(DateTime createdDate, Level level)
        {
            this.CreatedDate = createdDate;
            this.Level = level;
        }

        public DateTime CreatedDate { get; private set; }

        public Level Level { get; private set; }
    }
}