using FluentAssertions;

using Futurum.Test.Option;

using Xunit;

namespace Futurum.Test.Tests.Option;

public class FluentAssertionOptionExtensionsShouldBeHasValueTests
{
    public class ShouldBeHasValue
    {
        [Fact]
        public void HasValue()
        {
            var option = Core.Option.Option.From(10);

            option.ShouldBeHasValue();
        }

        [Fact]
        public void HasNoValue()
        {
            var option = Core.Option.Option.None<int>();

            var action = () => option.ShouldBeHasValue();

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected option.HasValue to be true, but found False.");
        }
    }

    public class ShouldBeHasValueWithValue
    {
        [Fact]
        public void HasValue_matches()
        {
            var value = 10;

            var option = Core.Option.Option.From(value);

            option.ShouldBeHasValueWithValue(value);
        }

        [Fact]
        public void HasValue_doesnt_match()
        {
            var value = 10;

            var option = Core.Option.Option.From(value);

            var action = () => option.ShouldBeHasValueWithValue(20);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected option.Value to be 20, but found 10.");
        }

        [Fact]
        public void HasNoValue()
        {
            var option = Core.Option.Option.None<int>();

            var action = () => option.ShouldBeHasValueWithValue(10);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected option.HasValue to be true, but found False.");
        }
    }

    public class ShouldBeHasValueWithValueWithSelector
    {
        [Fact]
        public void HasValue_matches()
        {
            var value = new TestClass(10);

            var option = Core.Option.Option.From(value);

            option.ShouldBeHasValueWithValue(x => x.Number, value.Number);
        }

        [Fact]
        public void HasValue_doesnt_match()
        {
            var value = new TestClass(10);

            var option = Core.Option.Option.From(value);

            var action = () => option.ShouldBeHasValueWithValue(x => x.Number, 20);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected selectorFunc(option.Value) to be 20, but found 10.");
        }

        [Fact]
        public void HasNoValue()
        {
            var option = Core.Option.Option.None<TestClass>();

            var action = () => option.ShouldBeHasValueWithValue(x => x.Number, 10);

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected option.HasValue to be true, but found False.");
        }
    }

    public class ShouldBeHasValueWithValueEquivalentTo
    {
        [Fact]
        public void HasValue_matches()
        {
            var value = new TestClass(10);

            var option = Core.Option.Option.From(value);

            option.ShouldBeHasValueWithValueEquivalentTo(new TestClass(10));
        }

        [Fact]
        public void HasValue_doesnt_match()
        {
            var value = new TestClass(10);

            var option = Core.Option.Option.From(value);

            var action = () => option.ShouldBeHasValueWithValueEquivalentTo(new TestClass(20));

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected property option.Value.Number to be 20, but found 10.");
        }

        [Fact]
        public void HasNoValue()
        {
            var option = Core.Option.Option.None<TestClass>();

            var action = () => option.ShouldBeHasValueWithValueEquivalentTo(new TestClass(20));

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected option.HasValue to be true, but found False.");
        }
    }

    public class ShouldBeHasValueWithValueEquivalentToWithSelector
    {
        [Fact]
        public void HasValue_matches()
        {
            var value = new TestChildClass(10);

            var option = Core.Option.Option.From(value);

            option.ShouldBeHasValueWithValueEquivalentTo(x => x.Child, new TestChildClass.ChildClass(10));
        }

        [Fact]
        public void HasValue_doesnt_match()
        {
            var value = new TestChildClass(10);

            var option = Core.Option.Option.From(value);

            var action = () => option.ShouldBeHasValueWithValueEquivalentTo(x => x.Child, new TestChildClass.ChildClass(20));

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected property selectorFunc(option.Value).Number to be 20, but found 10.");
        }

        [Fact]
        public void HasNoValue()
        {
            var option = Core.Option.Option.None<TestChildClass>();

            var action = () => option.ShouldBeHasValueWithValueEquivalentTo(x => x.Child, new TestChildClass.ChildClass(10));

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected option.HasValue to be true, but found False.");
        }
    }

    public class ShouldBeHasValueWithValueAssertion
    {
        [Fact]
        public void HasValue_matches()
        {
            var value = 10;

            var option = Core.Option.Option.From(value);

            option.ShouldBeHasValueWithValueAssertion(x => x.Should().Be(value));
        }

        [Fact]
        public void HasValue_doesnt_match()
        {
            var value = 10;

            var option = Core.Option.Option.From(value);

            var action = () => option.ShouldBeHasValueWithValueAssertion(x => x.Should().NotBe(value));

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Did not expect x to be 10");
        }

        [Fact]
        public void HasNoValue()
        {
            var option = Core.Option.Option.None<int>();

            var action = () => option.ShouldBeHasValueWithValueAssertion(x => x.Should().Be(10));

            action.Should().Throw<Xunit.Sdk.XunitException>().Which.Message.Should().Contain("Expected option.HasValue to be true, but found False.");
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