using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace Overseer.Abstractions.Tests
{
    public class ResultTests
    {
        [Fact]
        public void Success_ReturnsEncapsulatedResult()
        {
            var result = Result<string>.Succeed("test");

            result.Should().NotBeNull();
            result.Succeeded.Should().BeTrue();
            result.Value.Should().Be("test");
        }
        [Fact]
        public void StaticSuccess_ReturnsEncapsulatedResult()
        {
            var result = Result.Succeed("test");

            result.Should().NotBeNull();
            result.Succeeded.Should().BeTrue();
            result.Value.Should().Be("test");
            result.Should().BeOfType<Result<string>>();
        }

        [Fact]
        public void StaticFail_ReturnsErrorResult()
        {
            var result = Result.Fail<string>(new ValidationResult("Error"));

            result.Should().NotBeNull();
            result.Succeeded.Should().BeFalse();
            result.Value.Should().Be(default);
            result.Error.Should().NotBeNull();
            result.Error.ErrorMessage.Should().Be("Error");
            result.Should().BeOfType<Result<string>>();
        }
        [Fact]
        public void Fail_ReturnsErrorResult()
        {
            var result = Result<string>.Fail(new ValidationResult("Error"));

            result.Should().NotBeNull();
            result.Succeeded.Should().BeFalse();
            result.Value.Should().Be(default);
            result.Error.Should().NotBeNull();
            result.Error.ErrorMessage.Should().Be("Error");
        }
        [Fact]
        public void MapError_ReturnsMappedErrorResult()
        {
            var result = Result<string>.Fail(new ValidationResult("Error"));

            var newResult = result.MapError<int>();

            newResult.Should().NotBeNull();
            newResult.Succeeded.Should().BeFalse();
            newResult.Error.Should().NotBeNull();
            newResult.Error.ErrorMessage.Should().Be("Error");

            newResult.Should().BeOfType<Result<int>>();
        }
    }
}
