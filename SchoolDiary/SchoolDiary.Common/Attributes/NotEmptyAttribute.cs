namespace SchoolDiary.Common.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using SchoolDiary.Common.Extensions;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class NotEmptyAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field must not be empty";
        
        public NotEmptyAttribute() : base(DefaultErrorMessage) { }
        
        public NotEmptyAttribute(string errorMessage) : base(errorMessage) { }

        public override bool IsValid(object value)
        {
            if (value is null)
            {
                return true;
            }

            switch (value)
            {
                case Guid guid:
                    return guid.IsEmpty();
                default:
                    return true;
            }
        }
    }
}
