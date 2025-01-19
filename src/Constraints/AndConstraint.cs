namespace ShouldlyFluentassertionsBridge.Constraints;

public class AndConstraint<T>(T parentConstraint)
{
    public T And { get; } = parentConstraint;
}
