using Shouldly;
using ShouldlyFluentassertionsBridge.Constraints;

namespace ShouldlyFluentassertionsBridge.ClassShoulds;

#pragma warning disable CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
public class StringShould(string? input)
#pragma warning restore CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
{
    public AndConstraint<StringShould> Be(string? expected,
                                          StringCompareShould stringCompareShould,
                                          string? because = null)
    {
        input.ShouldBe(expected, customMessage: because, options: stringCompareShould);
        return new AndConstraint<StringShould>(this);
    }
    public AndConstraint<StringShould> Be(string? expected,
                                          string? because = null)
    {
        input.ShouldBe(expected, customMessage: because);
        return new AndConstraint<StringShould>(this);
    }
    public AndConstraint<StringShould> Be(string? expected,
                                          IEqualityComparer<string> comparer,
                                          string? because = null)
    {
        input.ShouldBe(expected, comparer, customMessage: because);
        return new AndConstraint<StringShould>(this);
    }

    public AndConstraint<StringShould> BeEquivalentTo(string? expected,
                                                      string? because = null)
    {
        input.ShouldBeEquivalentTo(expected,
                                   customMessage: because);
        return new AndConstraint<StringShould>(this);
    }

    public AndConstraint<StringShould> NotBeEquivalentTo(string? expected,
                                                         string? because = null)
    {
        if (input == null && expected != null)
            return new AndConstraint<StringShould>(this);


        if (input != null && expected == null)
            return new AndConstraint<StringShould>(this);


        return input?.CompareTo(expected) != 0
            ? new AndConstraint<StringShould>(this)
            : throw new ShouldAssertException($"Expected input not to be {expected} {Formatter.Because(because)}");

    }

    public AndConstraint<StringShould> Contain(string expected,
                                               string? because = null,
                                               Case caseSensitivity = Case.Insensitive)
    {
        Guard.AssertNotNull(input,
                            because);

        input!.ShouldContain(expected,
                             caseSensitivity: caseSensitivity,
                             customMessage: because);
        return new AndConstraint<StringShould>(this);
    }

    public AndConstraint<StringShould> NotContain(string expected,
                                                  string? because = null,
                                                  Case caseSensitivity = Case.Insensitive)
    {
        Guard.AssertNotNull(input,
                            because);

        input!.ShouldNotContain(expected,
                                caseSensitivity: caseSensitivity,
                                customMessage: because);
        return new AndConstraint<StringShould>(this);
    }

    public AndConstraint<StringShould> StartWith(string expected,
                                                 string? because = null,
                                                 Case caseSensitivity = Case.Insensitive)
    {
        Guard.AssertNotNull(input,
                            because);

        input!.ShouldStartWith(expected,
                               caseSensitivity: caseSensitivity,
                               customMessage: because);
        return new AndConstraint<StringShould>(this);
    }

    public AndConstraint<StringShould> NotStartWith(string expected,
                                                    string? because = null,
                                                    Case caseSensitivity = Case.Insensitive)
    {
        Guard.AssertNotNull(input,
                            because);

        input!.ShouldNotStartWith(expected,
                                  caseSensitivity: caseSensitivity,
                                  customMessage: because);
        return new AndConstraint<StringShould>(this);
    }

    public AndConstraint<StringShould> EndWith(string expected,
                                               string? because = null,
                                               Case caseSensitivity = Case.Insensitive)
    {
        Guard.AssertNotNull(input,
                            because);

        input.ShouldEndWith(expected,
                            caseSensitivity,
                            customMessage: because);

        return new AndConstraint<StringShould>(this);
    }

    public AndConstraint<StringShould> NotEndWith(string expected,
                                                  string? because = null,
                                                  Case caseSensitivity = Case.Insensitive)
    {
        Guard.AssertNotNull(input,
                            because);
        input.ShouldNotEndWith(expected,
                               customMessage: because,
                               caseSensitivity: caseSensitivity);
        return new AndConstraint<StringShould>(this);
    }


    public AndConstraint<StringShould> BeEmpty(string? because = null)
    {
        Guard.AssertNotNull(input, because);
        input.ShouldBeEmpty(customMessage: because);
        return new AndConstraint<StringShould>(this);
    }


    public AndConstraint<StringShould> NotBeEmpty(string? because = null)
    {
        Guard.AssertNotNull(input, because);
        input.ShouldNotBeEmpty(customMessage: because);
        return new AndConstraint<StringShould>(this);
    }

    public AndConstraint<StringShould> BeNullOrEmpty(string? because = null)
    {
        input.ShouldBeNullOrEmpty(customMessage: because);
        return new AndConstraint<StringShould>(this);
    }

    public AndConstraint<StringShould> NotBeNullOrEmpty(string? because = null)
    {
        input.ShouldNotBeNullOrEmpty(customMessage: because);
        return new AndConstraint<StringShould>(this);
    }
    public AndConstraint<StringShould> BeNullOrWhitespace(string? because = null)
    {
        input.ShouldBeNullOrWhiteSpace(customMessage: because);
        return new AndConstraint<StringShould>(this);
    }

    public AndConstraint<StringShould> NotBeNullOrWhitespace(string? because = null)
    {
        input.ShouldNotBeNullOrWhiteSpace(customMessage: because);
        return new AndConstraint<StringShould>(this);
    }
}
