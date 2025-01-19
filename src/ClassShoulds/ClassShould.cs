using Shouldly;
using ShouldlyFluentassertionsBridge.Constraints;

namespace ShouldlyFluentassertionsBridge.ClassShoulds;

public class ClassShould(object? input)
{
    public AndConstraint<ClassShould> Be(object? expected,
                                         string? because = null)
    {
        input.ShouldBe(expected,
                       because);
        return new AndConstraint<ClassShould>(this);
    }

    public AndConstraint<ClassShould> NotBe(object? expected,
                                            string? because = null)
    {
        input.ShouldNotBe(expected,
                          because);
        return new AndConstraint<ClassShould>(this);
    }

    public AndConstraint<ClassShould> BeOfType<TExpected>(string? because = null)
    {
        input.ShouldBeOfType<TExpected>(because);
        return new AndConstraint<ClassShould>(this);
    }

    public AndConstraint<ClassShould> NotBeOfType<TExpected>(string? because = null)
    {
        input.ShouldNotBeOfType<TExpected>(because);
        return new AndConstraint<ClassShould>(this);
    }

    public AndConstraint<ClassShould> BeNull(string? because = null)
    {
        input.ShouldBeNull(because);
        return new AndConstraint<ClassShould>(this);
    }

    public AndConstraint<ClassShould> NotBeNull(string? because = null)
    {
        input.ShouldNotBeNull(because);
        return new AndConstraint<ClassShould>(this);
    }
}
