using System;
using System.Collections.Generic;
using ACadSharp.Attributes;
using CSMath;
using CSMath.Geometry;

namespace ACadSharp.Entities;

[DxfName("CIRCLE")]
[DxfSubClass("AcDbCircle")]
public class Circle : Entity, ICurve
{
	private double _radius = 1.0;

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ Center { get; set; } = XYZ.Zero;

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "CIRCLE";

	public override ObjectType ObjectType => ObjectType.CIRCLE;

	[DxfCodeValue(new int[] { 40 })]
	public double Radius
	{
		get
		{
			return _radius;
		}
		set
		{
			if (value <= 0.0)
			{
				throw new ArgumentOutOfRangeException("value", value, "The radius must be greater than 0.");
			}
			_radius = value;
		}
	}

	public double RadiusRatio => 1.0;

	public override string SubclassMarker => "AcDbCircle";

	[DxfCodeValue(new int[] { 39 })]
	public double Thickness { get; set; }

	public override void ApplyTransform(Transform transform)
	{
		XYZ normal = Normal;
		Center = transform.ApplyTransform(Center);
		Normal = transformNormal(transform, Normal);
		Matrix3 transOW;
		Matrix3 transWO;
		Matrix3 worldMatrix = getWorldMatrix(transform, normal, Normal, out transOW, out transWO);
		XYZ xYZ = transOW * new XYZ(Radius, 0.0, 0.0);
		xYZ = worldMatrix * xYZ;
		xYZ = transWO * xYZ;
		XY vector = new XY(xYZ.X, xYZ.Y);
		_radius = vector.GetLength();
	}

	public override BoundingBox GetBoundingBox()
	{
		XYZ min = new XYZ(Math.Min(Center.X - Radius, Center.X + Radius), Math.Min(Center.Y - Radius, Center.Y + Radius), Math.Min(Center.Z, Center.Z));
		XYZ max = new XYZ(Math.Max(Center.X - Radius, Center.X + Radius), Math.Max(Center.Y - Radius, Center.Y + Radius), Math.Max(Center.Z, Center.Z));
		return new BoundingBox(min, max);
	}

	public virtual XYZ PolarCoordinateRelativeToCenter(double angle)
	{
		XYZ axisX = XYZ.AxisX;
		axisX = Center + Radius * axisX;
		axisX = Matrix4.GetArbitraryAxis(Normal) * axisX;
		return CurveExtensions.PolarCoordinate(angle, Center, Normal, axisX - Center);
	}

	public virtual List<XYZ> PolygonalVertexes(int precision)
	{
		if (precision < 2)
		{
			throw new ArgumentOutOfRangeException("precision", precision, "The arc precision must be equal or greater than two.");
		}
		return CurveExtensions.PolygonalVertexes(precision, Center, 0.0, Math.PI * 2.0, Radius, Normal.Normalize());
	}
}
