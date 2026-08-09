using System;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class SectionView : VectorView
{
	public VectorView ParentView { get; }

	public Segment2D SectionLine { get; }

	public Plane SectionPlane { get; }

	public SectionView(double x, double y, Plane sectionPlane, double scale, string name)
		: base(x, y, null, scale, name)
	{
		_0023_003DztGdcVOA_003D(sectionPlane, scale);
	}

	public SectionView(Point2D position, VectorView parentView, Point2D sectionLineP0, Point2D sectionLineP1, string name)
		: this(position.X, position.Y, parentView, new Segment2D(sectionLineP0, sectionLineP1), name)
	{
	}

	public SectionView(double x, double y, VectorView parentView, Segment2D sectionLine, string name)
		: base(x, y, null, 1.0, name)
	{
		ParentView = parentView;
		SectionLine = sectionLine;
	}

	protected SectionView(SectionView another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_0023_003DzPOJsk28mpsMNtfD8Bw_003D_003D(another.SectionPlane);
	}

	protected internal SectionView(SectionViewSurrogate surrogate)
		: base(surrogate)
	{
		ParentView = surrogate.ParentView;
		SectionLine = surrogate.SectionLine;
		_0023_003DzPOJsk28mpsMNtfD8Bw_003D_003D(surrogate.SectionPlane);
	}

	protected SectionView(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		ParentView = (VectorView)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976871), typeof(VectorView));
		SectionLine = (Segment2D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976858), typeof(Segment2D));
		_0023_003DzPOJsk28mpsMNtfD8Bw_003D_003D((Plane)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976844), typeof(Plane)));
	}

	internal void _0023_003DzPOJsk28mpsMNtfD8Bw_003D_003D(Plane _0023_003DzPzO_0024GUk_003D)
	{
		SectionPlane = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DztGdcVOA_003D(Plane _0023_003Dz__4OfIpVgJ6A, double _0023_003DzoMBKEgY_003D)
	{
		_0023_003DzPOJsk28mpsMNtfD8Bw_003D_003D(_0023_003Dz__4OfIpVgJ6A);
		Scale = _0023_003DzoMBKEgY_003D;
		_0023_003DzXs_0024UXorrEwQq(_0023_003Dz2BrQCKOcKev5gM_QVw_003D_003D(_0023_003Dz__4OfIpVgJ6A));
	}

	internal static Camera _0023_003Dz2BrQCKOcKev5gM_QVw_003D_003D(Plane _0023_003Dz__4OfIpVgJ6A)
	{
		Utility.GetRotationAxisAndAngle(Vector3D.AxisX, _0023_003Dz__4OfIpVgJ6A.AxisZ, out var rotAxis, out var angleInDegrees);
		Quaternion rotation;
		if (rotAxis != null)
		{
			rotation = new Quaternion(rotAxis, angleInDegrees);
		}
		else if (Vector3D.Dot(_0023_003Dz__4OfIpVgJ6A.AxisZ, Vector3D.AxisX) > 0.0)
		{
			rotation = Quaternion.Identity;
		}
		else
		{
			Plane plane = new Plane(_0023_003Dz__4OfIpVgJ6A.AxisZ);
			rotAxis = plane.AxisX + plane.AxisY;
			rotAxis.Normalize();
			rotation = new Quaternion(rotAxis, 180.0);
		}
		Camera camera = new Camera((Point3D)_0023_003Dz__4OfIpVgJ6A.Origin.Clone(), 0.0, rotation, projectionType.Orthographic, 0.0, 1.0);
		camera.Tilt(_0023_003Dz__4OfIpVgJ6A.AxisY);
		return camera;
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new SectionViewSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976871), ParentView);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976858), SectionLine);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976844), SectionPlane);
	}

	public override object Clone()
	{
		return new SectionView(this);
	}

	public override object CloneWithTessellation()
	{
		return new SectionView(this, RegenMode != regenType.RegenAndCompile);
	}
}
