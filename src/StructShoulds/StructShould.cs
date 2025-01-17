using Shouldly;

namespace ShouldlyFluentassertionsBridge.StructShoulds;

public class StructShould<T>(T input)
    where T : struct
{
    public void Be(T expected,
                   string? because = null) =>
        input.ShouldBe(expected,
                       because);
}
