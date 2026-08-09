using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class TriangleIndex
{
	public int V1 = 0;

	public int V2 = 0;

	public int V3 = 0;

	public TriangleIndex()
	{
	}

	public TriangleIndex(TriangleIndex index)
	{
		V1 = index.V1;
		V2 = index.V2;
		V3 = index.V3;
	}

	public TriangleIndex(int v1, int v2, int v3)
	{
		V1 = v1;
		V2 = v2;
		V3 = v3;
	}

	public static void Copy(List<TriangleIndex> pts, ref List<TriangleIndex> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new TriangleIndex(pts[i]));
		}
	}

	public override string ToString()
	{
		return "V1: " + V1 + " - V2: " + V2 + " - V3: " + V3;
	}
}
