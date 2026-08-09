using System;
using System.Linq;
using System.Reflection;

namespace CSUtilities.Extensions;

internal static class ReflectionExtensions
{
	public static PropertyInfo GetPropertyByName(this Type type, string name)
	{
		return type.GetProperties().FirstOrDefault((PropertyInfo o) => o.Name == name);
	}

	public static bool HasInterface<T>(this Type type) where T : class
	{
		Type typeFromHandle = typeof(T);
		if (!typeFromHandle.IsInterface)
		{
			throw new ArgumentException("Generic type is not an interface");
		}
		return type.GetInterface(typeFromHandle.FullName) != null;
	}

	public static bool TryGetAttribute<T>(this MemberInfo member, out T attribute) where T : Attribute
	{
		attribute = member.GetCustomAttribute<T>();
		return attribute != null;
	}
}
