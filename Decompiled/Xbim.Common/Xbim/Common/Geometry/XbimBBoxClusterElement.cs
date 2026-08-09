using System.Collections.Generic;

namespace Xbim.Common.Geometry;

public class XbimBBoxClusterElement
{
	public List<int> GeometryIds;

	public XbimRect3D Bound;

	public XbimBBoxClusterElement(int geomteryId, XbimRect3D bound)
	{
		GeometryIds = new List<int>(1) { geomteryId };
		Bound = bound;
	}

	public void Add(XbimBBoxClusterElement otherElement)
	{
		GeometryIds.AddRange(otherElement.GeometryIds);
		Bound.Union(otherElement.Bound);
	}
}
