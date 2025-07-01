using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        // Dictionary to hold the bindings between interfaces/abstract classes and their concrete implementations
        private readonly Dictionary<Type, Type> _bindings = new();

        // Register a mapping between interface and implementation
        public void Bind(Type interfaceType, Type implementationType)
        {
            // Interface type must be an interface or abstract class
            if (!interfaceType.IsInterface && !interfaceType.IsAbstract)
            {
                throw new ArgumentException("The key type must be an interface or abstract class.");
            }

            // Implementation must be a concrete class (not abstract)
            if (!implementationType.IsClass || implementationType.IsAbstract)
            {
                throw new ArgumentException("The implementation type must be a concrete class.");
            }

            // Implementation must actually implement the interface or inherit the abstract class
            if (!interfaceType.IsAssignableFrom(implementationType))
            {
                throw new ArgumentException($"The type {implementationType.FullName} does not implement {interfaceType.FullName}.");
            }

            _bindings[interfaceType] = implementationType;
        }
        public T Get<T>()
        {
            var typeToResolve = typeof(T);

            // Look up the implementation type for the requested interface or abstract class
            if (_bindings.TryGetValue(typeToResolve, out var implementationType))
            {
                // Create an instance using the parameterless constructor
                return (T)Activator.CreateInstance(implementationType)!;
            }
            else
            {
                // No binding found for the requested type - throw exception
                throw new InvalidOperationException($"No binding found for type {typeToResolve.FullName}");
            }
        }
    }
}