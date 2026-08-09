using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Triangle : Entity, IFace, ICloneable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static readonly IndexTriangle[] _0023_003DznuAb7UsOMxSG3E4LsA_003D_003D = new IndexTriangle[1]
	{
		new IndexTriangle(0, 1, 2)
	};

	public Vector3D Normal { get; set; }

	public byte VisibleEdgeFlag { get; set; } = 7;

	public Triangle(double v1x, double v1y, double v1z, double v2x, double v2y, double v2z, double v3x, double v3y, double v3z)
		: base(entityNatureType.Polygon)
	{
		_vertices = new Point3D[3]
		{
			new Point3D(v1x, v1y, v1z),
			new Point3D(v2x, v2y, v2z),
			new Point3D(v3x, v3y, v3z)
		};
	}

	public Triangle(Point3D v1, Point3D v2, Point3D v3)
		: base(entityNatureType.Polygon)
	{
		_vertices = new Point3D[3] { v1, v2, v3 };
	}

	protected Triangle(Triangle another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_vertices = new Point3D[3];
		for (int i = 0; i < 3; i++)
		{
			_vertices[i] = (Point3D)another._vertices[i].Clone();
		}
		VisibleEdgeFlag = another.VisibleEdgeFlag;
		if (keepTessellation)
		{
			Normal = (Vector3D)another.Normal.Clone();
		}
	}

	protected internal Triangle(TriangleSurrogate surrogate)
		: this(surrogate.GetVertices()[0], surrogate.GetVertices()[1], surrogate.GetVertices()[2])
	{
	}

	public Triangle(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
		_vertices = (Point3D[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), typeof(Point3D[]));
		Normal = (Vector3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953809), typeof(Vector3D));
		VisibleEdgeFlag = info.GetByte(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975990));
	}

	public override object Clone()
	{
		return new Triangle(this);
	}

	public override object CloneWithTessellation()
	{
		return new Triangle(this, RegenMode != regenType.RegenAndCompile);
	}

	private protected override void _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
	}

	public override void Regen(RegenParams data)
	{
		Normal = Quad.ComputeNormal(_vertices[0], _vertices[1], _vertices[2]);
		base.Regen(data);
	}

	public IList<HitTriangle> FindClosestTriangle(Transformation transf, Segment3D seg)
	{
		return Utility.FindClosestTriangle(transf, seg, _vertices, _0023_003DznuAb7UsOMxSG3E4LsA_003D_003D).Values;
	}

	public ICurve[] Section(Plane pln, double tol)
	{
		return new Mesh(3, 1, Mesh.natureType.Plain)
		{
			Vertices = _vertices,
			Triangles = _0023_003DznuAb7UsOMxSG3E4LsA_003D_003D
		}.Section(pln, tol);
	}

	public void FlipNormal()
	{
		Point3D point3D = (Point3D)_vertices[1].Clone();
		_vertices[1] = _vertices[2];
		_vertices[2] = point3D;
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

	public static double Area(Point3D p1, Point3D p2, Point3D p3)
	{
		return Utility.TriangleArea(p1, p2, p3);
	}

	public static double Area2D(double x1, double y1, double x2, double y2, double x3, double y3)
	{
		return (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0;
	}

	public static Point3D Centroid(Point3D p1, Point3D p2, Point3D p3)
	{
		double x = (p1.X + p2.X + p3.X) / 3.0;
		double y = (p1.Y + p2.Y + p3.Y) / 3.0;
		double z = (p1.Z + p2.Z + p3.Z) / 3.0;
		return new Point3D(x, y, z);
	}

	internal static double _0023_003Dz1Adjqfhc_0024Cyh(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D, Point3D _0023_003Dzm4eSPQQ_003D)
	{
		double num = _0023_003DzFj_0024IqDQ_003D.DistanceTo(_0023_003DzjdeMMkk_003D);
		double num2 = _0023_003DzjdeMMkk_003D.DistanceTo(_0023_003Dzm4eSPQQ_003D);
		double num3 = _0023_003Dzm4eSPQQ_003D.DistanceTo(_0023_003DzFj_0024IqDQ_003D);
		double num4 = (num + num2 + num3) / 2.0;
		return Math.Sqrt(num4 * (num4 - num) * (num4 - num2) * (num4 - num3));
	}

	internal static double _0023_003DzPiN1LjJIcmriaUrYeA_003D_003D(Point2D _0023_003DzffqPLNQ_003D, Point2D _0023_003Dz5Azd7L8_003D, Point2D _0023_003DzZe6oCrQ_003D, Point2D _0023_003DzB68dg9Q_003D, double _0023_003Dzt38nTwk_003D, double _0023_003DzRZmqfkw_003D, double _0023_003DzKZleN9c_003D)
	{
		double num = ((_0023_003Dz5Azd7L8_003D.Y - _0023_003DzZe6oCrQ_003D.Y) * (_0023_003DzB68dg9Q_003D.X - _0023_003DzZe6oCrQ_003D.X) + (_0023_003DzZe6oCrQ_003D.X - _0023_003Dz5Azd7L8_003D.X) * (_0023_003DzB68dg9Q_003D.Y - _0023_003DzZe6oCrQ_003D.Y)) / ((_0023_003Dz5Azd7L8_003D.Y - _0023_003DzZe6oCrQ_003D.Y) * (_0023_003DzffqPLNQ_003D.X - _0023_003DzZe6oCrQ_003D.X) + (_0023_003DzZe6oCrQ_003D.X - _0023_003Dz5Azd7L8_003D.X) * (_0023_003DzffqPLNQ_003D.Y - _0023_003DzZe6oCrQ_003D.Y));
		double num2 = ((_0023_003DzZe6oCrQ_003D.Y - _0023_003DzffqPLNQ_003D.Y) * (_0023_003DzB68dg9Q_003D.X - _0023_003DzZe6oCrQ_003D.X) + (_0023_003DzffqPLNQ_003D.X - _0023_003DzZe6oCrQ_003D.X) * (_0023_003DzB68dg9Q_003D.Y - _0023_003DzZe6oCrQ_003D.Y)) / ((_0023_003Dz5Azd7L8_003D.Y - _0023_003DzZe6oCrQ_003D.Y) * (_0023_003DzffqPLNQ_003D.X - _0023_003DzZe6oCrQ_003D.X) + (_0023_003DzZe6oCrQ_003D.X - _0023_003Dz5Azd7L8_003D.X) * (_0023_003DzffqPLNQ_003D.Y - _0023_003DzZe6oCrQ_003D.Y));
		double num3 = 1.0 - num - num2;
		return _0023_003Dzt38nTwk_003D * num + _0023_003DzRZmqfkw_003D * num2 + _0023_003DzKZleN9c_003D * num3;
	}

	public override bool IsValid(StringBuilder log = null)
	{
		if (!new Vector3D(_vertices[0], _vertices[1], _vertices[2]).IsZero)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982510));
			return false;
		}
		return base.IsValid(log);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new TriangleSurrogate(this);
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (Normal != null)
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

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982468));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975940) + _vertices[0]);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975949) + _vertices[1]);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975930) + _vertices[2]);
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

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		return _vertices;
	}

	public double GetPerimeter()
	{
		return _vertices[0].DistanceTo(_vertices[1]) + _vertices[1].DistanceTo(_vertices[2]) + _vertices[2].DistanceTo(_vertices[0]);
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

	protected internal override void DrawNormals(DrawParams data)
	{
		double normalLength = GetNormalLength();
		data.RenderContext.DrawNormals(new Point3D[1] { _vertices[0] }, Normal * normalLength);
	}

	protected internal override void DrawEdges(DrawParams data)
	{
		if (VisibleEdgeFlag == 7)
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
			list.Add(_vertices[0]);
		}
		if (list.Count > 0)
		{
			data.RenderContext.DrawLines(list.ToArray());
		}
	}

	public override void Compile(CompileParams data)
	{
		RegenMode = regenType.NotNeeded;
	}

	protected internal override void Draw(DrawParams data)
	{
		data.RenderContext.DrawTrianglesPlanar(_vertices, new IndexTriangle[1]
		{
			new IndexTriangle(0, 1, 2)
		}, Normal);
	}

	protected internal override void DrawWireframe(DrawParams data)
	{
		data.RenderContext.DrawLineLoop(_vertices);
	}

	protected internal override void DrawSilhouettes(DrawSilhouettesParams data)
	{
		data.RenderContext.DrawLineLoop(_vertices);
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		Transformation transformation = data.Transformation;
		if (transformation == null)
		{
			if (Entity.FrustumEdgesTriangleIntersection(data.SelectionEdges, _vertices[0], _vertices[1], _vertices[2]))
			{
				AddSelectedItemLeaf(data);
				return true;
			}
			return false;
		}
		if (Entity.FrustumEdgesTriangleIntersection(data.SelectionEdges, transformation * _vertices[0], transformation * _vertices[1], transformation * _vertices[2]))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		if (data.Transformation == null)
		{
			if (Entity.ThroughTriangleScreenPolygon(_vertices[0], _vertices[1], _vertices[2], data))
			{
				AddSelectedItemLeaf(data);
				return true;
			}
			return false;
		}
		if (Entity.ThroughTriangleScreenPolygon(data.Transformation * _vertices[0], data.Transformation * _vertices[1], data.Transformation * _vertices[2], data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return true;
	}

	public static double Quality(Point3D p1, Point3D p2, Point3D p3)
	{
		return _0023_003DzAO_0024anLA_003D(p1, p2, p3, p1.DistanceTo(p2), p2.DistanceTo(p3), p3.DistanceTo(p1));
	}

	internal static double _0023_003DzAO_0024anLA_003D(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D, Point3D _0023_003Dzm4eSPQQ_003D, double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003Dzt_m8zV0_003D)
	{
		return 6.928203230275509 * Utility.TriangleArea(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D, _0023_003Dzm4eSPQQ_003D) / Math.Max(_0023_003DzjbqS1qE_003D, Math.Max(_0023_003Dz1v6oPQk_003D, _0023_003Dzt_m8zV0_003D)) / (_0023_003DzjbqS1qE_003D + _0023_003Dz1v6oPQk_003D + _0023_003Dzt_m8zV0_003D);
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D obj = _0023_003DzuAMveDQA6vvk()[0];
		obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
		obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		_0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D _0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D2 = new _0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D(new Point3D[4]
		{
			_vertices[0],
			_vertices[1],
			_vertices[2],
			(Point3D)_vertices[0].Clone()
		}, ColorMethod == colorMethodType.byEntity, LayerName, Color);
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[1] { _0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D2 };
	}

	internal override SilhoWireData _0023_003DzEt1XHB_xc_BLLBoMbJmskWU_003D(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		return HiddenLinesView._0023_003DzeWZNZhCW691ciXKd0w_003D_003D(this, _0023_003DzELu0Pss_003D.Parents, _vertices, _0023_003DznuAb7UsOMxSG3E4LsA_003D_003D, null, _0023_003DzbErHvVw_003D: false, 0.0);
	}

	internal _0023_003DzbykJA36oCfUxYTgeaw_003D_003D[] _0023_003Dzh7e7AC7wIb_T(Color _0023_003Dzt_m8zV0_003D)
	{
		Point3D point3D = _vertices[0];
		Point3D point3D2 = _vertices[1];
		Point3D point3D3 = _vertices[2];
		Plane plane = new Plane(point3D, new Vector3D(0.0 - Normal.X, 0.0 - Normal.Y, 0.0 - Normal.Z));
		List<List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>> list = new List<List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>>();
		list.Add(new List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>
		{
			new _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu(point3D.ToArray()),
			new _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu(point3D2.ToArray()),
			new _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu(point3D3.ToArray())
		});
		_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 = new _0023_003DzbykJA36oCfUxYTgeaw_003D_003D();
		_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DznMfYYu4y2pvS(plane.Origin.ToArray(), plane.AxisZ.ToArray());
		_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzzFhuPAt59wzG(list);
		if (_0023_003Dzt_m8zV0_003D != Color.Empty)
		{
			_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003Dzwtld1NM_003D = new double[3]
			{
				(double)(int)_0023_003Dzt_m8zV0_003D.R / 255.0,
				(double)(int)_0023_003Dzt_m8zV0_003D.G / 255.0,
				(double)(int)_0023_003Dzt_m8zV0_003D.B / 255.0
			};
		}
		return new _0023_003DzbykJA36oCfUxYTgeaw_003D_003D[1] { _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 };
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
}
