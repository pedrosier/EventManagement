using System;
using EventManagement.Domain.Entities;
using Xunit;

namespace EventManagement.Domain.Tests
{
    public class VenueSpecs
    {
        [Fact]
        public void Constructor_WithValidData_Succeeds()
        {
            var venue = new Venue(1, "Name", "Address", 100);
            Assert.Equal(1, venue.VenueId);
            Assert.Equal("Name", venue.Name);
            Assert.Equal("Address", venue.Address);
            Assert.Equal(100, venue.Capacity);
        }

        [Fact]
        public void Constructor_NegativeId_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Venue(-1, "Name", "Address", 100));
        }

        [Fact]
        public void Constructor_ZeroId_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Venue(0, "Name", "Address", 100));
        }

        [Fact]
        public void Constructor_NullName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Venue(1, null!, "Address", 100));
        }

        [Fact]
        public void Constructor_EmptyName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Venue(1, "", "Address", 100));
        }

        [Fact]
        public void Constructor_NullAddress_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Venue(1, "Name", null!, 100));
        }

        [Fact]
        public void Constructor_EmptyAddress_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Venue(1, "Name", "", 100));
        }

        [Fact]
        public void Constructor_WhitespaceAddress_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Venue(1, "Name", "   ", 100));
        }

        [Fact]
        public void Constructor_ZeroCapacity_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Venue(1, "Name", "Address", 0));
        }

        [Fact]
        public void Constructor_NegativeCapacity_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Venue(1, "Name", "Address", -1));
        }

        [Fact]
        public void SetDescription_Valid_SetsValue()
        {
            var venue = new Venue(1, "Name", "Address", 100);
            venue.SetDescription("Desc");
            Assert.Equal("Desc", venue.Description);
        }

        [Fact]
        public void SetDescription_Null_SetsNull()
        {
            var venue = new Venue(1, "Name", "Address", 100);
            venue.SetDescription(null);
            Assert.Null(venue.Description);
        }

        [Fact]
        public void SetDescription_Empty_SetsNull()
        {
            var venue = new Venue(1, "Name", "Address", 100);
            venue.SetDescription("");
            Assert.Null(venue.Description);
        }

        [Fact]
        public void ParkingInfo_SetNull_ReturnsEmpty()
        {
            var venue = new Venue(1, "Name", "Address", 100);
            venue.ParkingInfo = null;
            Assert.Equal(string.Empty, venue.ParkingInfo);
        }

        [Fact]
        public void Default_Property_Works()
        {
            Assert.Equal("Online Event", Venue.Default.Name);
        }

        [Fact]
        public void Equals_SameId_True()
        {
            var v1 = new Venue(1, "Name1", "Addr1", 100);
            var v2 = new Venue(1, "Name2", "Addr2", 200);
            Assert.Equal(v1, v2);
        }

        [Fact]
        public void Equals_DifferentId_False()
        {
            var v1 = new Venue(1, "Name", "Addr", 100);
            var v2 = new Venue(2, "Name", "Addr", 100);
            Assert.NotEqual(v1, v2);
        }

        [Fact]
        public void GetHashCode_SameId_SameHash()
        {
            var v1 = new Venue(1, "Name1", "Addr1", 100);
            var v2 = new Venue(1, "Name2", "Addr2", 200);
            Assert.Equal(v1.GetHashCode(), v2.GetHashCode());
        }
    }
}