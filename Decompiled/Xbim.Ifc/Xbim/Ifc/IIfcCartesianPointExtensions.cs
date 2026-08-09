using Xbim.Common.Geometry;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc;

public static class IIfcCartesianPointExtensions
{
	public static void SetXY(this IIfcCartesianPoint obj, double x, double y)
	{
		obj.Coordinates.Clear();
		obj.Coordinates.Add(x);
		obj.Coordinates.Add(y);
	}

	public static void SetXYZ(this IIfcCartesianPoint obj, double x, double y, double z)
	{
		obj.Coordinates.Clear();
		obj.Coordinates.Add(x);
		obj.Coordinates.Add(y);
		obj.Coordinates.Add(z);
	}

	public static XbimPoint3D ToXbimPoint3D(this IIfcCartesianPoint obj)
	{
		return new XbimPoint3D(obj.X, obj.Y, obj.Z);
	}

	public static bool IsEqual(this IIfcCartesianPoint obj, IIfcCartesianPoint p, double tolerance)
	{
		return obj.DistanceSquared(p) <= tolerance * tolerance;
	}

	public static double DistanceSquared(this IIfcCartesianPoint obj, IIfcCartesianPoint p)
	{
		obj.XYZ(out var x, out var y, out var z);
		p.XYZ(out var x2, out var y2, out var z2);
		double num = x;
		num -= x2;
		num *= num;
		double num2 = 0.0 + num;
		num = y;
		num -= y2;
		num *= num;
		double num3 = num2 + num;
		num = z;
		num -= z2;
		num *= num;
		return num3 + num;
	}

	public static void XYZ(this IIfcCartesianPoint obj, out double x, out double y, out double z)
	{
		if (obj.Dim == 3L)
		{
			x = obj.Coordinates[0];
			y = obj.Coordinates[1];
			z = obj.Coordinates[2];
		}
		else if (obj.Dim == 2L)
		{
			x = obj.Coordinates[0];
			y = obj.Coordinates[1];
			z = 0.0;
		}
		else
		{
			z = (y = (x = double.NaN));
		}
	}
}
