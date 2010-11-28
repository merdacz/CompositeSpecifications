namespace CompositeSpecifications.Core
{
    using System;

    public static class SystemTime
    {
        private static readonly Func<DateTime> DefaultEvaluationFunction = () => DateTime.Now;

        static SystemTime()
        {
            EvaluationFunction = DefaultEvaluationFunction;
        }

        public static DateTime Now
        {
            get { return EvaluationFunction(); }
        }

        public static Func<DateTime> EvaluationFunction
        {
            get;
            set;
        }
    }
}
