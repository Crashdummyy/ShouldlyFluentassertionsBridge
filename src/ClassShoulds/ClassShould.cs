using Shouldly;

namespace ShouldlyFluentassertionsBridge.ClassShoulds;

public class ClassShould<T>(T? input)
    where T : class?
{
    public void Be(T? expected,
                            string? because = null) =>
        input.ShouldBe(expected,
                       because);

    public void BeOfType<TExpected>() => input.ShouldBeOfType<TExpected>();
}
