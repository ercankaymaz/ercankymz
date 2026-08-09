using System.Collections.Generic;
using System.Reflection;

internal static class _0023_003DzNZ_0024uM70jeHx_JDltqynA34ap8NXo
{
	private static readonly Assembly _0023_003DzH9VU2k0_003D;

	static _0023_003DzNZ_0024uM70jeHx_JDltqynA34ap8NXo()
	{
		_0023_003DzH9VU2k0_003D = typeof(_0023_003DzNZ_0024uM70jeHx_JDltqynA34ap8NXo).Assembly;
	}

	internal static AssemblyName[] _0023_003DzE8QrneA_003D(Assembly _0023_003Dz7qHuqPLesOR8PnJMTsnX9dELdqBFqc4_Pw_003D_003D)
	{
		AssemblyName[] referencedAssemblies = _0023_003Dz7qHuqPLesOR8PnJMTsnX9dELdqBFqc4_Pw_003D_003D.GetReferencedAssemblies();
		if ((object)_0023_003Dz7qHuqPLesOR8PnJMTsnX9dELdqBFqc4_Pw_003D_003D != _0023_003DzH9VU2k0_003D)
		{
			return referencedAssemblies;
		}
		string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748005);
		string[] array = text.Split('|');
		List<string> list = new List<string>(referencedAssemblies.Length + array.Length);
		string[] array2 = array;
		foreach (string item in array2)
		{
			list.Add(item);
		}
		AssemblyName[] array3 = referencedAssemblies;
		foreach (AssemblyName assemblyName in array3)
		{
			string fullName = assemblyName.FullName;
			if (!list.Contains(fullName))
			{
				list.Add(fullName);
			}
		}
		int count = list.Count;
		AssemblyName[] array4 = new AssemblyName[count];
		for (int k = 0; k != count; k++)
		{
			array4[k] = new AssemblyName(list[k]);
		}
		return array4;
	}
}
