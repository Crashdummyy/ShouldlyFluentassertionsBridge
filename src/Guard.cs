using Shouldly;

namespace ShouldlyFluentassertionsBridge;

public static class Guard
{
    public static void AssertNotNull<T>(T? input,
                                        string? because = null)
    {
        if (input != null)
            return;

        throw new ShouldAssertException($"Expected input not to be <null> {Formatter.Because(because)}");
    }
}
