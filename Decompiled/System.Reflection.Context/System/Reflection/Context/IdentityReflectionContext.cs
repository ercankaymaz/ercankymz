namespace System.Reflection.Context;

internal sealed class IdentityReflectionContext : ReflectionContext
{
	public override Assembly MapAssembly(Assembly assembly)
	{
		return assembly;
	}

	public override TypeInfo MapType(TypeInfo type)
	{
		return type;
	}
}
