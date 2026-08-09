using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Extensions;
using CSMath;
using CSUtilities.Extensions;

namespace ACadSharp.Entities;

[DxfName("POLYLINE")]
[DxfSubClass(null, true)]
public abstract class Polyline<T> : Entity, IPolyline, IEntity, IHandledCadObject, IGeometricEntity where T : Entity, IVertex
{
	private PolylineFlags _flags;

	[DxfCodeValue(new int[] { 30 })]
	public double Elevation { get; set; }

	[DxfCodeValue(new int[] { 41 })]
	public double EndWidth { get; set; }

	[DxfCodeValue(new int[] { 70 })]
	public PolylineFlags Flags
	{
		get
		{
			return _flags;
		}
		set
		{
			_flags = value;
		}
	}

	public bool IsClosed
	{
		get
		{
			if (!Flags.HasFlag(PolylineFlags.ClosedPolylineOrClosedPolygonMeshInM))
			{
				return Flags.HasFlag(PolylineFlags.ClosedPolygonMeshInN);
			}
			return true;
		}
		set
		{
			if (value)
			{
				_flags.AddFlag(PolylineFlags.ClosedPolylineOrClosedPolygonMeshInM);
				_flags.AddFlag(PolylineFlags.ClosedPolygonMeshInN);
			}
			else
			{
				_flags.RemoveFlag(PolylineFlags.ClosedPolylineOrClosedPolygonMeshInM);
				_flags.RemoveFlag(PolylineFlags.ClosedPolygonMeshInN);
			}
		}
	}

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "POLYLINE";

	[DxfCodeValue(new int[] { 75 })]
	public SmoothSurfaceType SmoothSurface { get; set; }

	[DxfCodeValue(new int[] { 40 })]
	public double StartWidth { get; set; }

	[DxfCodeValue(new int[] { 39 })]
	public double Thickness { get; set; }

	public SeqendCollection<T> Vertices { get; private set; }

	IEnumerable<IVertex> IPolyline.Vertices => Vertices;

	public Polyline()
	{
		Vertices = new SeqendCollection<T>(this);
	}

	public Polyline(IEnumerable<T> vertices, bool isClosed)
		: this()
	{
		if (vertices == null)
		{
			throw new ArgumentException("The vertices enumerable cannot be null or empty", "vertices");
		}
		Vertices.AddRange(vertices);
		IsClosed = isClosed;
	}

	public override void ApplyTransform(Transform transform)
	{
		XYZ xYZ = transformNormal(transform, Normal);
		getWorldMatrix(transform, Normal, xYZ, out var transOW, out var transWO);
		foreach (T vertex in Vertices)
		{
			XYZ xyz = transOW * vertex.Location.Convert<XYZ>();
			xyz = transform.ApplyTransform(xyz);
			xyz = transWO * xyz;
			vertex.Location = xyz;
		}
		Normal = xYZ;
	}

	public override CadObject Clone()
	{
		Polyline<T> polyline = (Polyline<T>)base.Clone();
		polyline.Vertices = new SeqendCollection<T>(polyline);
		foreach (T vertex in Vertices)
		{
			polyline.Vertices.Add((T)vertex.Clone());
		}
		return polyline;
	}

	public override BoundingBox GetBoundingBox()
	{
		if (Vertices.Any((T v) => v.Bulge != 0.0))
		{
			return BoundingBox.FromPoints(this.GetPoints<XYZ>(255));
		}
		return BoundingBox.FromPoints(Vertices.Select((T v) => v.Location.Convert<XYZ>()));
	}

	internal static IEnumerable<Entity> Explode(IPolyline polyline)
	{
		List<Entity> list = new List<Entity>();
		for (int i = 0; i < polyline.Vertices.Count(); i++)
		{
			IVertex vertex = polyline.Vertices.ElementAt(i);
			IVertex vertex2 = polyline.Vertices.ElementAtOrDefault(i + 1);
			if (vertex2 == null && polyline.IsClosed)
			{
				vertex2 = polyline.Vertices.First();
			}
			else if (vertex2 == null)
			{
				break;
			}
			Entity entity = null;
			if (vertex.Bulge == 0.0)
			{
				entity = new Line
				{
					StartPoint = vertex.Location.Convert<XYZ>(),
					EndPoint = vertex2.Location.Convert<XYZ>(),
					Normal = polyline.Normal,
					Thickness = polyline.Thickness
				};
			}
			else
			{
				XY p = vertex.Location.Convert<XY>();
				XY p2 = vertex2.Location.Convert<XY>();
				Arc arc = Arc.CreateFromBulge(p, p2, vertex.Bulge);
				arc.Center = new XYZ(arc.Center.X, arc.Center.Y, polyline.Elevation);
				arc.Normal = polyline.Normal;
				arc.Thickness = polyline.Thickness;
				entity = arc;
			}
			polyline.MatchProperties(entity);
			list.Add(entity);
		}
		return list;
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		doc.RegisterCollection(Vertices);
	}

	internal override void UnassignDocument()
	{
		base.Document.UnregisterCollection(Vertices);
		base.UnassignDocument();
	}
}
