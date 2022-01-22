using Moq;

namespace Futurum.Test.Moq;

/// <summary>
/// Extension methods for <see cref="Mock{T}"/>, so that it supports <see cref="Futurum.Core"/>
/// </summary>
public static class MockExtensions
{
    /// <summary>
    /// Configure <see cref="Mock{T}"/> so that it supports <see cref="Futurum.Core"/>
    /// </summary>
    public static Mock<T> Configure<T>(this Mock<T> mock)
        where T : class
    {
        mock.DefaultValueProvider = MoqFuturumDefaultValueProvider.Default;

        return mock;
    }
}