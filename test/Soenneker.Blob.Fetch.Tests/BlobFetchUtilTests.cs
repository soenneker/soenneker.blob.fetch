using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Blob.Fetch.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Blob.Fetch.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class BlobFetchUtilTests : HostedUnitTest
{
    private readonly IBlobFetchUtil _util;

    public BlobFetchUtilTests(Host host) : base(host)
    {
        _util = Resolve<IBlobFetchUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
