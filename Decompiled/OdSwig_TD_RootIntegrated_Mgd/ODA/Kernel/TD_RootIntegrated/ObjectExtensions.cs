using System;
using System.Reflection;

namespace ODA.Kernel.TD_RootIntegrated;

internal static class ObjectExtensions
{
	public static T CastTo<T>(this object o)
	{
		return (T)o;
	}

	public static object CastToReflected(this object o, Type type)
	{
		MethodInfo method = typeof(ObjectExtensions).GetMethod("CastTo", BindingFlags.Static | BindingFlags.Public);
		Type[] typeArguments = new Type[1] { type };
		if (method == null)
		{
			return null;
		}
		MethodInfo methodInfo = method.MakeGenericMethod(typeArguments);
		if (methodInfo == null)
		{
			return null;
		}
		return methodInfo.Invoke(null, new object[1] { o });
	}
}
