using System.Reflection;

namespace Drop_Scrapping.Helpers;

public static class TypesHelper
{
    /// <summary>
    /// Returns target types from all assemblies by current
    /// </summary>
    /// <param name="targetType"></param>
    /// <returns>List of types</returns>
    public static List<Type> GetTypesImplementingGenericInterface(Type targetType)
    {
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(p => p.GetInterfaces().Any(i => i.Name == targetType.Name))
            .ToList();
    }
}
