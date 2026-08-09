using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Extensions;
using CSMath;
using CSUtilities.Extensions;

namespace ACadSharp.Entities;

[DxfName("LWPOLYLINE")]
[DxfSubClass("AcDbPolyline")]
public class LwPolyline : Entity, IPolyline, IEntity, IHandledCadObject, IGeometricEntity
{
	public class Vertex : IVertex
	{
		[DxfCodeValue(new int[] { 10, 20 })]
		public XY Location { get; set; } = XY.Zero;

		[DxfCodeValue(DxfReferenceType.Optional, new int[] { 40 })]
		public double StartWidth { get; set; }

		[DxfCodeValue(DxfReferenceType.Optional, new int[] { 41 })]
		public double EndWidth { get; set; }

		[DxfCodeValue(DxfReferenceType.Optional, new int[] { 42 })]
		public double Bulge { get; set; }

		[DxfCodeValue(new int[] { 70 })]
		public VertexFlags Flags { get; set; }

		[DxfCodeValue(new int[] { 50 })]
		public double CurveTangent { get; set; }

		[DxfCodeValue(new int[] { 91 })]
		public int Id { get; set; }

		IVector IVertex.Location
		{
			get
			{
				return Location;
			}
			set
			{
				Location = value.Convert<XY>();
			}
		}

		public Vertex()
		{
		}

		public Vertex(XY location)
		{
			Location = location;
		}

		public override string ToString()
		{
			return Location.ToString();
		}
	}

	private LwPolylineFlags _flags;

	[DxfCodeValue(new int[] { 43 })]
	public double ConstantWidth { get; set; }

	[DxfCodeValue(new int[] { 38 })]
	public double Elevation { get; set; }

	[DxfCodeValue(new int[] { 70 })]
	public LwPolylineFlags Flags
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
			return Flags.HasFlag(LwPolylineFlags.Closed);
		}
		set
		{
			if (value)
			{
				_flags.AddFlag(LwPolylineFlags.Closed);
			}
			else
			{
				_flags.RemoveFlag(LwPolylineFlags.Closed);
			}
		}
	}

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "LWPOLYLINE";

	public override ObjectType ObjectType => ObjectType.LWPOLYLINE;

	public override string SubclassMarker => "AcDbPolyline";

	[DxfCodeValue(new int[] { 39 })]
	public double Thickness { get; set; }

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 90 })]
	public List<Vertex> Vertices { get; private set; } = new List<Vertex>();

	IEnumerable<IVertex> IPolyline.Vertices => Vertices;

	public LwPolyline()
	{
	}

	public LwPolyline(params IEnumerable<Vertex> vertices)
	{
		Vertices.AddRange(vertices);
	}

	public LwPolyline(params IEnumerable<XY> vertices)
		: this(vertices.Select((XY v) => new Vertex(v)))
	{
	}

	public override void ApplyTransform(Transform transform)
	{
		XYZ xYZ = transformNormal(transform, Normal);
		getWorldMatrix(transform, Normal, xYZ, out var transOW, out var transWO);
		foreach (Vertex vertex in Vertices)
		{
			XYZ xyz = transOW * vertex.Location.Convert<XYZ>();
			xyz = transform.ApplyTransform(xyz);
			xyz = transWO * xyz;
			vertex.Location = xyz.Convert<XY>();
		}
		Normal = xYZ;
	}

	public override BoundingBox GetBoundingBox()
	{
		if (Vertices.Any((Vertex v) => v.Bulge != 0.0))
		{
			return BoundingBox.FromPoints(this.GetPoints<XYZ>(255));
		}
		return BoundingBox.FromPoints(Vertices.Select((Vertex v) => v.Location.Convert<XYZ>()));
	}
}
