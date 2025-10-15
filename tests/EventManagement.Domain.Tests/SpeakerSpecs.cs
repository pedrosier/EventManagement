using System;
using EventManagement.Domain.Entities;
using Xunit;

namespace EventManagement.Domain.Tests
{
    public class SpeakerSpecs
    {
        [Fact]
        public void Constructor_WithValidData_Succeeds()
        {
            var speaker = new Speaker(1, "Name", "email@example.com");
            Assert.Equal(1, speaker.SpeakerId);
            Assert.Equal("Name", speaker.FullName);
            Assert.Equal("email@example.com", speaker.Email);
        }

        [Fact]
        public void Constructor_NegativeId_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Speaker(-1, "Name", "email@example.com"));
        }

        [Fact]
        public void Constructor_ZeroId_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Speaker(0, "Name", "email@example.com"));
        }

        [Fact]
        public void Constructor_NullName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Speaker(1, null!, "email@example.com"));
        }

        [Fact]
        public void Constructor_EmptyName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Speaker(1, "", "email@example.com"));
        }

        [Fact]
        public void Constructor_WhitespaceName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Speaker(1, "   ", "email@example.com"));
        }

        [Fact]
        public void Constructor_NullEmail_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Speaker(1, "Name", null!));
        }

        [Fact]
        public void Constructor_InvalidEmail_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Speaker(1, "Name", "invalid"));
        }

        [Fact]
        public void SetBiography_Valid_SetsValue()
        {
            var speaker = new Speaker(1, "Name", "email@example.com");
            speaker.SetBiography("Bio");
            Assert.Equal("Bio", speaker.Biography);
        }

        [Fact]
        public void SetBiography_Null_SetsNull()
        {
            var speaker = new Speaker(1, "Name", "email@example.com");
            speaker.SetBiography(null);
            Assert.Null(speaker.Biography);
        }

        [Fact]
        public void SetBiography_Empty_SetsNull()
        {
            var speaker = new Speaker(1, "Name", "email@example.com");
            speaker.SetBiography("");
            Assert.Null(speaker.Biography);
        }

        [Fact]
        public void SetBiography_Whitespace_SetsNull()
        {
            var speaker = new Speaker(1, "Name", "email@example.com");
            speaker.SetBiography("   ");
            Assert.Null(speaker.Biography);
        }

        [Fact]
        public void Company_SetNull_ReturnsEmpty()
        {
            var speaker = new Speaker(1, "Name", "email@example.com");
            speaker.Company = null;
            Assert.Equal(string.Empty, speaker.Company);
        }

        [Fact]
        public void LinkedInProfile_SetNull_ReturnsEmpty()
        {
            var speaker = new Speaker(1, "Name", "email@example.com");
            speaker.LinkedInProfile = null;
            Assert.Equal(string.Empty, speaker.LinkedInProfile);
        }

        [Fact]
        public void Equals_SameId_True()
        {
            var s1 = new Speaker(1, "Name1", "email1@example.com");
            var s2 = new Speaker(1, "Name2", "email2@example.com");
            Assert.Equal(s1, s2);
        }

        [Fact]
        public void Equals_DifferentId_False()
        {
            var s1 = new Speaker(1, "Name", "email@example.com");
            var s2 = new Speaker(2, "Name", "email@example.com");
            Assert.NotEqual(s1, s2);
        }

        [Fact]
        public void GetHashCode_SameId_SameHash()
        {
            var s1 = new Speaker(1, "Name1", "email1@example.com");
            var s2 = new Speaker(1, "Name2", "email2@example.com");
            Assert.Equal(s1.GetHashCode(), s2.GetHashCode());
        }

        [Fact]
        public void ToString_FormatsCorrectly()
        {
            var speaker = new Speaker(1, "Name", "email@example.com");
            Assert.Equal("Speaker: Name (ID: 1, Email: email@example.com)", speaker.ToString());
        }
    }
}