using DotnetModules.Shared.Core;
using DotnetModules.Shared.DependentAC;

namespace DotnetModules.ModuleA;

public class Module : BaseModule
{
    public override Task Load()
    {
        Console.WriteLine(CrossFeature.GetCrossFeature());

        return base.Load();
    }
}