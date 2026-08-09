using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Quad : Entity, IFace, ICloneable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static readonly IndexTriangle[] _0023_003DznuAb7UsOMxSG3E4LsA_003D_003D = new IndexTriangle[2]
	{
		new IndexTriangle(0, 1, 2),
		new IndexTriangle(0, 2, 3)
	};

	public Vector3D Normal { get; }

	public byte VisibleEdgeFlag { get; set; } = 15;

	public Quad(double v1x, double v1y, double v1z, double v2x, double v2y, double v2z, double v3x, double v3y, double v3z, double v4x, double v4y, double v4z)
		: base(entityNatureType.Polygon)
	{
		_vertices = new Point3D[4];
		_vertices[0] = new Point3D(v1x, v1y, v1z);
		_vertices[1] = new Point3D(v2x, v2y, v2z);
		_vertices[2] = new Point3D(v3x, v3y, v3z);
		_vertices[3] = new Point3D(v4x, v4y, v4z);
	}

	public Quad(Point3D v1, Point3D v2, Point3D v3, Point3D v4)
		: base(entityNatureType.Polygon)
	{
		_vertices = new Point3D[4];
		_vertices[0] = new Point3D(v1.X, v1.Y, v1.Z);
		_vertices[1] = new Point3D(v2.X, v2.Y, v2.Z);
		_vertices[2] = new Point3D(v3.X, v3.Y, v3.Z);
		_vertices[3] = new Point3D(v4.X, v4.Y, v4.Z);
	}

	public Quad(Plane plane, Point2D v1, Point2D v2, Point2D v3, Point2D v4)
		: base(entityNatureType.Polygon)
	{
		_vertices = new Point3D[4];
		_vertices[0] = plane.PointAt(v1);
		_vertices[1] = plane.PointAt(v2);
		_vertices[2] = plane.PointAt(v3);
		_vertices[3] = plane.PointAt(v4);
	}

	public Quad(Plane plane, double x, double y, double width, double height)
		: base(entityNatureType.Polygon)
	{
		_vertices = new Point3D[4];
		_vertices[0] = plane.PointAt(x, y);
		_vertices[1] = plane.PointAt(x + width, y);
		_vertices[2] = plane.PointAt(x + width, y + height);
		_vertices[3] = plane.PointAt(x, y + height);
	}

	public Quad(double x, double y, double width, double height)
		: base(entityNatureType.Polygon)
	{
		_vertices = new Point3D[4];
		_vertices[0] = new Point3D(x, y);
		_vertices[1] = new Point3D(x + width, y);
		_vertices[2] = new Point3D(x + width, y + height);
		_vertices[3] = new Point3D(x, y + height);
	}

	protected Quad(Quad another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_vertices = new Point3D[4];
		for (int i = 0; i < 4; i++)
		{
			_vertices[i] = (Point3D)another._vertices[i].Clone();
		}
		VisibleEdgeFlag = another.VisibleEdgeFlag;
		if (keepTessellation)
		{
			_0023_003Dz2h5Pusvr_xOb((Vector3D)another.Normal.Clone());
		}
	}

	protected internal Quad(QuadSurrogate surrogate)
		: this(surrogate.GetVertices()[0], surrogate.GetVertices()[1], surrogate.GetVertices()[2], surrogate.GetVertices()[3])
	{
	}

	public Quad(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
		_vertices = (Point3D[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), typeof(Point3D[]));
		_0023_003Dz2h5Pusvr_xOb((Vector3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953809), typeof(Vector3D)));
		VisibleEdgeFlag = info.GetByte(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975990));
	}

	public override object Clone()
	{
		return new Quad(this);
	}

	public override object CloneWithTessellation()
	{
		return new Quad(this, RegenMode != regenType.RegenAndCompile);
	}

	private protected override void _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
	}

	internal void _0023_003Dz2h5Pusvr_xOb(Vector3D _0023_003DzPzO_0024GUk_003D)
	{
		Normal = _0023_003DzPzO_0024GUk_003D;
	}

	public IList<HitTriangle> FindClosestTriangle(Transformation transf, Segment3D seg)
	{
		return Utility.FindClosestTriangle(transf, seg, _vertices, _0023_003DznuAb7UsOMxSG3E4LsA_003D_003D).Values;
	}

	public ICurve[] Section(Plane pln, double tol)
	{
		return new Mesh(4, 2, Mesh.natureType.Plain)
		{
			Vertices = _vertices,
			Triangles = _0023_003DznuAb7UsOMxSG3E4LsA_003D_003D
		}.Section(pln, tol);
	}

	public override void Regen(RegenParams data)
	{
		_0023_003Dz2h5Pusvr_xOb(ComputeNormal(_vertices[0], _vertices[1], _vertices[2]));
		base.Regen(data);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975982));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975940) + _vertices[0]);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975949) + _vertices[1]);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975930) + _vertices[2]);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975907) + _vertices[3]);
		double _0023_003DzXWCF4rA_003D = double.NaN;
		Point3D centroid = null;
		double _0023_003DzhKcriekaIolc = double.NaN;
		Point3D centroid2 = null;
		double _0023_003DzZZ1x4JqOx = double.NaN;
		double convertedDensity = double.NaN;
		if (regenMode == regenType.RegenAndCompile)
		{
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971351));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		}
		else
		{
			_0023_003DzXWCF4rA_003D = GetArea(out centroid);
			_0023_003DzhKcriekaIolc = GetVolume(out centroid2);
			_0023_003DzZZ1x4JqOx = GetMass(GetMaterial(materials, layers), linearUnits, massUnits, out convertedDensity);
		}
		stringBuilder = _0023_003DzJ7t6sHqYVrbZ(stringBuilder, _0023_003DzXWCF4rA_003D, centroid, _0023_003DzhKcriekaIolc, centroid2, _0023_003DzZZ1x4JqOx, convertedDensity, linearUnits, massUnits, materials, layers);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975920) + GetPerimeter() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + linearUnits.ToString().ToLower());
		return stringBuilder.ToString();
	}

	public double GetPerimeter()
	{
		return _vertices[0].DistanceTo(_vertices[1]) + _vertices[1].DistanceTo(_vertices[2]) + _vertices[2].DistanceTo(_vertices[3]) + _vertices[3].DistanceTo(_vertices[0]);
	}

	public void FlipNormal()
	{
		Point3D point3D = (Point3D)_vertices[3].Clone();
		_vertices[3] = _vertices[1];
		_vertices[1] = point3D;
		if ((object)Normal != null)
		{
			Normal.Negate();
		}
	}

	public override void TransformBy(Transformation xform)
	{
		base.TransformBy(xform);
		if (Normal != null)
		{
			Utility.TransformNormals(xform, new Vector3D[1] { Normal });
		}
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new QuadSurrogate(this);
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (base._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D() && Normal != null)
		{
			return Normal.Length > 0.0;
		}
		return false;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	{
		base.GetObjectData(info, ctxt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), _vertices);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953809), Normal);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975990), VisibleEdgeFlag);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			return new Point3D[2]
			{
				_vertices[0],
				_vertices[2]
			};
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}

	public Mesh ConvertToMesh(double deviation = 0.0, double angle = 0.0, Mesh.natureType nature = Mesh.natureType.Plain, bool weld = true)
	{
		Mesh mesh = new Mesh(Utility.DeepCopy(_vertices), Utility.DeepCopy(_0023_003DznuAb7UsOMxSG3E4LsA_003D_003D));
		mesh.CopyAttributes(this);
		return mesh;
	}

	public Brep ConvertToBrep(bool mergeFaces = true, bool mergeEdges = true)
	{
		return ConvertToMesh().ConvertToBrep(mergeFaces, mergeEdges);
	}

	public void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		ComputeBoundingBox(null, out boxMin, out boxMax);
	}

	public Mesh[] GetTessellation()
	{
		return new Mesh[1]
		{
			new Mesh(_vertices, _0023_003DznuAb7UsOMxSG3E4LsA_003D_003D)
		};
	}

	public double GetArea(out Point3D centroid)
	{
		AreaProperties areaProperties = new AreaProperties();
		areaProperties.Add(GetTessellation());
		centroid = areaProperties.Centroid;
		return areaProperties.Area;
	}

	public double GetVolume(out Point3D centroid)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(GetTessellation());
		centroid = volumeProperties.Centroid;
		return volumeProperties.Volume;
	}

	public void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ, out double ix, out double iy, out double iz)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(GetTessellation());
		volumeProperties.GetPrincipalAxes(volumeProperties.Volume, volumeProperties.Centroid, out axisX, out axisY, out axisZ, out ix, out iy, out iz);
	}

	public void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ)
	{
		GetPrincipalAxes(out axisX, out axisY, out axisZ, out var _, out var _, out var _);
	}

	public double GetMass(Material material, linearUnitsType linearUnits, massUnitsType massUnits, out double convertedDensity)
	{
		Point3D centroid;
		return Utility._0023_003DzaWhFDDP5nQ_0024L(material, MaterialName, massUnits, linearUnits, GetVolume(out centroid), out convertedDensity);
	}

	internal static Vector3D ComputeNormal(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D, Point3D _0023_003Dzm4eSPQQ_003D)
	{
		double[] array = new double[3]
		{
			_0023_003DzFj_0024IqDQ_003D.X - _0023_003Dzm4eSPQQ_003D.X,
			_0023_003DzFj_0024IqDQ_003D.Y - _0023_003Dzm4eSPQQ_003D.Y,
			_0023_003DzFj_0024IqDQ_003D.Z - _0023_003Dzm4eSPQQ_003D.Z
		};
		double[] array2 = new double[3]
		{
			_0023_003DzjdeMMkk_003D.X - _0023_003DzFj_0024IqDQ_003D.X,
			_0023_003DzjdeMMkk_003D.Y - _0023_003DzFj_0024IqDQ_003D.Y,
			_0023_003DzjdeMMkk_003D.Z - _0023_003DzFj_0024IqDQ_003D.Z
		};
		Vector3D vector3D = new Vector3D(array[1] * array2[2] - array[2] * array2[1], array[2] * array2[0] - array[0] * array2[2], array[0] * array2[1] - array[1] * array2[0]);
		if (!vector3D.Normalize())
		{
			vector3D = Vector3D.AxisX;
		}
		return vector3D;
	}

	protected internal override void DrawEdges(DrawParams data)
	{
		if (VisibleEdgeFlag == 15)
		{
			DrawWireframe(data);
			return;
		}
		List<Point3D> list = new List<Point3D>(8);
		if ((VisibleEdgeFlag & 1) != 0)
		{
			list.Add(_vertices[0]);
			list.Add(_vertices[1]);
		}
		if ((VisibleEdgeFlag & 2) != 0)
		{
			list.Add(_vertices[1]);
			list.Add(_vertices[2]);
		}
		if ((VisibleEdgeFlag & 4) != 0)
		{
			list.Add(_vertices[2]);
			list.Add(_vertices[3]);
		}
		if ((VisibleEdgeFlag & 8) != 0)
		{
			list.Add(_vertices[3]);
			list.Add(_vertices[0]);
		}
		if (list.Count > 0)
		{
			data.RenderContext.DrawLines(list.ToArray());
		}
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		context.DrawQuads(_vertices, new Vector3D[1] { Normal });
	}

	protected internal override void DrawWireframe(DrawParams data)
	{
		data.RenderContext.DrawLineLoop(_vertices);
	}

	protected internal override void DrawSilhouettes(DrawSilhouettesParams data)
	{
		data.RenderContext.DrawLineLoop(_vertices);
	}

	protected internal override void DrawIsocurves(DrawParams data)
	{
	}

	protected internal override void DrawNormals(DrawParams data)
	{
		double normalLength = GetNormalLength();
		data.RenderContext.DrawNormals(new Point3D[1] { _vertices[0] }, Normal * normalLength);
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		if (Entity.ThroughTriangleQuad(data, _vertices))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity.ThroughTriangleScreenPolygonQuad(_vertices, data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		Point3D point3D = _vertices[0];
		Point3D point3D2 = _vertices[1];
		Point3D point3D3 = _vertices[2];
		Point3D point3D4 = _vertices[3];
		Point4D point4D = new Point4D(point3D.X, point3D.Y, point3D.Z);
		Point4D point4D2 = new Point4D(point3D2.X, point3D2.Y, point3D2.Z);
		Point4D point4D3 = new Point4D(point3D3.X, point3D3.Y, point3D3.Z);
		Point4D point4D4 = new Point4D(point3D4.X, point3D4.Y, point3D4.Z);
		Surface surface = new Surface(1, new double[4] { 0.0, 0.0, 1.0, 1.0 }, 1, new double[4] { 0.0, 0.0, 1.0, 1.0 }, new Point4D[2, 2]
		{
			{ point4D2, point4D },
			{ point4D3, point4D4 }
		});
		surface.CopyAttributes(this);
		surface._0023_003Dz_0024_0024rGbexgW9YV(_0023_003Dza_SABTbwi5q2, _0023_003DzJO1FWlQ_003D, ref _0023_003DzyzK8swU_003D);
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		Point3D point3D = _vertices[0];
		Point3D point3D2 = _vertices[1];
		Point3D point3D3 = _vertices[2];
		Point3D point3D4 = _vertices[3];
		Point4D point4D = new Point4D(point3D.X, point3D.Y, point3D.Z);
		Point4D point4D2 = new Point4D(point3D2.X, point3D2.Y, point3D2.Z);
		Point4D point4D3 = new Point4D(point3D3.X, point3D3.Y, point3D3.Z);
		Point4D point4D4 = new Point4D(point3D4.X, point3D4.Y, point3D4.Z);
		return new Surface(1, new double[4] { 0.0, 0.0, 1.0, 1.0 }, 1, new double[4] { 0.0, 0.0, 1.0, 1.0 }, new Point4D[2, 2]
		{
			{ point4D2, point4D },
			{ point4D3, point4D4 }
		})._0023_003DzAKDLnmImamFN(_0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ, _0023_003DzsAi4oSk_003D);
	}

	internal override SilhoWireData _0023_003DzEt1XHB_xc_BLLBoMbJmskWU_003D(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		return HiddenLinesView._0023_003DzeWZNZhCW691ciXKd0w_003D_003D(this, _0023_003DzELu0Pss_003D.Parents, _vertices, _0023_003DznuAb7UsOMxSG3E4LsA_003D_003D, null, _0023_003DzbErHvVw_003D: false, 0.0);
	}
}
