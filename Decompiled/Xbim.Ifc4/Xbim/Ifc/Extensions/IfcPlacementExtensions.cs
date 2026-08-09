using System;
using Xbim.Common.Geometry;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc.Extensions;

public static class IfcPlacementExtensions
{
	public static double? Z(this IIfcObjectPlacement objPlacement)
	{
		if (!(objPlacement is IIfcLocalPlacement objPlacement2))
		{
			return null;
		}
		XbimMatrix3D xbimMatrix3D = objPlacement2.ToMatrix3D();
		XbimPoint3D p = new XbimPoint3D(0.0, 0.0, 0.0);
		return xbimMatrix3D.Transform(p).Z;
	}

	public static XbimMatrix3D ToMatrix3D(this IIfcObjectPlacement objPlacement)
	{
		if (objPlacement is IIfcLocalPlacement ifcLocalPlacement)
		{
			XbimMatrix3D xbimMatrix3D = ifcLocalPlacement.RelativePlacement.ToMatrix3D();
			if (ifcLocalPlacement.PlacementRelTo != null)
			{
				return xbimMatrix3D * ifcLocalPlacement.PlacementRelTo.ToMatrix3D();
			}
			return xbimMatrix3D;
		}
		throw new NotImplementedException("Placement of type " + objPlacement.GetType().Name + " is not implemented");
	}

	public static XbimMatrix3D ToMatrix3D(this IIfcAxis2Placement placement)
	{
		IIfcAxis2Placement3D obj = placement as IIfcAxis2Placement3D;
		IIfcAxis2Placement2D ifcAxis2Placement2D = placement as IIfcAxis2Placement2D;
		return obj?.ToMatrix3D() ?? ifcAxis2Placement2D?.ToMatrix3D() ?? XbimMatrix3D.Identity;
	}

	public static XbimMatrix3D ToMatrix3D(this IIfcPlacement placement)
	{
		IIfcAxis2Placement3D obj = placement as IIfcAxis2Placement3D;
		IIfcAxis2Placement2D ifcAxis2Placement2D = placement as IIfcAxis2Placement2D;
		return obj?.ToMatrix3D() ?? ifcAxis2Placement2D?.ToMatrix3D() ?? XbimMatrix3D.Identity;
	}

	public static XbimMatrix3D ToMatrix3D(this IIfcAxis2Placement3D axis3)
	{
		if (axis3.RefDirection != null && axis3.Axis != null)
		{
			XbimVector3D v = new XbimVector3D(axis3.Axis.X, axis3.Axis.Y, axis3.Axis.Z).Normalized();
			XbimVector3D v2 = new XbimVector3D(axis3.RefDirection.X, axis3.RefDirection.Y, axis3.RefDirection.Z).Normalized();
			XbimVector3D xbimVector3D = XbimVector3D.CrossProduct(v, v2).Normalized();
			return new XbimMatrix3D(v2.X, v2.Y, v2.Z, 0.0, xbimVector3D.X, xbimVector3D.Y, xbimVector3D.Z, 0.0, v.X, v.Y, v.Z, 0.0, axis3.Location.X, axis3.Location.Y, axis3.Location.Z, 1.0);
		}
		return new XbimMatrix3D(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, axis3.Location.X, axis3.Location.Y, axis3.Location.Z, 1.0);
	}

	public static XbimMatrix3D ToMatrix3D(this IIfcAxis2Placement2D axis2)
	{
		if (axis2.RefDirection != null)
		{
			XbimVector3D xbimVector3D = new XbimVector3D(axis2.RefDirection.X, axis2.RefDirection.Y, 0.0).Normalized();
			return new XbimMatrix3D(xbimVector3D.X, xbimVector3D.Y, 0.0, 0.0, xbimVector3D.Y, xbimVector3D.X, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, axis2.Location.X, axis2.Location.Y, 0.0, 1.0);
		}
		return new XbimMatrix3D(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, axis2.Location.X, axis2.Location.Y, axis2.Location.Z, 1.0);
	}
}
