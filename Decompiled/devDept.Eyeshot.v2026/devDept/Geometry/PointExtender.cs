using devDept.Eyeshot.Entities;

namespace devDept.Geometry;

public static class PointExtender
{
	public static bool IsOnCurve(this Point3D point, ICurve curve, double maxGap)
	{
		Point3D closestPt;
		double closestParam;
		return point.IsOnCurve(curve, maxGap, out closestPt, out closestParam);
	}

	public static bool IsOnCurve(this Point3D point, ICurve curve, double maxGap, out Point3D closestPt, out double closestParam)
	{
		curve.ClosestPointTo(point, out closestParam);
		closestPt = curve.PointAt(closestParam);
		return Point3D.Distance(closestPt, point) < maxGap;
	}

	public static bool EqualsExact(this Point3D point, Point3D other)
	{
		if (point.X == other.X && point.Y == other.Y)
		{
			return point.Z == other.Z;
		}
		return false;
	}
}
