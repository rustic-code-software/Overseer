
using FluentAssertions;
using Xunit;

namespace Overseer.Abstractions.Tests
{
    public class OptionTests
    {
        [Fact]
        public void Some_HasValueAndValue()
        {
            var opt = Option.Some("test");

            opt.Should().NotBeNull();
            opt.HasValue.Should().BeTrue();
            opt.Value.Should().Be("test");
        }

        [Fact]
        public void Some_Equals_SameValue()
        {
            var a = Option.Some("x");
            var b = Option.Some("x");

            a.Equals(b).Should().BeTrue();
            (a == b).Should().BeTrue();
            a.GetHashCode().Should().Be(b.GetHashCode());
        }

        [Fact]
        public void Some_NotEquals_DifferentValue()
        {
            var a = Option.Some("x");
            var b = Option.Some("y");

            a.Equals(b).Should().BeFalse();
            (a == b).Should().BeFalse();
            (a != b).Should().BeTrue();
        }

        [Fact]
        public void None_Equals_None()
        {
            var a = Option.None<string>();
            var b = Option.None<string>();

            a.Equals(b).Should().BeTrue();
            (a == b).Should().BeTrue();
            a.GetHashCode().Should().Be(b.GetHashCode());
        }

        [Fact]
        public void None_Equals_Some()
        {
            var a = Option.None<string>();
            var b = Option.Some("x");

            a.Equals(b).Should().BeFalse();
            (a == b).Should().BeFalse();
            (a != b).Should().BeTrue();
        }

        [Fact]
        public void Some_NotEquals_None()
        {
            var some = Option.Some("x");
            var none = Option.None<string>();

            some.Equals(none).Should().BeFalse();
            (some == none).Should().BeFalse();
            (some != none).Should().BeTrue();
        }

        [Fact]
        public void Equals_Null_ReturnsFalse()
        {
            var some = Option.Some(1);
            var none = Option.None<int>();

            some.Equals(null).Should().BeFalse();
            none.Equals(null).Should().BeFalse();
        }

        [Fact]
        public void None_HasNoValue()
        {
            var opt = Option.None<string>();

            opt.Should().NotBeNull();
            opt.HasValue.Should().BeFalse();
            opt.Value.Should().Be(default(string));
        }

        [Fact]
        public void Map_Some_TransformsValue()
        {
            var opt = Option.Some(2);

            var mapped = opt.Map(x => x * 3);

            mapped.Should().NotBeNull();
            mapped.HasValue.Should().BeTrue();
            mapped.Value.Should().Be(6);
        }

        [Fact]
        public void Map_None_RemainsNone()
        {
            var opt = Option.None<int>();

            var mapped = opt.Map(x => x * 3);

            mapped.Should().NotBeNull();
            mapped.HasValue.Should().BeFalse();
            mapped.Value.Should().Be(default(int));
        }

        [Fact]
        public void Match_Function_ReturnsCorrect()
        {
            var some = Option.Some("yes");

            var res1 = some.Match(s => s.Length, () => 0);
            res1.Should().Be(3);

            var none = Option.None<string>();
            var res2 = none.Match(s => s.Length, () => -1);
            res2.Should().Be(-1);
        }

        [Fact]
        public void Match_Action_ExecutesCorrectAction()
        {
            var someCalled = 0;
            var noneCalled = 0;

            var some = Option.Some(5);
            some.Match(v => someCalled++, () => noneCalled++);

            someCalled.Should().Be(1);
            noneCalled.Should().Be(0);

            someCalled = 0; noneCalled = 0;

            var none = Option.None<int>();
            none.Match(v => someCalled++, () => noneCalled++);

            someCalled.Should().Be(0);
            noneCalled.Should().Be(1);
        }
    }
}
