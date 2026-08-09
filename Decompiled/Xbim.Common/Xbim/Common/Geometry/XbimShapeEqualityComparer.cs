using System.Collections.Generic;
using System.Linq;

namespace Xbim.Common.Geometry;

public class XbimShapeEqualityComparer : IEqualityComparer<XbimGeometryData>
{
	public bool Equals(XbimGeometryData x, XbimGeometryData y)
	{
		return x.ShapeData.SequenceEqual(y.ShapeData);
	}

	public int GetHashCode(XbimGeometryData obj)
	{
		return obj.ShapeData.Length;
	}
}
