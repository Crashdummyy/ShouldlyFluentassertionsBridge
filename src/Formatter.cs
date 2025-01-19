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
        
        var formatBuilder = new StringBuilder();
        var type = typeof(T);
        formatBuilder.AppendLine($"--- {type.Name} ---");
        var propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var padLength = propertyInfos.Max(x => x.Name.Length);
        foreach (var propertyInfo in propertyInfos) 
            formatBuilder.AppendLine($"{propertyInfo.Name.PadRight(padLength, ' ')}: {propertyInfo.GetValue(target)}");
        
        formatBuilder.AppendLine("----------------------");
        return formatBuilder.ToString();
    }
    internal static string Format<T>(this IEnumerable<T?> target)
    {
        var list = target as IList<T?> ?? target.ToList();
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
