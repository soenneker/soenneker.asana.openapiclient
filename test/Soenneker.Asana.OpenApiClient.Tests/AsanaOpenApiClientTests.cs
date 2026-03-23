using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Asana.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class AsanaOpenApiClientTests : FixturedUnitTest
{
    public AsanaOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
