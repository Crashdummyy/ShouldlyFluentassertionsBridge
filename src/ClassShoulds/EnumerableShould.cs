using System.Linq.Expressions;
using System.Text;
using Shouldly;
using ShouldlyFluentassertionsBridge.Constraints;

namespace ShouldlyFluentassertionsBridge.ClassShoulds;

public class EnumerableShould<T>(IEnumerable<T?>? input)
{
    public AndConstraint<EnumerableShould<T>> Be(T? expected, 
                                                 string? because = null)
    {
        expected.ShouldBe(expected,
                          because);
        
        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> HaveCount(int actual, 
                                                        string? because = null)
    {
        if (input == null)
            throw new ShouldAssertException(new ExpectedShouldlyMessage(input, because).ToString());

        input.Count().ShouldBe(actual, because);
        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> AllSatisfy(Action<T?> expected, 
                                                         string because = "", 
                                                         params object[] becauseArgs)
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
            return new AndConstraint<EnumerableShould<T>>(this);

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

    public AndConstraint<EnumerableShould<T>> HaveCountGreaterOrEqualTo(int expected, 
                                                                        string? because = null)
    {
        if (input == null)
        {
            throw new ShouldAssertException(new ExpectedShouldlyMessage(input, because).ToString());
        }

        input.Count().ShouldBeGreaterThanOrEqualTo(expected, because);
        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> ContainEquivalentOf(T expected,
                                                                  string? because = null)
    {
        if (input == null)
        {
            throw new ShouldAssertException(new ExpectedShouldlyMessage(input, because).ToString());
        }
        
        input.ShouldContain(expected, because);
        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> BeEmpty(string? because = null)
    {
        if (input == null)
            throw new ShouldAssertException(new ExpectedShouldlyMessage(input, because).ToString());

        input.ShouldBeEmpty(because);

        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> ContainSingle(Expression<Func<T, bool>> predicate,
                                                            string? because = null)
    {
        if (input == null)
            throw new ShouldAssertException(new ExpectedShouldlyMessage(input, because).ToString());
        
        input!.ShouldContain(predicate, 1, because);
        return new AndConstraint<EnumerableShould<T>>(this);
    }
}
