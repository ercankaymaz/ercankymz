using System;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class WireBox : LinearPath
{
	public Point3D CenterPoint => Point3D.MidPoint(_vertices[0], _vertices[6]);

	public WireBox(double x1, double y1, double z1, double x2, double y2, double z2)
		: this(new Point3D(x1, y1, z1), new Point3D(x2, y2, z2))
	{
	}

	public WireBox(Point3D min, Point3D max)
		: base(Utility.GetBoundingBoxCorners(min, max))
	{
	}

	public WireBox(Point3D min, Vector3D size)
		: base(Utility.GetBoundingBoxCorners(min, min + size))
	{
	}

	public WireBox(Point3D[] corners)
		: base(corners)
	{
	}

	protected WireBox(WireBox another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_vertices = Utility._0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(another._vertices);
	}

	protected internal WireBox(WireBoxSurrogate surrogate)
		: this(surrogate.Vertices)
	{
	}

	protected WireBox(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public override object Clone()
	{
		return new WireBox(this);
	}

	public override object CloneWithTessellation()
	{
		return new WireBox(this, RegenMode != regenType.RegenAndCompile);
	}

	private protected override void _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
	}

	public override bool IsValid(StringBuilder log = null)
	{
		if (_vertices == null)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960550));
		}
		else if (_vertices.Length != 8)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983466));
		}
		return base.IsValid(log);
	}

	protected override void DrawWireEntity(RenderContextBase context, object myParams)
	{
		Segment3D[] array = _0023_003DzAqQbug4_003D();
		foreach (Segment3D segment3D in array)
		{
			context.DrawLine(segment3D.P0, segment3D.P1);
		}
	}

	private Segment3D[] _0023_003DzAqQbug4_003D()
	{
		return new Segment3D[12]
		{
			new Segment3D(_vertices[0], _vertices[1]),
			new Segment3D(_vertices[1], _vertices[2]),
			new Segment3D(_vertices[2], _vertices[3]),
			new Segment3D(_vertices[3], _vertices[0]),
			new Segment3D(_vertices[4], _vertices[5]),
			new Segment3D(_vertices[5], _vertices[6]),
			new Segment3D(_vertices[6], _vertices[7]),
			new Segment3D(_vertices[7], _vertices[4]),
			new Segment3D(_vertices[0], _vertices[4]),
			new Segment3D(_vertices[1], _vertices[5]),
			new Segment3D(_vertices[2], _vertices[6]),
			new Segment3D(_vertices[3], _vertices[7])
		};
	}

	internal override bool IntersectEdgeOrIsoline(FrustumParams _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzELu0Pss_003D.Transformation == null)
		{
			Segment3D[] array = _0023_003DzAqQbug4_003D();
			foreach (Segment3D segment in array)
			{
				if (Utility.IsSegmentInsideOrCrossing(_0023_003DzELu0Pss_003D.Frustum, segment))
				{
					AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
					return true;
				}
			}
		}
		else
		{
			Segment3D[] array = _0023_003DzAqQbug4_003D();
			foreach (Segment3D segment2 in array)
			{
				if (Utility.IsSegmentInsideOrCrossing(_0023_003DzELu0Pss_003D.Frustum, segment2))
				{
					AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
					return true;
				}
			}
		}
		return false;
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new WireBoxSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
	}
}
