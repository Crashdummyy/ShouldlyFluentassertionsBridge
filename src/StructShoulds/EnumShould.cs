using ShouldlyFluentassertionsBridge.Constraints;
using Shouldly;
using Shouldly.ShouldlyExtensionMethods;

namespace ShouldlyFluentassertionsBridge.StructShoulds
{
  public class EnumShould(Enum input)
  {
    public AndConstraint<EnumShould> Be(Enum expected, string? because = null)
    {
      input.ShouldBe(expected, customMessage: because);
      return new AndConstraint<EnumShould>(this);
    }

    public AndConstraint<EnumShould> NotBe(Enum expected, string? because)
    {
      input.ShouldNotBe(expected, customMessage: because);
      return new AndConstraint<EnumShould>(this);
    }

    public AndConstraint<EnumShould> HaveFlag(Enum expected, string? because = null)
    {
      input.ShouldHaveFlag(expected, customMessage: because);
      return new AndConstraint<EnumShould>(this);
    }

    public AndConstraint<EnumShould> NotHaveFlag(Enum expected, string? because = null)
    {
      input.ShouldNotHaveFlag(expected, customMessage: because);
      return new AndConstraint<EnumShould>(this);
    }
  }
}
