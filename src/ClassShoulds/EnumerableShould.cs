using System.Text;
using Shouldly;

namespace ShouldlyFluentassertionsBridge.ClassShoulds;

public class EnumerableShould<T>(IEnumerable<T?>? input)
{
    public void Be(T? expected, string? because = null) => expected.ShouldBe(expected, because);

    public void HaveCount(int actual, string? because = null)
    {
        if (input == null)
            throw new ShouldAssertException(new ExpectedShouldlyMessage(input, because).ToString());

        input.Count().ShouldBe(actual, because);
    }

    public void AllSatisfy(Action<T?> expected, string because = "", params object[] becauseArgs)
    {
        if (input == null)
        {
            throw new ShouldAssertException(new ExpectedShouldlyMessage(input, because).ToString());
        }

        var errors = new List<string>(input.Count());
        foreach (var item in input)
        {
            try
            {
                expected(item);
            }
            catch (Exception e)
            {
                errors.Add(e.Message);
            }
        }

        if (errors.Count == 0)
            return;

        var errorBuilder = new StringBuilder();
        errorBuilder.AppendLine($"##### Errors: {errors.Count} #####");
        errors.ForEach(error => errorBuilder.AppendLine(error));
        errorBuilder.AppendLine();
        errorBuilder.AppendLine("------------------------------------");
        throw new ShouldAssertException(
            new ExpectedActualShouldlyMessage(
                errorBuilder.ToString(),
                input,
                string.Format(because, becauseArgs)
            ).ToString()
        );
    }

    public void HaveCountGreaterOrEqualTo(int expected, string because)
    {
        if (input == null)
        {
            throw new ShouldAssertException(new ExpectedShouldlyMessage(input, because).ToString());
        }

        input.Count().ShouldBeGreaterThanOrEqualTo(expected, because);
    }
}
