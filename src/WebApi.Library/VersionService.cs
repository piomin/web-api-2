using System.Reflection;

namespace WebApi.Library;

public class VersionService
{
    private readonly Assembly _assembly;

    public VersionService(Assembly? assembly = null)
    {
        _assembly = assembly ?? Assembly.GetExecutingAssembly();
    }

    public string? GetVersion()
    {
        var informationalVersion = _assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
            .InformationalVersion;

        return informationalVersion ?? _assembly.GetName().Version?.ToString();
    }
}
