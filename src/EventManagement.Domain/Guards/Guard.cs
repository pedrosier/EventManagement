using System;
using System.Diagnostics.CodeAnalysis;

namespace EventManagement.Domain.Guards
{
    public static class Guard
    {
        public static void AgainstNull([NotNull] object? value, string paramName)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }

        public static void AgainstNullOrWhiteSpace([NotNull] string? value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{paramName} cannot be null or whitespace.", paramName);
        }

        public static void AgainstNegativeOrZero(int value, string paramName)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(paramName, $"{paramName} must be greater than zero.");
        }

        public static void AgainstPastDate(DateTime date, string paramName)
        {
            if (date < DateTime.Now)
                throw new ArgumentException($"{paramName} cannot be in the past.", paramName);
        }

        public static bool IsValidEmail(string? email)
        {
            return !string.IsNullOrWhiteSpace(email) && email.Contains('@');
        }

        public static bool TryParseNonEmpty(string? input, [NotNullWhen(true)] out string? result)
        {
            result = input?.Trim();
            return !string.IsNullOrEmpty(result);
        }
    }
}