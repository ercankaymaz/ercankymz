using System;
using System.Globalization;

namespace UglyToad.PdfPig.Geometry;

public readonly struct UserSpaceUnit
{
	public static readonly UserSpaceUnit Default = new UserSpaceUnit(1);

	public int PointMultiples { get; }

	internal UserSpaceUnit(int pointMultiples)
	{
		if (pointMultiples <= 0)
		{
			throw new ArgumentOutOfRangeException("Cannot have a zero or negative value of point multiples: " + pointMultiples);
		}
		PointMultiples = pointMultiples;
	}

	public override string ToString()
	{
		return PointMultiples.ToString(CultureInfo.InvariantCulture);
	}
}
