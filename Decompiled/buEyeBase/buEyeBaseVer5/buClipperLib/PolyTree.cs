using System.Collections.Generic;

namespace buEyeBaseVer5.buClipperLib;

public class PolyTree : PolyNode
{
	internal List<PolyNode> list_2 = new List<PolyNode>();

	public int Total
	{
		get
		{
			int num = list_2.Count;
			if (num > 0 && list_1[0] != list_2[0])
			{
				num--;
			}
			return num;
		}
	}

	public void Clear()
	{
		for (int i = 0; i < list_2.Count; i++)
		{
			list_2[i] = null;
		}
		list_2.Clear();
		list_1.Clear();
	}

	public PolyNode GetFirst()
	{
		if (list_1.Count <= 0)
		{
			return null;
		}
		return list_1[0];
	}
}
