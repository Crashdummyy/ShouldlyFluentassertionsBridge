using System.Diagnostics.Contracts;
using ShouldlyFluentassertionsBridge.ClassShoulds;
using ShouldlyFluentassertionsBridge.StructShoulds;

namespace ShouldlyFluentassertionsBridge;

public static class FluentAssertionBridge
{
    [Pure]
    public static ClassShould Should(this object? input) => new(input);

    [Pure]
    public static StringShould Should(this string? input) => new(input);

    [Pure]
    public static EnumerableShould<T?> Should<T>(this IEnumerable<T>? input) => new(input);
    
    [Pure]
    public static HttpResponseMessageShould Should(this HttpResponseMessage? input) => new(input);
}

public static class StructFluentAssertionBridge
{
    [Pure]
    public static StructShould<T> Should<T>(this T input) where T : struct => new(input);

    [Pure]
    public static BoolShould Should(this bool? input) => new(input);
    [Pure]
    public static BoolShould Should(this bool input) => new(input);
    
    [Pure]
    public static NumericShould<ulong> Should(this ulong input) => new(input);
    [Pure]
    public static NumericShould<ulong> Should(this ulong? input) => new(input);
    
    [Pure]
    public static NumericShould<long> Should(this long input) => new(input);
    [Pure]
    public static NumericShould<long> Should(this long? input) => new(input);
    
    [Pure]
    public static NumericShould<uint> Should(this uint input) => new(input);
    [Pure]
    public static NumericShould<uint> Should(this uint? input) => new(input);
    
    [Pure]
    public static NumericShould<int> Should(this int input) => new(input);
    [Pure]
    public static NumericShould<int> Should(this int? input) => new(input);
    
    [Pure]
    public static NumericShould<ushort> Should(this ushort input) => new(input);
    [Pure]
    public static NumericShould<ushort> Should(this ushort? input) => new(input);
    
    [Pure]
    public static NumericShould<short> Should(this short input) => new(input);
    [Pure]
    public static NumericShould<short> Should(this short? input) => new(input);
    
    [Pure]
    public static NumericShould<float> Should(this float input) => new(input);
    [Pure]
    public static NumericShould<float> Should(this float? input) => new(input);
    
    [Pure]
    public static NumericShould<double> Should(this double input) => new(input);
    [Pure]
    public static NumericShould<double> Should(this double? input) => new(input);
    
    [Pure]
    public static NumericShould<decimal> Should(this decimal input) => new(input);
    [Pure]
    public static NumericShould<decimal> Should(this decimal? input) => new(input);
}
