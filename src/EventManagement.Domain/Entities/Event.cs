using System;
using System.Diagnostics.CodeAnalysis;
using EventManagement.Domain.Guards;

namespace EventManagement.Domain.Entities
{
    public class Event
    {
        public int EventId { get; }
        public string Title { get; }
        private string _eventCode = string.Empty;
        [DisallowNull]
        public string EventCode
        {
            get => _eventCode;
            set
            {
                Guard.AgainstNull(value, nameof(EventCode));
                _eventCode = value.Trim();
            }
        }
        public DateTime EventDate { get; }
        public TimeSpan Duration { get; }
        public string? Description { get; private set; }

        private string? _requirements;
        [AllowNull]
        public string Requirements
        {
            get => _requirements ?? string.Empty;
            set => _requirements = value;
        }

        private string? _notes;
        [AllowNull]
        public string Notes
        {
            get => _notes ?? string.Empty;
            set => _notes = value;
        }

        private Venue? _venue;
        public Venue Venue
        {
            get
            {
                if (_venue is null)
                {
                    InitializeVenue();
                }
                return _venue;
            }
            set => _venue = value;
        }

        public Speaker? MainSpeaker { get; private set; }

        public Event(int eventId, string title, DateTime eventDate, TimeSpan duration)
        {
            Guard.AgainstNegativeOrZero(eventId, nameof(eventId));
            Guard.AgainstNullOrWhiteSpace(title, nameof(title));
            Guard.AgainstPastDate(eventDate, nameof(eventDate));
            if (duration < TimeSpan.FromMinutes(30))
                throw new ArgumentOutOfRangeException(nameof(duration), "Duration must be at least 30 minutes.");

            EventId = eventId;
            Title = title.Trim();
            EventDate = eventDate;
            Duration = duration;
        }

        public void SetEventCode(string code)
        {
            Guard.AgainstNull(code, nameof(code));
            EventCode = code.Trim();
        }

        public void SetDescription(string? description)
        {
            if (Guard.TryParseNonEmpty(description, out var parsed))
            {
                Description = parsed;
            }
            else
            {
                Description = null;
            }
        }

        public void AssignMainSpeaker(Speaker speaker)
        {
            Guard.AgainstNull(speaker, nameof(speaker));
            MainSpeaker = speaker;
        }

        [MemberNotNull(nameof(_venue))]
        private void InitializeVenue()
        {
            _venue = Venue.Default;
        }

        public override string ToString()
        {
            return $"Event: {Title} (ID: {EventId}, Date: {EventDate}, Duration: {Duration}, Code: {EventCode})";
        }
    }
}