using System.Diagnostics;

namespace ShouldlyFluentassertionsBridge.Constraints;

[DebuggerNonUserCode]
public class AndConstraint<T>(T parentConstraint)
{
    public T And { get; } = parentConstraint;
}
