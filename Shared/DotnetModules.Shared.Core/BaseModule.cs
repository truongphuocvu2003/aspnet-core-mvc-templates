using System.Reflection;

namespace DotnetModules.Shared.Core;
public abstract class BaseModule : IModule 
{
    public virtual Task Load()
    {
        Console.WriteLine($"Load module from: {Assembly.GetCallingAssembly().FullName}");
        return Task.CompletedTask;
    }

    public virtual Task Execute()
    {
        return Task.CompletedTask;
    } 
}