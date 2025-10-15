using System;
using System.Diagnostics.CodeAnalysis;
using EventManagement.Domain.Guards;

namespace EventManagement.Domain.Entities
{
    public class Speaker
    {
        public int SpeakerId { get; }
        public string FullName { get; }
        public string Email { get; }
        public string? Biography { get; private set; }

        private string? _company;
        [AllowNull]
        public string Company
        {
            get => _company ?? string.Empty;
            set => _company = value;
        }

        private string? _linkedInProfile;
        [AllowNull]
        public string LinkedInProfile
        {
            get => _linkedInProfile ?? string.Empty;
            set => _linkedInProfile = value;
        }

        public Speaker(int speakerId, string fullName, string email)
        {
            Guard.AgainstNegativeOrZero(speakerId, nameof(speakerId));
            Guard.AgainstNullOrWhiteSpace(fullName, nameof(fullName));
            Guard.AgainstNullOrWhiteSpace(email, nameof(email));
            if (!Guard.IsValidEmail(email))
                throw new ArgumentException("Invalid email format.", nameof(email));

            SpeakerId = speakerId;
            FullName = fullName.Trim();
            Email = email.Trim();
        }

        public void SetBiography(string? biography)
        {
            if (Guard.TryParseNonEmpty(biography, out var parsed))
            {
                Biography = parsed;
            }
            else
            {
                Biography = null;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Speaker other && SpeakerId == other.SpeakerId;
        }

        public override int GetHashCode()
        {
            return SpeakerId.GetHashCode();
        }

        public override string ToString()
        {
            return $"Speaker: {FullName} (ID: {SpeakerId}, Email: {Email})";
        }
    }
}