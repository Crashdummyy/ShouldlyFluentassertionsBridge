using Shouldly;
using ShouldlyFluentassertionsBridge.Constraints;

namespace ShouldlyFluentassertionsBridge.ClassShoulds;

public class ClassShould<T>(T? input)
    where T : class
{
    public AndConstraint<ClassShould<T>> Be(T? expected,
                                            string? because = null)
    {
        input.ShouldBe(expected,
                       because);
        return new AndConstraint<ClassShould<T>>(this);
    }

    public AndConstraint<ClassShould<T>> BeOfType<TExpected>()
    {
        input.ShouldBeOfType<TExpected>();
        return new AndConstraint<ClassShould<T>>(this);
    }

    public AndConstraint<ClassShould<T>> NotBeNull(string? because = null)
    {
        input.ShouldNotBeNull(because);
        return new AndConstraint<ClassShould<T>>(this);
    }
}
