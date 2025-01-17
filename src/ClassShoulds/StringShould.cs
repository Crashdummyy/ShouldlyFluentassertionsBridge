using Shouldly;

namespace ShouldlyFluentassertionsBridge.ClassShoulds;

#pragma warning disable CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
public class StringShould(string? input) : ClassShould<string>(input)
#pragma warning restore CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
{
    public void Contain(string expected,
                        string? because = null)
    {
        if (input == null)
        {
            throw new ShouldAssertException(new ExpectedShouldlyMessage(input,
                                                                        because).ToString());
        }

        input.ShouldContain(expected);
    }

    public void StartWith(string expected,
                          string? because = null)
    {
        if (input == null)
        {
            throw new ShouldAssertException(new ExpectedShouldlyMessage(input,
                                                                        because).ToString());
        }

        input.ShouldContain(expected);
    }
}
