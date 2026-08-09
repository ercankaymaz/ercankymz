using System.Collections.Generic;

namespace CSMath.Geometry;

public interface ICurve
{
	XYZ Center { get; }

	double RadiusRatio { get; }

	List<XYZ> PolygonalVertexes(int precision);

	XYZ PolarCoordinateRelativeToCenter(double angle);
}
