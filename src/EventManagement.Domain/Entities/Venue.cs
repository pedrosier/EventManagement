using System;
using System.Diagnostics.CodeAnalysis;
using EventManagement.Domain.Guards;

namespace EventManagement.Domain.Entities
{
    public class Venue
    {
        public int VenueId { get; }
        public string Name { get; }
        public string Address { get; }
        public int Capacity { get; }
        public string? Description { get; private set; }

        private string? _parkingInfo;
        [AllowNull]
        public string ParkingInfo
        {
            get => _parkingInfo ?? string.Empty;
            set => _parkingInfo = value;
        }

        public static Venue Default { get; } = new Venue(9999999, "Online Event", "Virtual", 999);

        public Venue(int venueId, string name, string address, int capacity)
        {
            Guard.AgainstNegativeOrZero(venueId, nameof(venueId));
            Guard.AgainstNullOrWhiteSpace(name, nameof(name));
            Guard.AgainstNullOrWhiteSpace(address, nameof(address));
            Guard.AgainstNegativeOrZero(capacity, nameof(capacity));

            VenueId = venueId;
            Name = name.Trim();
            Address = address.Trim();
            Capacity = capacity;
        }

        // Private constructor for Default
        // private Venue(int venueId, string name, string address, int capacity)
        // {
        //     VenueId = venueId;
        //     Name = name;
        //     Address = address;
        //     Capacity = capacity;
        // }

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

        public override bool Equals(object? obj)
        {
            return obj is Venue other && VenueId == other.VenueId;
        }

        public override int GetHashCode()
        {
            return VenueId.GetHashCode();
        }

        public override string ToString()
        {
            return $"Venue: {Name} (ID: {VenueId}, Address: {Address}, Capacity: {Capacity})";
        }
    }
}