using Shouldly;
using ShouldlyFluentassertionsBridge.Constraints;

namespace ShouldlyFluentassertionsBridge.StructShoulds;

public class NumericShould<T>(T? input)
    where T : struct, IComparable<T>
{
    public AndConstraint<NumericShould<T>> BeGreaterThan(T expected, string? because = null)
    {
        Guard.AssertNotNull(input, because);
        input!.Value.ShouldBeGreaterThan(expected, customMessage: because);
        return new AndConstraint<NumericShould<T>>(this);
    }

    public AndConstraint<NumericShould<T>> BeGreaterOrEqualTo(T expected, string? because = null) =>
        BeGreaterThanOrEqualTo(expected, because);

    public AndConstraint<NumericShould<T>> BeGreaterThanOrEqualTo(
        T expected,
        string? because = null
    )
    {
        Guard.AssertNotNull(input, because);
        input!.Value.ShouldBeGreaterThanOrEqualTo(expected, customMessage: because);
        return new AndConstraint<NumericShould<T>>(this);
    }

    public AndConstraint<NumericShould<T>> BeLessThan(T expected, string? because = null)
    {
        Guard.AssertNotNull(input, because);
        input!.Value.ShouldBeLessThan(expected, customMessage: because);
        return new AndConstraint<NumericShould<T>>(this);
    }

    public AndConstraint<NumericShould<T>> BeLessThanOrEqualTo(T expected, string? because = null)
    {
        Guard.AssertNotNull(input, because);
        input!.Value.ShouldBeLessThanOrEqualTo(expected, customMessage: because);
        return new AndConstraint<NumericShould<T>>(this);
    }
    
    public AndConstraint<NumericShould<T>> Be(T expected,
                                              string? because = null)
    {
        input.ShouldBe(expected,
                       because);
        return new AndConstraint<NumericShould<T>>(this);
    }

    public AndConstraint<NumericShould<T>> NotBe(T expected,
                                                 string? because = null)
    {
        input.ShouldNotBe(expected,
                          because);
        return new AndConstraint<NumericShould<T>>(this);
    }
}
