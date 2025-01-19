using Shouldly;
using ShouldlyFluentassertionsBridge.Constraints;

namespace ShouldlyFluentassertionsBridge.ClassShoulds;

public class HttpResponseMessageShould(HttpResponseMessage? input)
{
    public AndConstraint<HttpResponseMessageShould> BeSuccessful(string? because = null)
    {
        if (input is null)
            throw new ShouldAssertException($"Expected HttpStatusCode to be successful (2xx) because {because}, but HttpResponseMessage was <null>.");
        
        if (input!.IsSuccessStatusCode)
            return new AndConstraint<HttpResponseMessageShould>(this);

        throw new ShouldAssertException(
            $"Expected HttpStatusCode to be successful (2xx) because {because}, but HttpResponseMessage was {(int)input.StatusCode} ({input.StatusCode.ToString()}).");
    }
}
