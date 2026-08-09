using System;
using System.Collections.Generic;
using ACadSharp.Attributes;
using CSMath;
using CSMath.Geometry;

namespace ACadSharp.Entities;

[DxfName("ARC")]
[DxfSubClass("AcDbArc")]
public class Arc : Circle
{
	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 51 })]
	public double EndAngle { get; set; } = Math.PI;

	public override string ObjectName => "ARC";

	public override ObjectType ObjectType => ObjectType.ARC;

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 50 })]
	public double StartAngle { get; set; }

	public override string SubclassMarker => "AcDbArc";

	public double Sweep
	{
		get
		{
			double startAngle = StartAngle;
			double num = EndAngle;
			if (num < startAngle)
			{
				num += Math.PI * 2.0;
			}
			return startAngle - num;
		}
	}

	public Arc()
	{
	}

	public Arc(XYZ center, double radius, double start, double end)
	{
		base.Center = center;
		base.Radius = radius;
		StartAngle = start;
		EndAngle = end;
	}

	public Arc(XYZ center, XYZ start, XYZ end, XYZ normal)
	{
		base.Normal = normal;
		base.Center = center;
		base.Radius = center.DistanceFrom(start);
		double angle = XYZ.AxisX.GetAngle2(start - center, base.Normal);
		double angle2 = XYZ.AxisX.GetAngle2(end - center, base.Normal);
		if (angle2 < angle)
		{
			StartAngle = angle2;
			EndAngle = angle;
		}
		else
		{
			StartAngle = angle;
			EndAngle = angle2;
		}
	}

	public Arc(XYZ center, XYZ start, XYZ end)
		: this(center, start, end, XYZ.AxisZ)
	{
	}

	public static Arc CreateFromBulge(XY p1, XY p2, double bulge)
	{
		double radius;
		XY center = GetCenter(p1, p2, bulge, out radius);
		double angle;
		double angle2;
		if (bulge < 0.0)
		{
			angle = p2.Subtract(center).GetAngle();
			angle2 = p1.Subtract(center).GetAngle();
		}
		else
		{
			angle = p1.Subtract(center).GetAngle();
			angle2 = p2.Subtract(center).GetAngle();
		}
		return new Arc
		{
			Center = new XYZ(center.X, center.Y, 0.0),
			Radius = radius,
			StartAngle = angle,
			EndAngle = angle2
		};
	}

	public static XY GetCenter(XY start, XY end, double bulge)
	{
		double radius;
		return GetCenter(start, end, bulge, out radius);
	}

	public static XY GetCenter(XY start, XY end, double bulge, out double radius)
	{
		double num = 4.0 * Math.Atan(Math.Abs(bulge));
		double num2 = start.DistanceFrom(end) / 2.0;
		radius = num2 / Math.Sin(num / 2.0);
		double num3 = (Math.PI - num) / 2.0;
		double value = (end - start).GetAngle() + (double)Math.Sign(bulge) * num3;
		return new XY(start.X + radius * MathHelper.Cos(value), start.Y + radius * MathHelper.Sin(value));
	}

	public override void ApplyTransform(Transform transform)
	{
		XYZ normal = base.Normal;
		base.ApplyTransform(transform);
		Matrix3 transOW;
		Matrix3 transWO;
		Matrix3 worldMatrix = getWorldMatrix(transform, normal, base.Normal, out transOW, out transWO);
		XY xY = XY.Rotate(new XY(base.Radius, 0.0), StartAngle);
		XY xY2 = XY.Rotate(new XY(base.Radius, 0.0), EndAngle);
		XYZ xYZ = transOW * new XYZ(xY.X, xY.Y, 0.0);
		xYZ = worldMatrix * xYZ;
		xYZ = transWO * xYZ;
		XYZ xYZ2 = transOW * new XYZ(xY2.X, xY2.Y, 0.0);
		xYZ2 = worldMatrix * xYZ2;
		xYZ2 = transWO * xYZ2;
		XY xY3 = new XY(xYZ.X, xYZ.Y);
		XY xY4 = new XY(xYZ2.X, xYZ2.Y);
		if (Math.Sign(worldMatrix.M00 * worldMatrix.M11 * worldMatrix.M22) < 0)
		{
			EndAngle = xY3.GetAngle();
			StartAngle = xY4.GetAngle();
		}
		else
		{
			StartAngle = xY3.GetAngle();
			EndAngle = xY4.GetAngle();
		}
		StartAngle = MathHelper.FixZero(StartAngle);
		EndAngle = MathHelper.FixZero(EndAngle);
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.FromPoints(PolygonalVertexes(256));
	}

	public void GetEndVertices(out XYZ start, out XYZ end)
	{
		start = new XYZ(MathHelper.Cos(StartAngle), MathHelper.Sin(StartAngle), 0.0);
		start = base.Center + base.Radius * start;
		end = new XYZ(MathHelper.Cos(EndAngle), MathHelper.Sin(EndAngle), 0.0);
		end = base.Center + base.Radius * end;
		Matrix4 arbitraryAxis = Matrix4.GetArbitraryAxis(base.Normal);
		start = arbitraryAxis * start;
		end = arbitraryAxis * end;
	}

	public override List<XYZ> PolygonalVertexes(int precision)
	{
		if (precision < 2)
		{
			throw new ArgumentOutOfRangeException("precision", precision, "The arc precision must be equal or greater than two.");
		}
		return CurveExtensions.PolygonalVertexes(precision, base.Center, StartAngle, EndAngle, base.Radius, base.Normal.Normalize());
	}
}
