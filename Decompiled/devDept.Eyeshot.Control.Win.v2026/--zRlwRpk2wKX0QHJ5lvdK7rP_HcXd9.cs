using System.Collections.Generic;
using System.Reflection;

internal static class _0023_003DzRlwRpk2wKX0QHJ5lvdK7rP_HcXd9
{
	private static readonly Assembly _0023_003DzFrc_0024oLQ_003D;

	static _0023_003DzRlwRpk2wKX0QHJ5lvdK7rP_HcXd9()
	{
		_0023_003DzFrc_0024oLQ_003D = typeof(_0023_003DzRlwRpk2wKX0QHJ5lvdK7rP_HcXd9).Assembly;
	}

	internal static AssemblyName[] _0023_003DzDw__wI8_003D(Assembly _0023_003DznZpjxs6XgmnvEaZcoQf7vODk_0024oK653_fzQ_003D_003D)
	{
		AssemblyName[] referencedAssemblies = _0023_003DznZpjxs6XgmnvEaZcoQf7vODk_0024oK653_fzQ_003D_003D.GetReferencedAssemblies();
		if ((object)_0023_003DznZpjxs6XgmnvEaZcoQf7vODk_0024oK653_fzQ_003D_003D != _0023_003DzFrc_0024oLQ_003D)
		{
			return referencedAssemblies;
		}
		string text = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348614492);
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
