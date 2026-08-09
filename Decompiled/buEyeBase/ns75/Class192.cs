using System;
using System.Linq;
using System.Reflection;

namespace ns75;

internal class Class192
{
	private static Assembly assembly_0;

	private static string[] string_0 = new string[0];

	internal static void smethod_0()
	{
		try
		{
			AppDomain.CurrentDomain.ResourceResolve += smethod_1;
		}
		catch
		{
		}
	}

	private static Assembly smethod_1(object object_0, ResolveEventArgs resolveEventArgs_0)
	{
		if (assembly_0 == null)
		{
			lock (string_0)
			{
				assembly_0 = Assembly.Load("{210d3bfb-114b-4570-adc9-ed088b655c46}, PublicKeyToken=3e56350693f7355e");
				if (assembly_0 != null)
				{
					string_0 = assembly_0.GetManifestResourceNames();
				}
			}
		}
		if (!string_0.Contains(resolveEventArgs_0.Name))
		{
			return null;
		}
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		if (!resolveEventArgs_0.RequestingAssembly.Equals(executingAssembly))
		{
			return null;
		}
		return assembly_0;
	}
}
