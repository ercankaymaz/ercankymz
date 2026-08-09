using System.Collections.Generic;

namespace UglyToad.PdfPig.Geometry.ClipperLibrary;

internal class ClipperIntersectNodeSort : IComparer<ClipperIntersectNode>
{
	public int Compare(ClipperIntersectNode node1, ClipperIntersectNode node2)
	{
		long num = node2.Pt.Y - node1.Pt.Y;
		if (num > 0)
		{
			return 1;
		}
		if (num >= 0)
		{
			return 0;
		}
		return -1;
	}
}
