using Xbim.Common.Geometry;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc;

public static class IIfcDirectionExtensions
{
	public static XbimVector3D XbimVector3D(this IIfcDirection obj)
	{
		return new XbimVector3D(obj.X, obj.Y, double.IsNaN(obj.Z) ? 0.0 : obj.Z);
	}

	public static XbimVector3D Normalise(this IIfcDirection obj)
	{
		if (obj.Dim == 3L)
		{
			XbimVector3D result = new XbimVector3D(obj.X, obj.Y, obj.Z);
			result.Normalized();
			return result;
		}
		double num = obj.X;
		double num2 = obj.Y;
		double num3 = obj.Z;
		if (double.IsNaN(num))
		{
			num = 0.0;
		}
		if (double.IsNaN(num2))
		{
			num2 = 0.0;
		}
		if (double.IsNaN(num3))
		{
			num3 = 0.0;
		}
		XbimVector3D result2 = new XbimVector3D(num, num2, num3);
		result2.Normalized();
		return result2;
	}

	public static void SetXY(this IIfcDirection obj, double x, double y)
	{
		obj.DirectionRatios.Clear();
		obj.DirectionRatios.Add(x);
		obj.DirectionRatios.Add(y);
	}

	public static void SetXYZ(this IIfcDirection obj, double x, double y, double z)
	{
		obj.DirectionRatios.Clear();
		obj.DirectionRatios.Add(x);
		obj.DirectionRatios.Add(y);
		obj.DirectionRatios.Add(z);
	}
}
