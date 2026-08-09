using System.Collections.Concurrent;
using Xbim.Common.Geometry;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc;

public static class IIfcAxis2Placement2DExtensions
{
	public static XbimMatrix3D ToMatrix3D(this IIfcAxis2Placement2D obj, ConcurrentDictionary<int, object> maps = null)
	{
		if (maps != null && maps.TryGetValue(obj.EntityLabel, out var value))
		{
			return (XbimMatrix3D)value;
		}
		if (obj.RefDirection != null)
		{
			XbimVector3D xbimVector3D = obj.RefDirection.XbimVector3D();
			xbimVector3D.Normalized();
			value = new XbimMatrix3D(xbimVector3D.X, xbimVector3D.Y, 0.0, 0.0, xbimVector3D.Y, xbimVector3D.X, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, obj.Location.X, obj.Location.Y, 0.0, 1.0);
		}
		else
		{
			value = new XbimMatrix3D(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, obj.Location.X, obj.Location.Y, obj.Location.Z, 1.0);
		}
		maps?.TryAdd(obj.EntityLabel, value);
		return (XbimMatrix3D)value;
	}
}
