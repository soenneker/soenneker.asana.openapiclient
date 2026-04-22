using Soenneker.Tests.HostedUnit;

namespace Soenneker.Asana.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class AsanaOpenApiClientTests : HostedUnitTest
{
    public AsanaOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
