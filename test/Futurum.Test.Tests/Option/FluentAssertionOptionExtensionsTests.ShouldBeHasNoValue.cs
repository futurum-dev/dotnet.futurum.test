using Futurum.Test.Option;

using Xunit;

namespace Futurum.Test.Tests.Option;

public class FluentAssertionOptionExtensionsShouldBeHasNoValueTests
{
    [Fact]
    public void ShouldBeHasNoValue()
    {
        var option = Core.Option.Option.None<int>();

        option.ShouldBeHasNoValue();
    }
}