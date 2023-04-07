using FluentAssertions;

using Futurum.Core.Result;
using Futurum.Test.Result;

using Xunit;

namespace Futurum.Test.Tests.Result;

public class FluentAssertionResultExtensionsShouldBeFailureTests
{
    private const string ERROR_MESSAGE = "Error-Message";

    public class ShouldBeFailure
    {
        [Fact]
        public void Success()
        {
            var result = Core.Result.Result.Ok();

            var action = () => result.ShouldBeFailure();

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsFailure to be true, but found False.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail(ERROR_MESSAGE);

            result.ShouldBeFailure();
        }
    }

    public class ShouldBeFailureWithErrorSafe
    {
        [Fact]
        public void Success()
        {
            var result = Core.Result.Result.Ok();

            var action = () => result.ShouldBeFailureWithErrorSafe(ERROR_MESSAGE);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsFailure to be true, but found False.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail(ERROR_MESSAGE);

            result.ShouldBeFailureWithErrorSafe(ERROR_MESSAGE);
        }
    }

    public class ShouldBeFailureWithError
    {
        [Fact]
        public void Success()
        {
            var result = Core.Result.Result.Ok();

            var action = () => result.ShouldBeFailureWithError(ERROR_MESSAGE);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsFailure to be true, but found False.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail(ERROR_MESSAGE);

            result.ShouldBeFailureWithError(ERROR_MESSAGE);
        }
    }

    public class ShouldBeFailure_Generic
    {
        [Fact]
        public void Success()
        {
            var result = Core.Result.Result.Ok(10);

            var action = () => result.ShouldBeFailure();

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsFailure to be true, but found False.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail<int>(ERROR_MESSAGE);

            result.ShouldBeFailure();
        }
    }

    public class ShouldBeFailureWithErrorSafe_Generic
    {
        [Fact]
        public void Success()
        {
            var result = Core.Result.Result.Ok(10);

            var action = () => result.ShouldBeFailureWithErrorSafe(ERROR_MESSAGE);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsFailure to be true, but found False.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail<int>(ERROR_MESSAGE);

            result.ShouldBeFailureWithErrorSafe(ERROR_MESSAGE);
        }
    }

    public class ShouldBeFailureWithError_Generic
    {
        [Fact]
        public void Success()
        {
            var result = Core.Result.Result.Ok(10);

            var action = () => result.ShouldBeFailureWithError(ERROR_MESSAGE);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsFailure to be true, but found False.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail<int>(ERROR_MESSAGE);

            result.ShouldBeFailureWithError(ERROR_MESSAGE);
        }
    }

    public class ShouldBeFailureWithErrorSafeContaining
    {
        [Fact]
        public void Success()
        {
            var result = Core.Result.Result.Ok();

            var action = () => result.ShouldBeFailureWithErrorSafeContaining(ERROR_MESSAGE);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsFailure to be true, but found False.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail(ResultErrorCompositeExtensions.ToResultError(ERROR_MESSAGE.ToResultError(), ERROR_MESSAGE.ToResultError()));

            result.ShouldBeFailureWithErrorSafeContaining(ERROR_MESSAGE);
        }
    }

    public class ShouldBeFailureWithErrorContaining
    {
        [Fact]
        public void Success()
        {
            var result = Core.Result.Result.Ok();

            var action = () => result.ShouldBeFailureWithErrorContaining(ERROR_MESSAGE);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsFailure to be true, but found False.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail(ResultErrorCompositeExtensions.ToResultError(ERROR_MESSAGE.ToResultError(), ERROR_MESSAGE.ToResultError()));

            result.ShouldBeFailureWithErrorContaining(ERROR_MESSAGE);
        }
    }

    public class ShouldBeFailureWithErrorSafeContaining_Generic
    {
        [Fact]
        public void Success()
        {
            var result = Core.Result.Result.Ok(10);

            var action = () => result.ShouldBeFailureWithErrorSafeContaining(ERROR_MESSAGE);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsFailure to be true, but found False.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail<int>(ResultErrorCompositeExtensions.ToResultError(ERROR_MESSAGE.ToResultError(), ERROR_MESSAGE.ToResultError()));

            result.ShouldBeFailureWithErrorSafeContaining(ERROR_MESSAGE);
        }
    }

    public class ShouldBeFailureWithErrorContaining_Generic
    {
        [Fact]
        public void Success()
        {
            var result = Core.Result.Result.Ok(10);

            var action = () => result.ShouldBeFailureWithErrorContaining(ERROR_MESSAGE);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsFailure to be true, but found False.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail<int>(ResultErrorCompositeExtensions.ToResultError(ERROR_MESSAGE.ToResultError(), ERROR_MESSAGE.ToResultError()));

            result.ShouldBeFailureWithErrorContaining(ERROR_MESSAGE);
        }
    }

    public class ShouldBeErrorSafe
    {
        [Fact]
        public void success()
        {
            var resultError = ERROR_MESSAGE.ToResultError();

            resultError.ShouldBeErrorSafe(ERROR_MESSAGE);
        }

        [Fact]
        public void failure()
        {
            var incorrectErrorMessage = "test";

            var resultError = ERROR_MESSAGE.ToResultError();

            var action = () => resultError.ShouldBeErrorSafe(incorrectErrorMessage);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should()
                  .Contain("Expected error.ToErrorStringSafe() to be \"test\" with a length of 4, but \"Error-Message\" has a length of 13, differs near \"Err\" (index 0).");
        }
    }

    public class ShouldBeError
    {
        [Fact]
        public void success()
        {
            var resultError = ERROR_MESSAGE.ToResultError();

            resultError.ShouldBeError(ERROR_MESSAGE);
        }

        [Fact]
        public void failure()
        {
            var incorrectErrorMessage = "test";

            var resultError = ERROR_MESSAGE.ToResultError();

            var action = () => resultError.ShouldBeError(incorrectErrorMessage);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should()
                  .Contain("Expected error.ToErrorString() to be \"test\" with a length of 4, but \"Error-Message\" has a length of 13, differs near \"Err\" (index 0).");
        }
    }
}