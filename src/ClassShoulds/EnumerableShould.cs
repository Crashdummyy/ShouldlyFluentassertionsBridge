using System.Linq.Expressions;
using System.Text;
using Shouldly;
using ShouldlyFluentassertionsBridge.Constraints;

namespace ShouldlyFluentassertionsBridge.ClassShoulds;

public class EnumerableShould<T>(IEnumerable<T?>? input)
{
    public AndConstraint<EnumerableShould<T>> Be(IEnumerable<T?>? expected,
                                                 string? because = null)
    {
        if (input == null && expected == null)
            return new AndConstraint<EnumerableShould<T>>(this);

        Guard.AssertNotNull(input,
                            because);

        input.ShouldBe(expected,
                       because);

        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> BeNull(string? because = null)
    {
        input.ShouldBeNull(because);

        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> NotBeNull(string? because = null)
    {
        input.ShouldNotBeNull(because);

        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> BeEmpty(string? because = null)
    {
        Guard.AssertNotNull(input,
                            because);
        input.ShouldBeEmpty(because);

        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> NotBeEmpty(string? because = null)
    {
        Guard.AssertNotNull(input,
                            because);
        input.ShouldNotBeEmpty(because);

        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> HaveCount(int actual,
                                                        string? because = null)
    {
        Guard.AssertNotNull(input,
                            because);
        input!.Count().ShouldBe(actual,
                                because);
        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> AllSatisfy(Action<T?> expected,
                                                         string because = "",
                                                         params object[] becauseArgs)
    {
        Guard.AssertNotNull(input,
                            because);

        var errors = new List<string>(input!.Count());
        foreach (var item in input!)
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
                string.Format(because,
                              becauseArgs)
            ).ToString()
        );
    }

    public AndConstraint<EnumerableShould<T>> HaveCountGreaterOrEqualTo(int expected,
                                                                        string? because = null)
    {
        Guard.AssertNotNull(input,
                            because);

        input!.Count().ShouldBeGreaterThanOrEqualTo(expected,
                                                    because);
        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> Contain(T expected,
                                                      string? because = null)
    {
        Guard.AssertNotNull(input);
        input!.ShouldContain(expected,
                             customMessage: because);
        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> Contain(IEnumerable<T> expected,
                                                      string? because = null)
    {
        Guard.AssertNotNull(input,
                            because);
        
        var expectedList = expected as IList<T> ?? expected!.ToList()!;
        var inputList = input as IList<T> ?? input?.ToList()!;
        var missingEntries = new List<T>();
        foreach (var element in expectedList)
        {
            try
            {
                inputList.ShouldContain(element);
                return new AndConstraint<EnumerableShould<T>>(this);
            }
            catch (ShouldAssertException)
            {
                missingEntries.Add(element);
            }
        }

        throw new ShouldAssertException($"Expected {inputList.Format()} to contain {missingEntries.Format()} but they are missing");
    }

    public AndConstraint<EnumerableShould<T>> Contain(params T[] expected) => Contain(expected,
                                                                                      null);
    
    public AndConstraint<EnumerableShould<T>> NotContain(T expected,
                                                         string? because = null)
    {
        Guard.AssertNotNull(input);
        input!.ShouldNotContain(expected,
                                customMessage: because);
        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> Contain(Expression<Func<T, bool>> elementPredicate,
                                                      string? because = null,
                                                      int? numberOfTimes = null)
    {
        Guard.AssertNotNull(input,
                            because);

        if (numberOfTimes == null)
        {
            input!.ShouldContain(elementPredicate, 
                                 customMessage: because);
        }
        else
        {
            input!.ShouldContain(elementPredicate,
                                 expectedCount: numberOfTimes.Value,
                                 customMessage: because);    
        }
        

        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> NotContain(Expression<Func<T, bool>> elementPredicate,
                                                         string? because = null)
    {
        Guard.AssertNotNull(input,
                            because);

        input!.ShouldNotContain(elementPredicate,
                                because);

        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> ContainEquivalentOf(T expected,
                                                                  string? because = null)
    {
        Guard.AssertNotNull(input,
                            because);

        foreach (var element in input!)
        {
            try
            {
                element.ShouldBeEquivalentTo(expected,
                                             customMessage: because);

                return new AndConstraint<EnumerableShould<T>>(this);
            }
            catch (ShouldAssertException)
            {
                // Can be ignored
            }
        }

        throw new ShouldAssertException($"Expected {input.Format()} to contain {expected.Format()} but it was nowhere to be found");
    }

    public AndConstraint<EnumerableShould<T>> ContainSingle(Expression<Func<T, bool>> predicate,
                                                            string? because = null)
    {
        return ContainsNumberOfTimes(predicate,
                                     expectedCount: 1,
                                     because);
    }

    public AndConstraint<EnumerableShould<T>> ContainInOrder(params T?[] expected) =>
        ContainInOrder(expected,
                       string.Empty);

    public AndConstraint<EnumerableShould<T>> ContainInOrder(IEnumerable<T?> expected,
                                                             string? because)
    {
        Guard.AssertNotNull(input,
                            because);

        var expectedList = expected as IList<T> ?? expected!.ToList()!;
        var actualList = input as IList<T> ?? input!.ToList()!;

        for (var index = 0; index < expectedList.Count; index++)
        {
            var actual = actualList.ElementAtOrDefault(index);
            var expectedEntry = expectedList[index];
            try
            {
                actual.ShouldBeEquivalentTo(expectedEntry,
                                            because);
            }
            catch (ShouldAssertException e)
            {
                throw new ShouldAssertException($"Expected {expectedEntry.Format()} at ({index}) but found {actual.Format()}",
                                                e);
            }
        }

        return new AndConstraint<EnumerableShould<T>>(this);
    }

    public AndConstraint<EnumerableShould<T>> HaveCountLessOrEqualTo(int expected,
                                                                     string? because = null)
    {
        Guard.AssertNotNull(input,
                            because);
        input!.Count().ShouldBeLessThanOrEqualTo(expected,
                                                 because);

        return new AndConstraint<EnumerableShould<T>>(this);
    }
    
    public AndConstraint<EnumerableShould<T>> HaveCountGreaterThan(int expected,
                                                                   string? because = null)
    {
        Guard.AssertNotNull(input);
        
        input!.Count().ShouldBeGreaterThan(expected);

        return new AndConstraint<EnumerableShould<T>>(this);
    }


    private AndConstraint<EnumerableShould<T>> ContainsNumberOfTimes(Expression<Func<T, bool>> predicate,
                                                                     int expectedCount,
                                                                     string? because)
    {
        Guard.AssertNotNull(input,
                            because);
        input!.ShouldContain(predicate,
                             expectedCount,
                             because);
        return new AndConstraint<EnumerableShould<T>>(this);
    }
}
