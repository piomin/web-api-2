using System.Reflection;
using Xunit;

namespace WebApi.Library.Tests;

public class VersionServiceTests
{
    private readonly VersionService _versionService;
    private const string ExpectedVersion = "1.0.3";

    public VersionServiceTests()
    {
        _versionService = new VersionService();
    }

    [Fact]
    public void GetVersion_Test()
    {
        // Act
        var version = _versionService.GetVersion();

        // Assert
        Assert.NotNull(version);
        Assert.NotEmpty(version);
        // It should start with the version from the project file (1.0.0)
        Assert.StartsWith(ExpectedVersion, version);
    }
}
