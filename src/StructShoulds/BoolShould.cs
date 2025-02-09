using Shouldly;

namespace ShouldlyFluentassertionsBridge.StructShoulds;

public class BoolShould(bool? input) : StructShould<bool>(input ?? false)
{
    public void BeFalse(string? because = null)
    {
        Guard.AssertNotNull(input, because);
        Be(false,
           because);
    }

    public void BeTrue(string? because = null)
    {
        Guard.AssertNotNull(input, because);
        Be(true,
           because);
    }

    public void BeNull(string? because = null) => input.ShouldBeNull(customMessage: because);
    public void NotBeNull(string? because = null) => input.ShouldNotBeNull(customMessage: because);
}
