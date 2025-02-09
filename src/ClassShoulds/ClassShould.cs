using Shouldly;
using ShouldlyFluentassertionsBridge.Constraints;

namespace ShouldlyFluentassertionsBridge.ClassShoulds;

public class ClassShould(object? input)
{
    public AndConstraint<ClassShould> Be(object? expected,
                                         string? because = null)
    {
        input.ShouldBe(expected,
                       customMessage: because);
        return new AndConstraint<ClassShould>(this);
    }

    public AndConstraint<ClassShould> NotBe(object? expected,
                                            string? because = null)
    {
        input.ShouldNotBe(expected,
                          customMessage: because);
        return new AndConstraint<ClassShould>(this);
    }

    public AndConstraint<ClassShould> BeEquivalentTo(object? expected,
                                                     string? because = null)
    {
        Guard.AssertNotNull(input, because);
        input.ShouldBeEquivalentTo(expected,
                                   customMessage: because);
        return new AndConstraint<ClassShould>(this);
    }

    public AndConstraint<ClassShould> BeOfType<TExpected>(string? because = null)
    {
        input.ShouldBeOfType<TExpected>(customMessage: because);
        return new AndConstraint<ClassShould>(this);
    }

    public AndConstraint<ClassShould> NotBeOfType<TExpected>(string? because = null)
    {
        input.ShouldNotBeOfType<TExpected>(customMessage: because);
        return new AndConstraint<ClassShould>(this);
    }

    public AndConstraint<ClassShould> BeNull(string? because = null)
    {
        input.ShouldBeNull(customMessage: because);
        return new AndConstraint<ClassShould>(this);
    }

    public AndConstraint<ClassShould> NotBeNull(string? because = null)
    {
        input.ShouldNotBeNull(customMessage: because);
        return new AndConstraint<ClassShould>(this);
    }
}
