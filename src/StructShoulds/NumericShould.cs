using Shouldly;
using ShouldlyFluentassertionsBridge.Constraints;

namespace ShouldlyFluentassertionsBridge.StructShoulds;

public class NumericShould<T>(T input) : StructShould<T>(input) where T : struct, IComparable<T>
{
    public AndConstraint<NumericShould<T>> BeGreaterOrEqualTo(T expected,
                                                              string? because = null)
    {
        input.ShouldBeGreaterThanOrEqualTo(expected,
                                           because);
        return new AndConstraint<NumericShould<T>>(this);
    }

    public AndConstraint<NumericShould<T>> BeGreaterThan(T expected,
                                                         string? because = null)
    {
        input.ShouldBeGreaterThan(expected, customMessage: because);
        return new AndConstraint<NumericShould<T>>(this);
    }

    public AndConstraint<NumericShould<T>> BeLessThan(T expected,
                                                      string? because = null)
    {
        input.ShouldBeLessThan(expected, customMessage: because);
        return new AndConstraint<NumericShould<T>>(this);
    }

    public AndConstraint<NumericShould<T>> BeLessThanOrEqualTo(T expected,
                                                               string? because = null)
    {
        input.ShouldBeLessThanOrEqualTo(expected, customMessage: because);
        return new AndConstraint<NumericShould<T>>(this);
    }
}
