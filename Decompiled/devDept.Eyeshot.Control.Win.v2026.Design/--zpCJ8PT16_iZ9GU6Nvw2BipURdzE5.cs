using System.Collections.Generic;
using System.Reflection;

internal static class _0023_003DzpCJ8PT16_iZ9GU6Nvw2BipURdzE5
{
	private static readonly Assembly _0023_003Dzn0mbPio_003D;

	static _0023_003DzpCJ8PT16_iZ9GU6Nvw2BipURdzE5()
	{
		_0023_003Dzn0mbPio_003D = typeof(_0023_003DzpCJ8PT16_iZ9GU6Nvw2BipURdzE5).Assembly;
	}

	internal static AssemblyName[] _0023_003Dznx1EMIs_003D(Assembly _0023_003DzYFHt4lYUw1oel7oRm0R6NSM5YuR0tQ7_0024zQ_003D_003D)
	{
		AssemblyName[] referencedAssemblies = _0023_003DzYFHt4lYUw1oel7oRm0R6NSM5YuR0tQ7_0024zQ_003D_003D.GetReferencedAssemblies();
		if ((object)_0023_003DzYFHt4lYUw1oel7oRm0R6NSM5YuR0tQ7_0024zQ_003D_003D != _0023_003Dzn0mbPio_003D)
		{
			return referencedAssemblies;
		}
		string text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316248);
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
