# ShouldlyFluentassertionsBridge

![NuGet Version](https://img.shields.io/nuget/v/Codepotatoes.ShouldlyFluentassertionsBridge)
[![](https://img.shields.io/nuget/dt/Codepotatoes.ShouldlyFluentassertionsBridge.svg?label=downloads&color=007edf&logo=nuget)](https://www.nuget.org/packages/Codepotatoes.ShouldlyFluentassertionsBridge)

Since FluentAssertions changed its license model in [this commit](https://github.com/fluentassertions/fluentassertions/commit/df7e9bf8305ef5e26ae58fe4142f8d1b6c4fc4af)  
a few of us might be inclined to change to [shouldly](https://github.com/shouldly/shouldly).

This is a work in project which should allow us to preserve FluentAssertions syntax
while channeling all into shouldly

## Caveats

As this thing is mostly a facade you're loosing some Qol features.
### Loose of variable name

Shouldly extracts your variableName from the stacktrace.
Due to this being a facade the variable is now always named "input"

```csharp
var text = "asdf";

// Shouldy
text.ShouldBe("ffff");

// error:
text
    should be
"ffff"
    but was
"asdf"

// FluentAssertionBrige
text.Should().Be("ffff");

// error
input
    should be
"ffff"
    but was
"asdf"
```
