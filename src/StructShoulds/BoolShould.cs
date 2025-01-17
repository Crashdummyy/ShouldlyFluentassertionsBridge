using Shouldly;

namespace ShouldlyFluentassertionsBridge.StructShoulds;

public class BoolShould(bool? input) : StructShould<bool>(input ?? false)
{
    public void BeFalse(string? because = null)
    {
        if (input == null)
        {
            throw new ShouldAssertException(new ExpectedShouldlyMessage(input,
                                                                        because).ToString());
        }

        Be(false,
           because);
    }

    public void BeTrue(string? because = null)
    {
        if (input == null)
        {
            throw new ShouldAssertException(new ExpectedShouldlyMessage(input,
                                                                        because).ToString());
        }

        Be(true,
           because);
    }

    public void BeNull(string? because = null) => input.ShouldBeNull(because);
    public void NotBeNull(string? because = null) => input.ShouldNotBeNull(because);
}
