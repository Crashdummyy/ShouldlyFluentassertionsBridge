using ShouldlyFluentassertionsBridge.ClassShoulds;
using ShouldlyFluentassertionsBridge.StructShoulds;

namespace ShouldlyFluentassertionsBridge;

public static class FluentAssertionBridge
{
    public static ClassShould<T> Should<T>(this T? input) where T : class => new(input);
    public static StringShould Should(this string? input) => new(input);
    public static EnumerableShould<T?> Should<T>(this IEnumerable<T>? input) where T : class => new(input);
    public static EnumerableShould<T?> Should<T>(this ICollection<T>? input) where T : class => new(input);
    public static EnumerableShould<T?> Should<T>(this T?[]? input) where T : class => new(input);
}

public static class StructFluentAssertionBridge
{
    public static StructShould<T> Should<T>(this T input) where T : struct => new(input);
    public static BoolShould Should(this bool? input) => new(input);
    public static BoolShould Should(this bool input) => new(input);
}
