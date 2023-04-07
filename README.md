# Futurum.Test

![license](https://img.shields.io/github/license/futurum-dev/dotnet.futurum.test?style=for-the-badge)
![CI](https://img.shields.io/github/actions/workflow/status/futurum-dev/dotnet.futurum.test/ci.yml?branch=main&style=for-the-badge)
[![Coverage Status](https://img.shields.io/coveralls/github/futurum-dev/dotnet.futurum.test?style=for-the-badge)](https://coveralls.io/github/futurum-dev/dotnet.futurum.test?branch=main)
[![NuGet version](https://img.shields.io/nuget/v/futurum.test?style=for-the-badge)](https://www.nuget.org/packages/futurum.test)

A dotnet testing library, allowing you to test code that uses Futurum.Core. It contains a comprehensive set of assertions for testing Futurum.Core types.

## Result
### ShouldBeSuccess
Checks that the result is a success.

```csharp
result.ShouldBeSuccess();
```

### ShouldBeSuccessWithValue
Checks that the result is a success and that the value is equal to the expected value.

```csharp
result.ShouldBeSuccessWithValue(expectedValue);
```

### ShouldBeSuccessWithValueEquivalentTo
Checks that the result is a success and that the value is equivalent to the expected value.

```csharp
result.ShouldBeSuccessWithValueEquivalentTo(equivalentValue);
```

### ShouldBeSuccessWithValueEquivalentToAsync
Checks that the result is a success and that the value is equivalent to the expected value.

```csharp
result.ShouldBeSuccessWithValueEquivalentToAsync(numbers);
```

**NOTE** This method works with *IAsyncEnumerable&lt;T&gt;*.

### ShouldBeSuccessWithValueAssertion
Checks that the result is a success and that the value passes the assertions specified.

```csharp
result.ShouldBeSuccessWithValueAssertion(x => x.Should().Be(expectedValue));
```

### ShouldBeFailure
Checks that the result is a failure.

```csharp
result.ShouldBeFailure();
```

### ShouldBeFailureWithError
Checks that the result is a failure and that the error is equal to the expected error.

```csharp
result.ShouldBeFailureWithError(expectedErrorMessage);
```

### ShouldBeFailureWithErrorSafe
Checks that the result is a failure and that the error is equal to the expected error.

```csharp
result.ShouldBeFailureWithErrorSafe(expectedErrorMessage);
```

**NOTE** This will call *ToErrorStringSafe* on the error.

### ShouldBeFailureWithErrorContaining
Checks that the result is a failure and that the error contains the expected error.

```csharp
result.ShouldBeFailureWithErrorContaining(expectedErrorMessage);
```

### ShouldBeFailureWithErrorSafeContaining
Checks that the result is a failure and that the error contains the expected error.

```csharp
result.ShouldBeFailureWithErrorContaining(expectedErrorMessage);
```

**NOTE** This will call *ToErrorStringSafe* on the error.

## Option
### ShouldBeHasValue
Check that the option has a value.

```csharp
option.ShouldBeHasValue();
```

### ShouldBeHasValueWithValue
Check that the option has a value and that the value is equal to the expected value.

```csharp
option.ShouldBeHasValueWithValue(expectedValue);
```

### ShouldBeHasValueWithValueEquivalentTo
Check that the option has a value and that the value is equivalent to the expected value.

```csharp
option.ShouldBeHasValueWithValueEquivalentTo(equivalentValue);
```

### ShouldBeHasValueWithValueAssertion
Check that the option has a value and that the value passes the assertions specified.

```csharp
option.ShouldBeHasValueWithValueAssertion(x => x.Should().Be(expectedValue));
```

### ShouldBeHasNoValue
Check that the option has no value.

```csharp
option.ShouldBeHasNoValue();
```