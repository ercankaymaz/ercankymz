using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSUtilities;

internal static class AppDomainUtils
{
	public static IEnumerable<Type> GetTypesOfInterface<T>()
	{
		return from p in AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly s) => s.GetTypes())
			where p.GetInterface(typeof(T).FullName) != null
			select p;
	}

	public static IEnumerable<Type> GetTypesWithAttribute<T>() where T : Attribute
	{
		return from p in AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly s) => s.GetTypes())
			where p.GetCustomAttribute<T>() != null
			select p;
	}
}
