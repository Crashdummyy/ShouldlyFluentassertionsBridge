using Shouldly;

namespace ShouldlyFluentassertionsBridge;

public static class Guard
{
    public static void AssertNotNull<T>(T? input,
                                        string? because = null)
    {
        if (input != null)
            return;
        
        throw new ShouldAssertException(new ExpectedShouldlyMessage(input, because).ToString());
    }
}
