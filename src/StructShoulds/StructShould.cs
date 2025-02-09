using Shouldly;
using ShouldlyFluentassertionsBridge.Constraints;

namespace ShouldlyFluentassertionsBridge.StructShoulds;

public class StructShould<T>(T? input)
    where T: struct
{
    public AndConstraint<StructShould<T>> Be(T expected,
                                             string? because = null)
    {
        input.ShouldBe(expected,
                       customMessage: because);
        return new AndConstraint<StructShould<T>>(this);
    }

    public AndConstraint<StructShould<T>> NotBe(T expected,
                                                string? because = null)
    {
        input.ShouldNotBe(expected,
                          customMessage: because);
        return new AndConstraint<StructShould<T>>(this);
    }


    public AndConstraint<StructShould<T>> BeNull(string? because = null)
    {
        if (input == null)
            return new AndConstraint<StructShould<T>>(this);

        throw new ShouldAssertException(
            $"Expected {Formatter.Format(input)} to be <null> {Formatter.Because(because)}"
        );
    }

    public AndConstraint<StructShould<T>> NotBeNull(string? because = null)
    {
        Guard.AssertNotNull(input, because);
        return new AndConstraint<StructShould<T>>(this);
    }

    public AndConstraint<StructShould<T>> BeOneOf(params T?[] validValues) =>
        BeOneOf(validValues, null);

    public AndConstraint<StructShould<T>> BeOneOf(
        IEnumerable<T?> validValues,
        string? because = null
    )
    {
        input.ShouldBeOneOf(validValues?.ToArray() ?? [null], customMessage: because);
        return new AndConstraint<StructShould<T>>(this);
    }

    public AndConstraint<StructShould<T>> NotBeOneOf(params T?[] validValues) =>
        BeOneOf(validValues, null);

    public AndConstraint<StructShould<T>> NotBeOneOf(
        IEnumerable<T?> validValues,
        string? because = null
    )
    {
        input.ShouldNotBeOneOf(validValues?.ToArray() ?? [null], customMessage: because);
        return new AndConstraint<StructShould<T>>(this);
    }
}
