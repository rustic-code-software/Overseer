using FluentAssertions;

namespace Overseer.Abstractions.Tests
{
    public class UnitTests
    {
        [Fact]
        public void Value_EqualsItself()
        {
            var u1 = Unit.Value;
            var u2 = Unit.Value;

            u1.Equals(u2).Should().BeTrue();
            (u1 == u2).Should().BeTrue();
            u1.GetHashCode().Should().Be(u2.GetHashCode());
        }

        [Fact]
        public void NewUnit_EqualsValue()
        {
            var u1 = new Unit();
            var u2 = Unit.Value;

            u1.Equals(u2).Should().BeTrue();
            (u1 == u2).Should().BeTrue();
        }

        [Fact]
        public void ToString_ReturnsParens()
        {
            Unit.Value.ToString().Should().Be("()");
        }

        [Fact]
        public void Equals_ObjectNull_IsFalse()
        {
            object? nothing = null;
            Unit.Value.Equals(nothing).Should().BeFalse();
        }
    }
}
