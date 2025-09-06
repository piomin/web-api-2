using System.Reflection;
using library_api.Services;
using Xunit;

namespace library_api.Tests.Services;

public class VersionServiceTests
{
    private readonly VersionService _versionService;
    private const string ExpectedVersion = "1.0.0";

    public VersionServiceTests()
    {
        _versionService = new VersionService();
    }

    [Fact]
    public void GetVersion_ReturnsVersionFromAssembly()
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
