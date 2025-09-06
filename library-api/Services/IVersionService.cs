using System.Reflection;

namespace library_api.Services;

/// <summary>
/// Service that provides version information about the application.
/// </summary>
public interface IVersionService
{
    /// <summary>
    /// Gets the version of the application.
    /// </summary>
    /// <returns>A string representing the application version.</returns>
    string GetVersion();
}
