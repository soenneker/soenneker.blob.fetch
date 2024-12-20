using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Blob.Fetch.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.Blob.Fetch.Tests;

[Collection("Collection")]
public class BlobFetchUtilTests : FixturedUnitTest
{
    private readonly IBlobFetchUtil _util;

    public BlobFetchUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IBlobFetchUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
