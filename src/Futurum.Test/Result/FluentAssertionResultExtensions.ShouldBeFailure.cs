using FluentAssertions;

using Futurum.Core.Result;

namespace Futurum.Test.Result;

public static partial class FluentAssertionResultExtensions
{
    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result"/> should be <see cref="Futurum.Core.Result.Result.IsFailure"/> true.
    /// </summary>
    public static void ShouldBeFailure(this Core.Result.Result result)
    {
        result.IsFailure.Should().BeTrue();
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result"/> should be <see cref="Futurum.Core.Result.Result.IsFailure"/> true with <paramref name="errorMessages"/>.
    /// </summary>
    public static void ShouldBeFailureWithErrorSafe(this Core.Result.Result result, params string[] errorMessages)
    {
        result.ShouldBeFailure();

        result.Error.Map(ResultErrorStringExtensions.ToErrorStringSafe).Should().Be(string.Join(";", errorMessages));
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result"/> should be <see cref="Futurum.Core.Result.Result.IsFailure"/> true with <paramref name="errorMessages"/>.
    /// </summary>
    public static void ShouldBeFailureWithError(this Core.Result.Result result, params string[] errorMessages)
    {
        result.ShouldBeFailure();

        result.Error.Map(ResultErrorStringExtensions.ToErrorString).Should().Be(string.Join(";", errorMessages));
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsFailure"/> true.
    /// </summary>
    public static void ShouldBeFailure<T>(this Result<T> result)
    {
        result.IsFailure.Should().BeTrue();
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsFailure"/> true with <paramref name="errorMessages"/>.
    /// </summary>
    public static void ShouldBeFailureWithErrorSafe<T>(this Result<T> result, params string[] errorMessages)
    {
        result.ShouldBeFailure();

        result.Error.Map(ResultErrorStringExtensions.ToErrorStringSafe).Should().Be(string.Join(";", errorMessages));
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsFailure"/> true with <paramref name="errorMessages"/>.
    /// </summary>
    public static void ShouldBeFailureWithError<T>(this Result<T> result, params string[] errorMessages)
    {
        result.ShouldBeFailure();

        result.Error.Map(ResultErrorStringExtensions.ToErrorString).Should().Be(string.Join(";", errorMessages));
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsFailure"/> true containing <paramref name="errorMessage"/>.
    /// </summary>
    public static void ShouldBeFailureWithErrorSafeContaining(this Core.Result.Result result, string errorMessage)
    {
        result.ShouldBeFailure();

        result.Error.Value.Flatten().Any(e => e.ToErrorStringSafe(",").Contains(errorMessage))
              .Should().BeTrue($"Error does not contain error message : '{errorMessage}' , '{result.Error.Value.ToErrorString(",")}'");
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsFailure"/> true containing <paramref name="errorMessage"/>.
    /// </summary>
    public static void ShouldBeFailureWithErrorContaining(this Core.Result.Result result, string errorMessage)
    {
        result.ShouldBeFailure();

        result.Error.Value.Flatten().Any(e => e.ToErrorString(",").Contains(errorMessage))
              .Should().BeTrue($"Error does not contain error message : '{errorMessage}' , '{result.Error.Value.ToErrorString(",")}'");
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsFailure"/> true containing <paramref name="errorMessage"/>.
    /// </summary>
    public static void ShouldBeFailureWithErrorSafeContaining<T>(this Result<T> result, string errorMessage)
    {
        result.ShouldBeFailure();

        result.Error.Value.Flatten().Any(e => e.ToErrorStringSafe(",").Contains(errorMessage))
              .Should().BeTrue($"Error does not contain error message : '{errorMessage}' , '{result.Error.Value.ToErrorString(",")}'");
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsFailure"/> true containing <paramref name="errorMessage"/>.
    /// </summary>
    public static void ShouldBeFailureWithErrorContaining<T>(this Result<T> result, string errorMessage)
    {
        result.ShouldBeFailure();

        result.Error.Value.Flatten().Any(e => e.ToErrorString(",").Contains(errorMessage))
              .Should().BeTrue($"Error does not contain error message : '{errorMessage}' , '{result.Error.Value.ToErrorString(",")}'");
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.IResultError"/> should be <paramref name="errorMessages"/>.
    /// </summary>
    public static void ShouldBeErrorSafe(this IResultError error, params string[] errorMessages)
    {
        error.ToErrorStringSafe().Should().Be(string.Join(";", errorMessages));
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.IResultError"/> should be <paramref name="errorMessages"/>.
    /// </summary>
    public static void ShouldBeError(this IResultError error, params string[] errorMessages)
    {
        error.ToErrorString().Should().Be(string.Join(";", errorMessages));
    }
}