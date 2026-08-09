using System.Collections.Generic;

namespace UglyToad.PdfPig.Geometry.ClipperLibrary;

internal class ClipperPolyTree : ClipperPolyNode
{
	internal List<ClipperPolyNode> AllPolys = new List<ClipperPolyNode>();

	public int Total
	{
		get
		{
			int num = AllPolys.Count;
			if (num > 0 && Children[0] != AllPolys[0])
			{
				num--;
			}
			return num;
		}
	}

	public void Clear()
	{
		for (int i = 0; i < AllPolys.Count; i++)
		{
			AllPolys[i] = null;
		}
		AllPolys.Clear();
		Children.Clear();
	}

	public ClipperPolyNode GetFirst()
	{
		if (Children.Count > 0)
		{
			return Children[0];
		}
		return null;
	}
}
