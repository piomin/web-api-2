using System.Reflection;
using System.Runtime.Versioning;

namespace library_api.Services;

/// <summary>
/// Service that provides version information about the application.
/// </summary>
public class VersionService : IVersionService
{
    /// <inheritdoc/>
    public string GetVersion()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        return versionAttribute?.InformationalVersion ?? "1.0.0";
    }
}
