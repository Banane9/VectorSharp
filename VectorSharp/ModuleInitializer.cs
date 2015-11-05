using System.Linq;
using System.Reflection;
using VectorSharp.Generic;

/// <summary>
/// Used by the ModuleInit. All code inside the Initialize method is ran as soon as the assembly is loaded.
/// </summary>
public static class ModuleInitializer
{
    private static readonly MethodInfo addMethod = typeof(Vector3).GetTypeInfo().GetDeclaredMethod("AddSpecificType");

    /// <summary>
    /// Initializes the module.
    /// </summary>
    public static void Initialize()
    {
        var assembly = typeof(ModuleInitializer).GetTypeInfo().Assembly;

        var specificVector3s = assembly.DefinedTypes.Where(isVector3Derived);
        foreach (var type in specificVector3s)
        {
            var specificAddMethod = addMethod.MakeGenericMethod(type.AsType(), type.BaseType.GenericTypeArguments.First());
            specificAddMethod.Invoke(null, new object[0]);
        }
    }

    private static bool isVector3Derived(TypeInfo typeInfo)
    {
        return typeInfo.BaseType != null && typeInfo.BaseType.GenericTypeArguments != null && typeInfo.BaseType.GenericTypeArguments.Length == 1
            && typeInfo.BaseType == typeof(Vector3<>).MakeGenericType(typeInfo.BaseType.GenericTypeArguments.First());
    }
}