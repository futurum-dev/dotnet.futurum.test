using FluentAssertions;

using Futurum.Core.Result;
using Futurum.Test.Option;

namespace Futurum.Test.Result;

/// <summary>
/// Extension methods for <see cref="FluentAssertions"/>, so that it supports <see cref="Futurum.Core.Result.Result"/> and <see cref="Futurum.Core.Result.Result{T}"/>
/// </summary>
public static partial class FluentAssertionResultExtensions
{
    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result"/> should be <see cref="Futurum.Core.Result.Result.IsSuccess"/> true.
    /// </summary>
    public static void ShouldBeSuccess(this Core.Result.Result result)
    {
        var errorMessage = result.IsSuccess ? string.Empty : $"Error : '{result.Error.Value.ToErrorString()}'";

        result.IsSuccess.Should().BeTrue(errorMessage);
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsSuccess"/> true.
    /// </summary>
    public static void ShouldBeSuccess<T>(this Result<T> result)
    {
        var errorMessage = result.IsSuccess ? string.Empty : $"Error : '{result.Error.Value.ToErrorString()}'";

        result.IsSuccess.Should().BeTrue(errorMessage);
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsSuccess"/> true with <paramref name="value"/>.
    /// </summary>
    public static void ShouldBeSuccessWithValue<T>(this Result<T> result, T value)
    {
        result.ShouldBeSuccess();

        result.Value.Value.Should().Be(value);
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsSuccess"/> true with <paramref name="optionValue"/>.
    /// </summary>
    public static void ShouldBeSuccessWithValue<T>(this Result<T> result, Futurum.Core.Option.Option<T> optionValue)
    {
        result.ShouldBeSuccess();

        optionValue.ShouldBeHasValue();

        result.Value.Value.Should().Be(optionValue.Value);
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsSuccess"/> true with <paramref name="value"/>.
    /// </summary>
    public static void ShouldBeSuccessWithValue<T, TR>(this Result<T> result, Func<T, TR> selectorFunc, TR value)
    {
        result.ShouldBeSuccess();

        selectorFunc(result.Value.Value).Should().Be(value);
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsSuccess"/> true with equivalent to <paramref name="value"/>.
    /// </summary>
    public static void ShouldBeSuccessWithValueEquivalentTo<T>(this Result<T> result, T value)
    {
        result.ShouldBeSuccess();

        result.Value.Value.Should().BeEquivalentTo(value);
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsSuccess"/> true with equivalent to <paramref name="value"/>.
    /// </summary>
    public static void ShouldBeSuccessWithValueEquivalentTo<T, TR>(this Result<T> result, Func<T, TR> selectorFunc, TR value)
    {
        result.ShouldBeSuccess();

        selectorFunc(result.Value.Value).Should().BeEquivalentTo(value);
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsSuccess"/> true with equivalent to <paramref name="value"/>.
    /// </summary>
    public static Task ShouldBeSuccessWithValueEquivalentToAsync<TData>(this Result<IAsyncEnumerable<TData>> result, IEnumerable<TData> value) =>
        result.ShouldBeSuccessWithValueEquivalentToAsync(x => x, value);

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsSuccess"/> true with equivalent to <paramref name="value"/>.
    /// </summary>
    public static async Task ShouldBeSuccessWithValueEquivalentToAsync<T, TData>(this Result<T> result, Func<T, IAsyncEnumerable<TData>> selectorFunc, IEnumerable<TData> value)
    {
        result.ShouldBeSuccess();

        var asyncEnumerable = selectorFunc(result.Value.Value);

        var left = await ConvertIAsyncEnumerableToIEnumerable(asyncEnumerable);

        var right = value;

        left.Should().BeEquivalentTo(right);

        static async Task<IEnumerable<TData>> ConvertIAsyncEnumerableToIEnumerable(IAsyncEnumerable<TData> value)
        {
            var list = new List<TData>();

            await foreach (var x in value)
            {
                list.Add(x);
            }

            return list;
        }
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsSuccess"/> true with equivalent to <paramref name="value"/>.
    /// </summary>
    public static Task ShouldBeSuccessWithValueEquivalentToAsync<TData>(this Result<IAsyncEnumerable<TData>> result, IAsyncEnumerable<TData> value) =>
        result.ShouldBeSuccessWithValueEquivalentToAsync(x => x, value);

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsSuccess"/> true with equivalent to <paramref name="value"/>.
    /// </summary>
    public static async Task ShouldBeSuccessWithValueEquivalentToAsync<T, TData>(this Result<T> result, Func<T, IAsyncEnumerable<TData>> selectorFunc, IAsyncEnumerable<TData> value)
    {
        result.ShouldBeSuccess();

        var asyncEnumerable = selectorFunc(result.Value.Value);

        var left = await ConvertIAsyncEnumerableToIEnumerable(asyncEnumerable);

        var right = await ConvertIAsyncEnumerableToIEnumerable(value);

        left.Should().BeEquivalentTo(right);

        static async Task<IEnumerable<TData>> ConvertIAsyncEnumerableToIEnumerable(IAsyncEnumerable<TData> value)
        {
            var list = new List<TData>();

            await foreach (var x in value)
            {
                list.Add(x);
            }

            return list;
        }
    }

    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Result.Result{T}"/> should be <see cref="Futurum.Core.Result.Result{T}.IsSuccess"/> true and <paramref name="valueAssertion"/>.
    /// </summary>
    public static void ShouldBeSuccessWithValueAssertion<T>(this Result<T> result, Action<T> valueAssertion)
    {
        var errorMessage = result.IsSuccess ? string.Empty : $"Error : '{result.Error.Value.ToErrorString()}'";

        result.IsSuccess.Should().BeTrue(errorMessage);

        valueAssertion(result.Value.Value);
    }
}