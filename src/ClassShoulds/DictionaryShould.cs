using Shouldly;
using ShouldlyFluentassertionsBridge.Constraints;

namespace ShouldlyFluentassertionsBridge.ClassShoulds;

public class DictionaryShould<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>>? input)
    : EnumerableShould<KeyValuePair<TKey, TValue>>(input)
{
  public AndConstraint<DictionaryShould<TKey, TValue>> ContainValue(
      TValue expected,
      string? because = null
  )
  {
    Guard.AssertNotNull(input, because);
    var expectedIsNull = expected == null;
    foreach (var value in input!)
    {
      if (value.Value?.Equals(expected) ?? expectedIsNull)
        return new AndConstraint<DictionaryShould<TKey, TValue>>(this);
    }

    throw new ShouldAssertException(
        $"Expected {Formatter.Format(input)} to contain {Formatter.Format(expected)} {Formatter.Because(because)}"
    );
  }

  public AndConstraint<DictionaryShould<TKey, TValue>> NotContainValue(
      TValue expected,
      string? because = null
  )
  {
    Guard.AssertNotNull(input, because);
    var expectedIsNull = expected == null;
    foreach (var value in input!)
    {
      if (value.Value?.Equals(expected) ?? expectedIsNull)
        throw new ShouldAssertException(
            $"Expected {Formatter.Format(input)} not to contain {Formatter.Format(expected)} {Formatter.Because(because)}"
        );
      return new AndConstraint<DictionaryShould<TKey, TValue>>(this);
    }

    return new AndConstraint<DictionaryShould<TKey, TValue>>(this);
  }

  public AndConstraint<DictionaryShould<TKey, TValue>> ContainKey(
      TValue expected,
      string? because = null
  )
  {
    Guard.AssertNotNull(input, because);
    var expectedIsNull = expected == null;
    foreach (var value in input!)
    {
      if (value.Key?.Equals(expected) ?? expectedIsNull)
        return new AndConstraint<DictionaryShould<TKey, TValue>>(this);
    }

    throw new ShouldAssertException(
        $"Expected {Formatter.Format(input)} to contain {Formatter.Format(expected)} {Formatter.Because(because)}"
    );
  }

  public AndConstraint<DictionaryShould<TKey, TValue>> NotContainKey(
      TValue expected,
      string? because = null
  )
  {
    Guard.AssertNotNull(input, because);
    var expectedIsNull = expected == null;
    foreach (var value in input!)
    {
      if (value.Key?.Equals(expected) ?? expectedIsNull)
        throw new ShouldAssertException(
            $"Expected {Formatter.Format(input)} not to contain {Formatter.Format(expected)} {Formatter.Because(because)}"
        );
      return new AndConstraint<DictionaryShould<TKey, TValue>>(this);
    }

    return new AndConstraint<DictionaryShould<TKey, TValue>>(this);
  }
}
