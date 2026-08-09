using System.Collections.Generic;

namespace buCore.buClipperLib;

public class MyIntersectNodeSort : IComparer<IntersectNode>
{
	public int Compare(IntersectNode node1, IntersectNode node2)
	{
		long num = node2.intPoint_0.Y - node1.intPoint_0.Y;
		if (num <= 0L)
		{
			if (num >= 0L)
			{
				return 0;
			}
			return -1;
		}
		return 1;
	}
}
