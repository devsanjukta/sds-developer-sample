using System.Collections.Generic;
using System;
using Xunit;

namespace DeveloperSample.Container
{
    internal interface IContainerTestInterface
    {
    }

    internal class ContainerTestClass : IContainerTestInterface
    {
    }
    public abstract class AbstractClass : IContainerTestInterface { }
    public class UnrelatedClass { }

    public interface IOtherInterface { }
    public class OtherImplementation : IOtherInterface { }

    public class ContainerTest
    {
        //[Fact(Skip="Not implemented")]
        [Fact]
        public void CanBindAndGetService()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            var testInstance = container.Get<IContainerTestInterface>();
            Assert.IsType<ContainerTestClass>(testInstance);
        }

        [Fact]
        public void GetThrowsWhenNoBindingExists()
        {
            var container = new Container();

            Assert.Throws<InvalidOperationException>(() =>
            {
                var result = container.Get<IContainerTestInterface>();
            });
        }

        [Fact]
        public void BindThrowsWhenKeyIsNotInterfaceOrAbstract()
        {
            var container = new Container();

            Assert.Throws<ArgumentException>(() =>
            {
                container.Bind(typeof(string), typeof(ContainerTestClass));
            });
        }

        

        [Fact]
        public void BindThrowsWhenImplementationIsAbstract()
        {
            var container = new Container();

            Assert.Throws<ArgumentException>(() =>
            {
                container.Bind(typeof(IContainerTestInterface), typeof(AbstractClass));
            });
        }

        [Fact]
        public void BindThrowsWhenImplementationDoesNotMatchInterface()
        {
            var container = new Container();

            Assert.Throws<ArgumentException>(() =>
            {
                container.Bind(typeof(IContainerTestInterface), typeof(UnrelatedClass));
            });
        }

        [Fact]
        public void BindOverridesExistingBinding()
        {
            var container = new Container();

            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            container.Bind(typeof(IContainerTestInterface), typeof(OtherImplementation));

            var result = container.Get<IContainerTestInterface>();

            Assert.IsType<OtherImplementation>(result);
        }

        [Fact]
        public void CanBindAndResolveMultipleTypes()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            container.Bind(typeof(IOtherInterface), typeof(OtherImplementation));

            var result1 = container.Get<IContainerTestInterface>();
            var result2 = container.Get<IOtherInterface>();

            Assert.IsType<ContainerTestClass>(result1);
            Assert.IsType<OtherImplementation>(result2);
        }
    }
}