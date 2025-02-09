using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ShouldlyFluentassertionsBridge;

public static class Formatter
{
    internal static string Format<T>(this T? target)
    {
        if (target == null)
            return "<null>";

        var type = typeof(T);
        if (!type.IsClass)
            return target?.ToString() ?? string.Empty;

        var formatBuilder = new StringBuilder();
        formatBuilder.AppendLine($"--- {type.Name} ---");
        var propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        if (propertyInfos is not {Length: >= 1})
            return target?.ToString() ?? string.Empty;

        var padLength = propertyInfos.Max(x => x.Name.Length);
        foreach (var propertyInfo in propertyInfos)
            formatBuilder.AppendLine($"{propertyInfo.Name.PadRight(padLength, ' ')}: {propertyInfo.GetValue(target)}");

        formatBuilder.AppendLine("----------------------");
        return formatBuilder.ToString();
    }

    internal static string Format<T>(this IEnumerable<T?> target)
    {
        var list = target as IList<T?> ?? [.. target];
        if (list.Count <= 1)
            return Format(list);

        var formatBuilder = new StringBuilder();
        var type = typeof(T);

        formatBuilder.AppendLine($"--- {type.Name} ---");
        formatBuilder.AppendLine("[");
        var map = GetMap<T>();
        var padLength = map.Max(x => x.Key.Length);
        var index = 0;
        foreach (var element in list)
        {
            formatBuilder.AppendLine($"[{index}]:");
            if (element is null)
            {
                formatBuilder.AppendLine("<null>");
            }
            else
            {
                foreach (var pair in map)
                    formatBuilder.AppendLine($"    {pair.Key.PadRight(padLength, ' ')}: {pair.Value(element)}");
            }

            formatBuilder.AppendLine();
            index++;
        }
        formatBuilder.AppendLine("]");
        formatBuilder.AppendLine("----------------------");
        return formatBuilder.ToString();
    }

    internal static string Format<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> target)
    {

        if (target == null) return "null";

        var sb = new StringBuilder();
        sb.AppendLine("{");

        var keyFormatter = GetFormatter<TKey>();
        var valueFormatter = GetFormatter<TValue>();

        foreach (var kvp in target)
            sb.AppendLine($"  {keyFormatter(kvp.Key)}: {valueFormatter(kvp.Value)},");

        sb.Append('}');
        return sb.ToString();

        static Func<T, string> GetFormatter<T>()
        {
            var keyType = typeof(T);
            if (keyType.IsClass)
                return x => Format(x);
            if (typeof(IEnumerable).IsAssignableFrom(keyType) && keyType != typeof(string))
                return x => {
                    if (x is null)
                        return string.Empty;
                    else
                        return Format((IEnumerable<object?>)x);
                };

            return x => x?.ToString() ?? string.Empty;
        }
    }

    internal static string Because(string? because)
    {
        return string.IsNullOrWhiteSpace(because)
            ? string.Empty
            : $"because {because}";
    }

    private static Dictionary<string, Func<T, object?>> GetMap<T>()
    {
        var type = typeof(T);
        var map = new Dictionary<string, Func<T, object?>>();

        foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanRead))
        {
            var parameter = Expression.Parameter(type, "instance");

            var propertyExpression = Expression.Convert(Expression.Property(parameter,
                                                                            property),
                                                        typeof(object));

            map.Add(property.Name,
                    Expression.Lambda<Func<T, object?>>(propertyExpression, parameter).Compile());
        }

        return map;
    }
}
