using System;
using System.Collections.Generic;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        private Dictionary<SwallowType, Swallow> _swallows = new() {
            { SwallowType.African, new AfricanSwallow() },
            { SwallowType.European, new EuropeanSwallow() }
        };
        public Swallow GetSwallow(SwallowType swallowType)
        {
            return _swallows.TryGetValue(swallowType, out var swallow)
                ? swallow
                : throw new ArgumentException($"Swallow type {swallowType} not recognized.");
        }
    }

    public abstract class Swallow
    {
        public SwallowLoad Load { get; private set; } = SwallowLoad.None;

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public abstract double GetAirspeedVelocity();
    }
    public class AfricanSwallow : Swallow
    {
        public override double GetAirspeedVelocity()
        {
            return Load switch
            {
                SwallowLoad.None => 22,
                SwallowLoad.Coconut => 18,
                _ => throw new InvalidOperationException()
            };
        }
    }

    // European swallow subclass
    public class EuropeanSwallow : Swallow
    {
        public override double GetAirspeedVelocity()
        {
            return Load switch
            {
                SwallowLoad.None => 20,
                SwallowLoad.Coconut => 16,
                _ => throw new InvalidOperationException()
            };
        }
    }

    /* Original code
    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            if (Type == SwallowType.African && Load == SwallowLoad.None)
            {
                return 22;
            }
            if (Type == SwallowType.African && Load == SwallowLoad.Coconut)
            {
                return 18;
            }
            if (Type == SwallowType.European && Load == SwallowLoad.None)
            {
                return 20;
            }
            if (Type == SwallowType.European && Load == SwallowLoad.Coconut)
            {
                return 16;
            }
            throw new InvalidOperationException();
        }
    } */
}