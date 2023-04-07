using FluentAssertions;

using Futurum.Core.Option;
using Futurum.Test.Result;

using Xunit;

namespace Futurum.Test.Tests.Result;

public class FluentAssertionResultExtensionsShouldBeSuccessTests
{
    private const string ERROR_MESSAGE = "Error-Message";

    public class ShouldBeSuccess
    {
        [Fact]
        public void Success()
        {
            var result = Core.Result.Result.Ok();

            result.ShouldBeSuccess();
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail(ERROR_MESSAGE);

            var action = () => result.ShouldBeSuccess();

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsSuccess to be true because Error : 'Error-Message', but found False.");
        }
    }

    public class ShouldBeSuccess_Generic
    {
        [Fact]
        public void Success()
        {
            var result = Core.Result.Result.Ok(10);

            result.ShouldBeSuccess();
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail<int>(ERROR_MESSAGE);

            var action = () => result.ShouldBeSuccess();

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsSuccess to be true because Error : 'Error-Message', but found False.");
        }
    }

    public class ShouldBeSuccessWithValue
    {
        [Fact]
        public void Success_matches()
        {
            var value = 10;

            var result = Core.Result.Result.Ok(value);

            result.ShouldBeSuccessWithValue(value);
        }

        [Fact]
        public void Success_doesnt_match()
        {
            var result = Core.Result.Result.Ok(10);

            var action = () => result.ShouldBeSuccessWithValue(20);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.Value.Value to be 20, but found 10.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail<int>(ERROR_MESSAGE);

            var action = () => result.ShouldBeSuccessWithValue(10);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsSuccess to be true because Error : 'Error-Message', but found False.");
        }
    }

    public class ShouldBeSuccessWithValue_Option
    {
        [Fact]
        public void Success_matches()
        {
            var value = 10;

            var result = Core.Result.Result.Ok(value);

            result.ShouldBeSuccessWithValue(value.ToOption());
        }

        [Fact]
        public void Success_doesnt_match()
        {
            var result = Core.Result.Result.Ok(10);

            var action = () => result.ShouldBeSuccessWithValue(20.ToOption());

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.Value.Value to be 20, but found 10.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail<int>(ERROR_MESSAGE);

            var action = () => result.ShouldBeSuccessWithValue(10);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsSuccess to be true because Error : 'Error-Message', but found False.");
        }
    }

    public class ShouldBeSuccessWithValueWithSelector
    {
        [Fact]
        public void Success_matches()
        {
            var value = new TestClass(10);

            var result = Core.Result.Result.Ok(value);

            result.ShouldBeSuccessWithValue(x => x.Number, value.Number);
        }

        [Fact]
        public void Success_doesnt_match()
        {
            var value = new TestClass(10);

            var result = Core.Result.Result.Ok(value);

            var action = () => result.ShouldBeSuccessWithValue(x => x.Number, 20);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected selectorFunc(result.Value.Value) to be 20, but found 10.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail<TestClass>(ERROR_MESSAGE);

            var action = () => result.ShouldBeSuccessWithValue(x => x.Number, 20);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsSuccess to be true because Error : 'Error-Message', but found False.");
        }
    }

    public class ShouldBeSuccessWithValueEquivalentTo
    {
        [Fact]
        public void Success_matches()
        {
            var value = new TestClass(10);

            var result = Core.Result.Result.Ok(value);

            result.ShouldBeSuccessWithValueEquivalentTo(new TestClass(10));
        }

        [Fact]
        public void Success_doesnt_match()
        {
            var value = new TestClass(10);

            var result = Core.Result.Result.Ok(value);

            var action = () => result.ShouldBeSuccessWithValueEquivalentTo(new TestClass(20));

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected property result.Value.Value.Number to be 20, but found 10.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail<TestClass>(ERROR_MESSAGE);

            var action = () => result.ShouldBeSuccessWithValueEquivalentTo(new TestClass(10));

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsSuccess to be true because Error : 'Error-Message', but found False.");
        }
    }

    public class ShouldBeSuccessWithValueEquivalentToWithSelector
    {
        [Fact]
        public void Success_matches()
        {
            var value = new TestChildClass(10);

            var result = Core.Result.Result.Ok(value);

            result.ShouldBeSuccessWithValueEquivalentTo(x => x.Child, new TestChildClass.ChildClass(10));
        }

