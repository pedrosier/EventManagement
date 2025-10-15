using System;
using EventManagement.Domain.Entities;
using Xunit;

namespace EventManagement.Domain.Tests
{
    public class EventSpecs
    {
        [Fact]
        public void Constructor_WithValidData_Succeeds()
        {
            var futureDate = DateTime.Now.AddDays(1);
            var evt = new Event(1, "Title", futureDate, TimeSpan.FromMinutes(30));
            Assert.Equal(1, evt.EventId);
            Assert.Equal("Title", evt.Title);
            Assert.Equal(futureDate, evt.EventDate);
            Assert.Equal(TimeSpan.FromMinutes(30), evt.Duration);
        }

        [Fact]
        public void Constructor_NegativeId_ThrowsException()
        {
            var futureDate = DateTime.Now.AddDays(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => new Event(-1, "Title", futureDate, TimeSpan.FromMinutes(30)));
        }

        [Fact]
        public void Constructor_ZeroId_ThrowsException()
        {
            var futureDate = DateTime.Now.AddDays(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => new Event(0, "Title", futureDate, TimeSpan.FromMinutes(30)));
        }

        [Fact]
        public void Constructor_NullTitle_ThrowsException()
        {
            var futureDate = DateTime.Now.AddDays(1);
            Assert.Throws<ArgumentException>(() => new Event(1, null!, futureDate, TimeSpan.FromMinutes(30)));
        }

        [Fact]
        public void Constructor_EmptyTitle_ThrowsException()
        {
            var futureDate = DateTime.Now.AddDays(1);
            Assert.Throws<ArgumentException>(() => new Event(1, "", futureDate, TimeSpan.FromMinutes(30)));
        }

        [Fact]
        public void Constructor_PastDate_ThrowsException()
        {
            var pastDate = DateTime.Now.AddDays(-1);
            Assert.Throws<ArgumentException>(() => new Event(1, "Title", pastDate, TimeSpan.FromMinutes(30)));
        }

        [Fact]
        public void Constructor_DurationLessThan30Min_ThrowsException()
        {
            var futureDate = DateTime.Now.AddDays(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => new Event(1, "Title", futureDate, TimeSpan.FromMinutes(29)));
        }

        [Fact]
        public void EventCode_InitializesEmpty()
        {
            var futureDate = DateTime.Now.AddDays(1);
            var evt = new Event(1, "Title", futureDate, TimeSpan.FromMinutes(30));
            Assert.Equal(string.Empty, evt.EventCode);
        }

        [Fact]
        public void SetEventCode_Valid_SetsTrimmed()
        {
            var futureDate = DateTime.Now.AddDays(1);
            var evt = new Event(1, "Title", futureDate, TimeSpan.FromMinutes(30));
            evt.SetEventCode(" Code ");
            Assert.Equal("Code", evt.EventCode);
        }

        [Fact]
        public void SetEventCode_Null_ThrowsException()
        {
            var futureDate = DateTime.Now.AddDays(1);
            var evt = new Event(1, "Title", futureDate, TimeSpan.FromMinutes(30));
            Assert.Throws<ArgumentNullException>(() => evt.SetEventCode(null!));
        }

        [Fact]
        public void SetDescription_Valid_SetsValue()
        {
            var futureDate = DateTime.Now.AddDays(1);
            var evt = new Event(1, "Title", futureDate, TimeSpan.FromMinutes(30));
            evt.SetDescription("Desc");
            Assert.Equal("Desc", evt.Description);
        }

        [Fact]
        public void SetDescription_Null_SetsNull()
        {
            var futureDate = DateTime.Now.AddDays(1);
            var evt = new Event(1, "Title", futureDate, TimeSpan.FromMinutes(30));
            evt.SetDescription(null);
            Assert.Null(evt.Description);
        }

        [Fact]
        public void Requirements_SetNull_ReturnsEmpty()
        {
            var futureDate = DateTime.Now.AddDays(1);
            var evt = new Event(1, "Title", futureDate, TimeSpan.FromMinutes(30));
            evt.Requirements = null;
            Assert.Equal(string.Empty, evt.Requirements);
        }

        [Fact]
        public void Notes_SetNull_ReturnsEmpty()
        {
            var futureDate = DateTime.Now.AddDays(1);
            var evt = new Event(1, "Title", futureDate, TimeSpan.FromMinutes(30));
            evt.Notes = null;
            Assert.Equal(string.Empty, evt.Notes);
        }

        [Fact]
        public void Venue_LazyLoading_LoadsDefault()
        {
            var futureDate = DateTime.Now.AddDays(1);
            var evt = new Event(1, "Title", futureDate, TimeSpan.FromMinutes(30));
            Assert.Equal(Venue.Default, evt.Venue);
        }

        [Fact]
        public void Venue_MultipleAccesses_SameInstance()
        {
            var futureDate = DateTime.Now.AddDays(1);
            var evt = new Event(1, "Title", futureDate, TimeSpan.FromMinutes(30));
            var v1 = evt.Venue;
            var v2 = evt.Venue;
            Assert.Same(v1, v2);
        }

        [Fact]
        public void AssignMainSpeaker_Valid_Assigns()
        {
            var futureDate = DateTime.Now.AddDays(1);
            var evt = new Event(1, "Title", futureDate, TimeSpan.FromMinutes(30));
            var speaker = new Speaker(1, "Name", "email@example.com");
            evt.AssignMainSpeaker(speaker);
            Assert.Equal(speaker, evt.MainSpeaker);
        }

        [Fact]
        public void AssignMainSpeaker_Null_ThrowsException()
        {
            var futureDate = DateTime.Now.AddDays(1);
            var evt = new Event(1, "Title", futureDate, TimeSpan.FromMinutes(30));
            Assert.Throws<ArgumentNullException>(() => evt.AssignMainSpeaker(null!));
        }

        [Fact]
        public void MainSpeaker_CanBeNull_Initially()
        {
            var futureDate = DateTime.Now.AddDays(1);
            var evt = new Event(1, "Title", futureDate, TimeSpan.FromMinutes(30));
            Assert.Null(evt.MainSpeaker);
        }

        [Fact]
        public void ToString_FormatsCorrectly()
        {
            var futureDate = DateTime.Now.AddDays(1);
            var evt = new Event(1, "Title", futureDate, TimeSpan.FromHours(1));
            evt.SetEventCode("Code");
            var expected = $"Event: Title (ID: 1, Date: {futureDate}, Duration: 01:00:00, Code: Code)";
            Assert.Equal(expected, evt.ToString());
        }
    }
}