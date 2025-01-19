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
}
