using Xbim.Common.Geometry;

namespace Xbim.Ifc2x3.GeometryResource;

public static class IfcAxis2PlacementExtensions
{
	public static XbimMatrix3D ToMatrix3D(this IfcAxis2Placement placement)
	{
		IfcAxis2Placement3D ifcAxis2Placement3D = placement as IfcAxis2Placement3D;
		IfcAxis2Placement2D ifcAxis2Placement2D = placement as IfcAxis2Placement2D;
		if (ifcAxis2Placement3D != null)
		{
			return ifcAxis2Placement3D.ToMatrix3D();
		}
		if (!(ifcAxis2Placement2D != null))
		{
			return XbimMatrix3D.Identity;
		}
		return ifcAxis2Placement2D.ToMatrix3D();
	}
}
