namespace SchoolDiary.Common.Extensions
{
    using System;

    public static class GuidExtensions
    {
        public static bool IsEmpty(this Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
