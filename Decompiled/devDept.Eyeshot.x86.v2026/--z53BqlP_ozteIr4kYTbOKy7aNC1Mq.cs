using System.Collections.Generic;
using System.Reflection;

internal static class _0023_003Dz53BqlP_ozteIr4kYTbOKy7aNC1Mq
{
	private static readonly Assembly _0023_003DzpDG_0024bAk_003D;

	static _0023_003Dz53BqlP_ozteIr4kYTbOKy7aNC1Mq()
	{
		_0023_003DzpDG_0024bAk_003D = typeof(_0023_003Dz53BqlP_ozteIr4kYTbOKy7aNC1Mq).Assembly;
	}

	internal static AssemblyName[] _0023_003Dz4A3Alm0_003D(Assembly _0023_003DzLRuFTAWAqoR7AMUnrLNox43uEtXXshHxKg_003D_003D)
	{
		AssemblyName[] referencedAssemblies = _0023_003DzLRuFTAWAqoR7AMUnrLNox43uEtXXshHxKg_003D_003D.GetReferencedAssemblies();
		if ((object)_0023_003DzLRuFTAWAqoR7AMUnrLNox43uEtXXshHxKg_003D_003D != _0023_003DzpDG_0024bAk_003D)
		{
			return referencedAssemblies;
		}
		string text = _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355520046);
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
