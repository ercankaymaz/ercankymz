using System;
using System.Collections.Generic;
using ACadSharp.Attributes;
using CSMath;
using CSMath.Geometry;

namespace ACadSharp.Entities;

[DxfName("ELLIPSE")]
[DxfSubClass("AcDbEllipse")]
public class Ellipse : Entity, ICurve
{
	private double _radiusRatio = 1.0;

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ Center { get; set; } = XYZ.Zero;

	[DxfCodeValue(new int[] { 42 })]
	public double EndParameter { get; set; } = Math.PI * 2.0;

	public bool IsFullEllipse
	{
		get
		{
			if (StartParameter == 0.0)
			{
				return EndParameter == Math.PI * 2.0;
			}
			return false;
		}
	}

	public double MajorAxis => 2.0 * MajorAxisEndPoint.GetLength();

	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ MajorAxisEndPoint { get; set; } = XYZ.AxisX;

	public double MinorAxis => MajorAxis * RadiusRatio;

	public XYZ MinorAxisEndpoint
	{
		get
		{
			XYZ xYZ = XYZ.Cross(Normal, MajorAxisEndPoint.Normalize()).Normalize();
			double length = MajorAxisEndPoint.GetLength();
			return RadiusRatio * length * xYZ;
		}
	}

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "ELLIPSE";

	public override ObjectType ObjectType => ObjectType.ELLIPSE;

	[DxfCodeValue(new int[] { 40 })]
	public double RadiusRatio
	{
		get
		{
			return _radiusRatio;
		}
		set
		{
			if (value <= 0.0 || value > 1.0)
			{
				throw new ArgumentOutOfRangeException("value", "Radius ratio must be a value between 0 (not included) and 1.");
			}
			_radiusRatio = value;
		}
	}

	public double Rotation => ((XY)MajorAxisEndPoint).GetAngle();

	[DxfCodeValue(new int[] { 41 })]
	public double StartParameter { get; set; }

	public override string SubclassMarker => "AcDbEllipse";

	[DxfCodeValue(new int[] { 39 })]
	public double Thickness { get; set; }

	public override void ApplyTransform(Transform transform)
	{
		XYZ vector = XYZ.Cross(Normal, MajorAxisEndPoint);
		vector = vector.Normalize();
		vector *= MajorAxisEndPoint.GetLength() * RadiusRatio;
		Center = transform.ApplyTransform(Center);
		MajorAxisEndPoint = transform.ApplyScale(MajorAxisEndPoint);
		XYZ xYZ = transform.ApplyTransform(vector);
		if (xYZ != XYZ.Zero && MajorAxisEndPoint != XYZ.Zero)
		{
			double num = xYZ.GetLength() / MajorAxisEndPoint.GetLength();
			if (num > 1.0)
			{
				num = RadiusRatio;
			}
			RadiusRatio = num;
			Normal = XYZ.Cross(xYZ, MajorAxisEndPoint).Normalize();
		}
		else
		{
			Normal = transformNormal(transform, Normal);
		}
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.FromPoints(PolygonalVertexes(100));
	}

	public void GetEndVertices(out XYZ start, out XYZ end)
	{
		start = PolarCoordinateRelativeToCenter(StartParameter);
		end = PolarCoordinateRelativeToCenter(EndParameter);
	}

	public XYZ PolarCoordinateRelativeToCenter(double angle)
	{
		return CurveExtensions.PolarCoordinate(angle, Center, Normal, MajorAxisEndPoint, RadiusRatio);
	}

	public List<XYZ> PolygonalVertexes(int precision)
	{
		return CurveExtensions.PolygonalVertexes(precision, Center, StartParameter, EndParameter, Normal, MajorAxisEndPoint + Center, RadiusRatio);
	}
}
