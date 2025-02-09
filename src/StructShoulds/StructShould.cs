using Shouldly;
using ShouldlyFluentassertionsBridge.Constraints;

namespace ShouldlyFluentassertionsBridge.StructShoulds;

public class StructShould<T>(T input)
    where T : struct
{
    public AndConstraint<StructShould<T>> Be(T expected,
                                             string? because = null)
    {
        input.ShouldBe(expected,
                       because);
        return new AndConstraint<StructShould<T>>(this);
    }

    public AndConstraint<StructShould<T>> NotBe(T expected,
                                                string? because = null)
    {
        input.ShouldNotBe(expected,
                          because);
        return new AndConstraint<StructShould<T>>(this);
    }
}
