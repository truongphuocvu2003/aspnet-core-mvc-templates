namespace DotnetModules.Shared.Core;
public interface IModule
{
    Task Load();
    Task Execute();
}
