using Xbim.Common.Geometry;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc;

public static class IIfcAxis2PlacementExtensions
{
	public static XbimMatrix3D ToMatrix3D(this IIfcAxis2Placement placement)
	{
		if (!(placement is IIfcAxis2Placement3D obj))
		{
			if (placement is IIfcAxis2Placement2D obj2)
			{
				return obj2.ToMatrix3D();
			}
			return XbimMatrix3D.Identity;
		}
		return obj.ToMatrix3D();
	}
}
