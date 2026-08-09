using System.Collections.Generic;

namespace devDept.Eyeshot;

public class CirclePointComparer : IComparer<PointOnCircle>
{
	public int Compare(PointOnCircle a, PointOnCircle b)
	{
		if (a.Angle > b.Angle)
		{
			return 1;
		}
		if (a.Angle < b.Angle)
		{
			return -1;
		}
		return 0;
	}
}