        [Fact]
        public void Success_doesnt_match()
        {
            var value = new TestChildClass(10);

            var result = Core.Result.Result.Ok(value);

            var action = () => result.ShouldBeSuccessWithValueEquivalentTo(x => x.Child, new TestChildClass.ChildClass(20));

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected property selectorFunc(result.Value.Value).Number to be 20, but found 10.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail<TestChildClass>(ERROR_MESSAGE);

            var action = () => result.ShouldBeSuccessWithValueEquivalentTo(x => x.Child, new TestChildClass.ChildClass(10));

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsSuccess to be true because Error : 'Error-Message', but found False.");
        }
    }

    public class ShouldBeSuccessWithValueEquivalentToAsync
    {
        public class compare_to_IEnumerable
        {
            public class WithoutSelector
            {
                [Fact]
                public void Success_matches()
                {
                    var numbers = Enumerable.Range(0, 10);

                    var value = AsyncEnumerable(numbers);

                    var result = Core.Result.Result.Ok(value);

                    result.ShouldBeSuccessWithValueEquivalentToAsync(numbers);
                }

                [Fact]
                public void Success_doesnt_match()
                {
                    var numbers = Enumerable.Range(0, 10);

                    var value = AsyncEnumerable(numbers);

                    var result = Core.Result.Result.Ok(value);

                    var action = () => result.ShouldBeSuccessWithValueEquivalentToAsync(numbers.Select(x => x * 2));

                    action.Should().ThrowAsync<Xunit.Sdk.XunitException>().WithMessage("Expected property selectorFunc(result.Value.Value).Number to be 20, but found 10.");
                }

                [Fact]
                public void Failure()
                {
                    var result = Core.Result.Result.Fail<IAsyncEnumerable<int>>(ERROR_MESSAGE);

                    var action = () => result.ShouldBeSuccessWithValueEquivalentToAsync(Enumerable.Range(0, 10));

                    action.Should().ThrowAsync<Xunit.Sdk.XunitException>().WithMessage("Expected result.IsSuccess to be true because Error : 'Error-Message', but found False.");
                }
            }

            public class WithSelector
            {
                [Fact]
                public void Success_matches()
                {
                    var numbers = Enumerable.Range(0, 10);

                    var value = new TestAsyncEnumerableClass(AsyncEnumerable(numbers));

                    var result = Core.Result.Result.Ok(value);

                    result.ShouldBeSuccessWithValueEquivalentToAsync(x => x.Numbers, numbers);
                }

                [Fact]
                public void Success_doesnt_match()
                {
                    var numbers = Enumerable.Range(0, 10);

                    var value = new TestAsyncEnumerableClass(AsyncEnumerable(numbers));

                    var result = Core.Result.Result.Ok(value);

                    var action = () => result.ShouldBeSuccessWithValueEquivalentToAsync(x => x.Numbers, numbers.Select(x => x * 2));

                    action.Should().ThrowAsync<Xunit.Sdk.XunitException>().WithMessage("Expected property selectorFunc(result.Value.Value).Number to be 20, but found 10.");
                }

                [Fact]
                public void Failure()
                {
                    var result = Core.Result.Result.Fail<TestAsyncEnumerableClass>(ERROR_MESSAGE);

                    var action = () => result.ShouldBeSuccessWithValueEquivalentToAsync(x => x.Numbers, Enumerable.Range(0, 10));

                    action.Should().ThrowAsync<Xunit.Sdk.XunitException>().WithMessage("Expected result.IsSuccess to be true because Error : 'Error-Message', but found False.");
                }
            }
        }

        public class compare_to_IAsyncEnumerable
        {
            public class WithoutSelector
            {
                [Fact]
                public void Success_matches()
                {
                    var numbers = Enumerable.Range(0, 10);

                    var value = AsyncEnumerable(numbers);

                    var result = Core.Result.Result.Ok(value);

                    result.ShouldBeSuccessWithValueEquivalentToAsync(AsyncEnumerable(numbers));
                }

