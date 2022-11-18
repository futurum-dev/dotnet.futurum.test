using FluentAssertions;

namespace Futurum.Test.Option;

public static partial class FluentAssertionOptionExtensions
{
    /// <summary>
    /// Specifies that the <see cref="Futurum.Core.Option.Option{T}"/> should be <see cref="Futurum.Core.Option.Option{T}.HasNoValue"/> true.
    /// </summary>
    public static void ShouldBeHasNoValue<T>(this Futurum.Core.Option.Option<T> option)
    {
        option.HasNoValue.Should().BeTrue();
        option.HasValue.Should().BeFalse();
    }
}