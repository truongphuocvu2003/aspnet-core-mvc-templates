using System.Reflection;

using DotnetModules.Shared.Core;

Console.WriteLine("Hello, this is DotnetModules project!");

// Load referenced modules
Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*module*.dll", SearchOption.TopDirectoryOnly)
   .Select(Assembly.LoadFrom)
   .ToList();

// Load plugin modules
var moduleFolders = AppDomain.CurrentDomain.BaseDirectory + "/modules";
if (Directory.Exists(moduleFolders))
    Directory.EnumerateFiles(moduleFolders, "*.dll", SearchOption.TopDirectoryOnly)
       .Select(Assembly.LoadFrom)
       .ToList();

var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
    .Where(assembly => assembly.FullName.ToLower().Contains("module"))
    .ToList();

var moduleBaseType = typeof(IModule);

var modules = loadedAssemblies.SelectMany(assembly => assembly.ExportedTypes
        .Where(t => !t.IsInterface && !t.IsAbstract && t.IsClass && t.IsAssignableTo(moduleBaseType))
    )
    .Select(type => (IModule)Activator.CreateInstance(type))
    .ToList();

Console.WriteLine($"""
        Modules: {modules.Count}
        Info:
            {string.Join('\n', modules.Select(r => r.GetType().Assembly.FullName))}
    """);

Console.WriteLine();
Console.WriteLine("Loading modules: ");

foreach (var module in modules)
{
    module.Load();
}

const string adminPassFirst = "Password";
const string adminPassSecond = "123";
const string addUserName = "superAdmin";

var firstUser = new UserEntity(addUserName, $"{adminPassFirst}@{adminPassSecond}");

public record UserEntity(string UserName, string Password);