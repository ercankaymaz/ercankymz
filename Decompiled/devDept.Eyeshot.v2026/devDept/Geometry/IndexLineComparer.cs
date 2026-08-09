using System.Collections.Generic;

namespace devDept.Geometry;

public class IndexLineComparer : IComparer<IndexLine>
{
	public int Compare(IndexLine l1, IndexLine l2)
	{
		if (l1.V1 < l2.V1)
		{
			return -1;
		}
		if (l1.V1 > l2.V1)
		{
			return 1;
		}
		if (l1.V2 < l2.V2)
		{
			return -1;
		}
		if (l1.V2 > l2.V2)
		{
			return 1;
		}
		return 0;
	}
}