                [Fact]
                public void Success_doesnt_match()
                {
                    var numbers = Enumerable.Range(0, 10);

                    var value = AsyncEnumerable(numbers);

                    var result = Core.Result.Result.Ok(value);

                    var action = () => result.ShouldBeSuccessWithValueEquivalentToAsync(AsyncEnumerable(numbers.Select(x => x * 2)));

                    action.Should().ThrowAsync<Xunit.Sdk.XunitException>().WithMessage("Expected property selectorFunc(result.Value.Value).Number to be 20, but found 10.");
                }

                [Fact]
                public void Failure()
                {
                    var result = Core.Result.Result.Fail<IAsyncEnumerable<int>>(ERROR_MESSAGE);

                    var action = () => result.ShouldBeSuccessWithValueEquivalentToAsync(AsyncEnumerable(Enumerable.Range(0, 10)));

                    action.Should().ThrowAsync<Xunit.Sdk.XunitException>().WithMessage("Expected result.IsSuccess to be true because Error : 'Error-Message', but found False.");
                }
            }

            public class WithSelector
            {
                [Fact]
                public void Success_matches()
                {
                    var numbers = Enumerable.Range(0, 10);

                    var value = new TestAsyncEnumerableClass(AsyncEnumerable(numbers));

                    var result = Core.Result.Result.Ok(value);

                    result.ShouldBeSuccessWithValueEquivalentToAsync(x => x.Numbers, AsyncEnumerable(numbers));
                }

                [Fact]
                public void Success_doesnt_match()
                {
                    var numbers = Enumerable.Range(0, 10);

                    var value = new TestAsyncEnumerableClass(AsyncEnumerable(numbers));

                    var result = Core.Result.Result.Ok(value);

                    var action = () => result.ShouldBeSuccessWithValueEquivalentToAsync(x => x.Numbers, AsyncEnumerable(numbers.Select(x => x * 2)));

                    action.Should().ThrowAsync<Xunit.Sdk.XunitException>().WithMessage("Expected property selectorFunc(result.Value.Value).Number to be 20, but found 10.");
                }

                [Fact]
                public void Failure()
                {
                    var result = Core.Result.Result.Fail<TestAsyncEnumerableClass>(ERROR_MESSAGE);

                    var action = () => result.ShouldBeSuccessWithValueEquivalentToAsync(x => x.Numbers, AsyncEnumerable(Enumerable.Range(0, 10)));

                    action.Should().ThrowAsync<Xunit.Sdk.XunitException>().WithMessage("Expected result.IsSuccess to be true because Error : 'Error-Message', but found False.");
                }
            }
        }


        private static async IAsyncEnumerable<int> AsyncEnumerable(IEnumerable<int> numbers)
        {
            await Task.Yield();

            foreach (var number in numbers)
            {
                yield return number;
            }
        }

        public class TestAsyncEnumerableClass
        {
            public IAsyncEnumerable<int> Numbers { get; }

            public TestAsyncEnumerableClass(IAsyncEnumerable<int> numbers)
            {
                Numbers = numbers;
            }
        }
    }

    public class ShouldBeSuccessWithValueAssertion
    {
        [Fact]
        public void Success_matches()
        {
            var value = 10;

            var result = Core.Result.Result.Ok(value);

            result.ShouldBeSuccessWithValueAssertion(x => x.Should().Be(value));
        }

        [Fact]
        public void Success_doesnt_match()
        {
            var value = 10;

            var result = Core.Result.Result.Ok(value);

            var action = () => result.ShouldBeSuccessWithValueAssertion(x => x.Should().NotBe(value));

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Did not expect x to be 10.");
        }

        [Fact]
        public void Failure()
        {
            var result = Core.Result.Result.Fail<int>(ERROR_MESSAGE);

            var action = () => result.ShouldBeSuccessWithValueAssertion(x => x.Should().Be(10));

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected result.IsSuccess to be true because Error : 'Error-Message', but found False.");
        }
    }

    private class TestClass
    {
        public int Number { get; }

        public TestClass(int number)
        {
            Number = number;
        }
    }

    private class TestChildClass
    {
        public ChildClass Child { get; }

        public TestChildClass(int number)
        {
            Child = new ChildClass(number);
        }

        public class ChildClass
        {
            public int Number { get; }

            public ChildClass(int number)
            {
                Number = number;
            }
        }
    }
}