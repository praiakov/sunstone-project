using System;

namespace SunstoneProject.Application.Common
{
    public static class ValidationExtensions
    {
        public static bool IsNotEmptyOrNull(this string value) => !string.IsNullOrWhiteSpace(value);

        public static bool IsValidGuid(this Guid guid) => guid != Guid.Empty;

        public static bool IsGreaterThan(this string value, int length) => !string.IsNullOrWhiteSpace(value) && value.Length > length;
    }
}
