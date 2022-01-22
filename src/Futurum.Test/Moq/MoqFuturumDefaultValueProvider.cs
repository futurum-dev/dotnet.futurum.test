using Moq;

namespace Futurum.Test.Moq;

/// <summary>
/// <see cref="Moq"/> DefaultValueProvider so that it supports <see cref="Futurum.Core"/>
/// </summary>
public class MoqFuturumDefaultValueProvider : LookupOrFallbackDefaultValueProvider
{
    private MoqFuturumDefaultValueProvider()
    {
        Register(typeof(Core.Result.Result), CreateResultFactory);
        Register(typeof(Core.Result.Result<>), CreateResultGenericFactory);
        Register(typeof(Core.Option.Option<>), CreateOptionFactory);
    }

    private static object CreateResultFactory(Type type, Mock mock) =>
        Core.Result.Result.Fail($"Failed to create Result for Mock : '{mock.Object.GetType().FullName}'. Debug the test to breakpoint the creation of the failing Result.");

    private static object CreateResultGenericFactory(Type type, Mock mock) =>
        Core.Result.Result.Fail($"Failed to create Result Generic for Mock : '{mock.Object.GetType().FullName}', Result type : '{type.GenericTypeArguments[0]}'. Debug the test to breakpoint the creation of the failing Result.");

    private static object CreateOptionFactory(Type type, Mock mock) =>
        Core.Result.Result.Fail($"Failed to create Option for Mock : '{mock.Object.GetType().FullName}'.");

    public static readonly MoqFuturumDefaultValueProvider Default = new();
}