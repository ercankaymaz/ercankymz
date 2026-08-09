using System.Collections.Concurrent;
using Xbim.Common.Geometry;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc;

public static class IIfcAxis2Placement3DExtensions
{
	public static XbimMatrix3D ToMatrix3D(this IIfcAxis2Placement3D obj, ConcurrentDictionary<int, object> maps = null)
	{
		if (maps == null)
		{
			return obj.ConvertAxis3D();
		}
		if (maps.TryGetValue(obj.EntityLabel, out var value))
		{
			return (XbimMatrix3D)value;
		}
		value = obj.ConvertAxis3D();
		maps.TryAdd(obj.EntityLabel, value);
		return (XbimMatrix3D)value;
	}

	private static XbimMatrix3D ConvertAxis3D(this IIfcAxis2Placement3D obj)
	{
		if (obj.RefDirection == null || obj.Axis == null)
		{
			return new XbimMatrix3D(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, obj.Location.X, obj.Location.Y, obj.Location.Z, 1.0);
		}
		XbimVector3D v = obj.Axis.XbimVector3D();
		v.Normalized();
		XbimVector3D v2 = obj.RefDirection.XbimVector3D();
		v2.Normalized();
		XbimVector3D xbimVector3D = XbimVector3D.CrossProduct(v, v2);
		xbimVector3D.Normalized();
		return new XbimMatrix3D(v2.X, v2.Y, v2.Z, 0.0, xbimVector3D.X, xbimVector3D.Y, xbimVector3D.Z, 0.0, v.X, v.Y, v.Z, 0.0, obj.Location.X, obj.Location.Y, obj.Location.Z, 1.0);
	}
}
