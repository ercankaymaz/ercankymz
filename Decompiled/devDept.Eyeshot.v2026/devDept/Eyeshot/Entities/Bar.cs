using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Bar : Entity, IFace, ICloneable, ITriangles
{
	protected Point3D start;

	protected Point3D end;

	private IndexTriangle[] _triangles;

	private double _radius;

	private int _slices;

	public int Slices
	{
		get
		{
			return _slices;
		}
		set
		{
			_slices = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double Radius
	{
		get
		{
			return _radius;
		}
		set
		{
			_radius = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public Point3D StartPoint
	{
		get
		{
			return start;
		}
		set
		{
			start = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public Point3D EndPoint
	{
		get
		{
			return end;
		}
		set
		{
			end = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public IndexTriangle[] Triangles
	{
		get
		{
			return _triangles;
		}
		protected internal set
		{
			_triangles = value;
		}
	}

	public Bar(double x1, double y1, double z1, double x2, double y2, double z2, double radius, int slices)
		: base(entityNatureType.Polygon)
	{
		start = new Point3D(x1, y1, z1);
		end = new Point3D(x2, y2, z2);
		_radius = radius;
		Slices = slices;
	}

	public Bar(Point3D start, Point3D end, double radius, int slices)
		: base(entityNatureType.Polygon)
	{
		this.start = start;
		this.end = end;
		_radius = radius;
		Slices = slices;
	}

	protected Bar(Bar another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		start = (Point3D)another.start.Clone();
		end = (Point3D)another.end.Clone();
		_radius = another._radius;
		_slices = another.Slices;
		if (keepTessellation)
		{
			Triangles = Utility._0023_003DzX42kjXfbzdxuD8Dt7A_003D_003D(another.Triangles);
		}
	}

	protected internal Bar(BarSurrogate surrogate)
		: this(surrogate.StartPoint, surrogate.EndPoint, surrogate.Radius, surrogate.Slices)
	{
	}

	protected Bar(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		start = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954895), typeof(Point3D));
		end = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954593), typeof(Point3D));
		_radius = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843));
		Slices = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956086));
	}

	public override object Clone()
	{
		return new Bar(this);
	}

	public override object CloneWithTessellation()
	{
		return new Bar(this, RegenMode != regenType.RegenAndCompile);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956065) + StartPoint);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956056) + EndPoint);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956041) + _radius);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956281) + Slices);
		double _0023_003DzXWCF4rA_003D = double.NaN;
		Point3D centroid = null;
		double _0023_003DzhKcriekaIolc = double.NaN;
		Point3D centroid2 = null;
		double _0023_003DzZZ1x4JqOx = double.NaN;
		double convertedDensity = double.NaN;
		if (regenMode == regenType.RegenAndCompile)
		{
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956265));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		}
		else
		{
			_0023_003DzXWCF4rA_003D = GetArea(out centroid);
			_0023_003DzhKcriekaIolc = GetVolume(out centroid2);
			_0023_003DzZZ1x4JqOx = GetMass(GetMaterial(materials, layers), linearUnits, massUnits, out convertedDensity);
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956197) + _triangles.Length);
		}
		stringBuilder = _0023_003DzJ7t6sHqYVrbZ(stringBuilder, _0023_003DzXWCF4rA_003D, centroid, _0023_003DzhKcriekaIolc, centroid2, _0023_003DzZZ1x4JqOx, convertedDensity, linearUnits, massUnits, materials, layers);
		return stringBuilder.ToString();
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

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (Utility.InsideOrCrossingFrustum(data, _vertices, _triangles))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (Utility._0023_003DzuQDPXh1pHaNF4I3G_Evhw9Q_003D(_vertices, _triangles, data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		if (Entity._0023_003Dzz3lsBX3i0Rg2(data, _vertices, _triangles))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity._0023_003DzOejNn2S1Lat5_0024X4DHg_003D_003D(_vertices, _triangles, data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override void DrawSilhouettes(DrawSilhouettesParams data)
	{
		HiddenLinesView._0023_003DzY9TYF9sTjnZYO51HtXX26S0_003D(this, data);
	}

	protected internal override void DrawIsocurves(DrawParams data)
	{
		base.DrawWireframe(data);
	}

	protected internal override void DrawNormals(DrawParams data)
	{
		_0023_003Dz_0024B4aBrhAQ9pMnKBcfw_003D_003D(out var _0023_003DzrH1N0x4_003D);
		data.RenderContext.DrawLines(_0023_003DzrH1N0x4_003D);
	}

	internal Vector3D[] _0023_003Dz_0024B4aBrhAQ9pMnKBcfw_003D_003D(out float[] _0023_003DzrH1N0x4_003D)
	{
		double normalLength = GetNormalLength();
		Vector3D[] array = new Vector3D[_vertices.Length];
		_0023_003DzrH1N0x4_003D = new float[Slices * 12];
		int num = 0;
		for (int i = 0; i < Slices; i++)
		{
			Point3D point3D = _vertices[i];
			Vector3D vector3D = Vector3D.Subtract(point3D, start);
			vector3D.Normalize();
			array[i] = vector3D;
			_0023_003DzrH1N0x4_003D[num++] = (float)point3D.X;
			_0023_003DzrH1N0x4_003D[num++] = (float)point3D.Y;
			_0023_003DzrH1N0x4_003D[num++] = (float)point3D.Z;
			_0023_003DzrH1N0x4_003D[num++] = (float)(point3D.X + vector3D.X * normalLength);
			_0023_003DzrH1N0x4_003D[num++] = (float)(point3D.Y + vector3D.Y * normalLength);
			_0023_003DzrH1N0x4_003D[num++] = (float)(point3D.Z + vector3D.Z * normalLength);
			point3D = _vertices[i + Slices];
			vector3D = Vector3D.Subtract(point3D, end);
			vector3D.Normalize();
			array[i + Slices] = vector3D;
			_0023_003DzrH1N0x4_003D[num++] = (float)point3D.X;
			_0023_003DzrH1N0x4_003D[num++] = (float)point3D.Y;
			_0023_003DzrH1N0x4_003D[num++] = (float)point3D.Z;
			_0023_003DzrH1N0x4_003D[num++] = (float)(point3D.X + vector3D.X * normalLength);
			_0023_003DzrH1N0x4_003D[num++] = (float)(point3D.Y + vector3D.Y * normalLength);
			_0023_003DzrH1N0x4_003D[num++] = (float)(point3D.Z + vector3D.Z * normalLength);
		}
		return array;
	}

	protected internal override void DrawWireframe(DrawParams data)
	{
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
		data.RenderContext.Draw(drawData);
	}

	public override void Regen(RegenParams data)
	{
		if (Slices < 3)
		{
			Slices = 3;
		}
		_vertices = new Point3D[Slices * 2];
		Vector3D vector3D = Vector3D.Subtract(end, start);
		double length = vector3D.Length;
		for (int i = 0; i < Slices; i++)
		{
			double num = (double)(i * 2) * Math.PI / (double)Slices;
			double num2 = Math.Cos(num);
			double num3 = Math.Sin(num);
			_vertices[i] = new Point3D(0.0, num2 * _radius, num3 * _radius);
			_vertices[i + Slices] = new Point3D(length, num2 * _radius, num3 * _radius);
		}
		_triangles = new IndexTriangle[Slices * 2];
		int num4 = 0;
		for (int j = 0; j < Slices; j++)
		{
			if (j + 1 < Slices)
			{
				_triangles[num4] = new IndexTriangle(j, j + 1, j + Slices + 1);
			}
			else
			{
				_triangles[num4] = new IndexTriangle(j, 0, Slices);
			}
			if (j + Slices + 1 < Slices * 2)
			{
				_triangles[num4 + 1] = new IndexTriangle(j, j + Slices + 1, j + Slices);
			}
			else
			{
				_triangles[num4 + 1] = new IndexTriangle(j, Slices, j + Slices);
			}
			num4 += 2;
		}
		Transformation orientationTransformation = Utility.GetOrientationTransformation(start, vector3D);
		for (int k = 0; k < Slices; k++)
		{
			_vertices[k] = orientationTransformation * _vertices[k];
			_vertices[Slices + k] = orientationTransformation * _vertices[Slices + k];
		}
		base.Regen(data);
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		Point3D[] array = new Point3D[4 * Slices];
		Vector3D[] array2 = new Vector3D[4 * Slices];
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < Slices; i++)
		{
			Utility.GetSliceVerticesAndNormals(i, _radius, Slices, start, end, _vertices, out array[num++], out array[num++], out array[num++], out array[num++], out array2[num2++], out array2[num2++], out array2[num2++], out array2[num2++]);
		}
		context.DrawQuadStrip(array, array2);
	}

	public override void TransformBy(Transformation xform)
	{
		double scaleFactor = Math.Abs(xform.ScaleFactorX);
		Plane pl = new Plane(new Vector3D(StartPoint, EndPoint));
		if (xform.IsScaleFactorUniform() || xform.IsScaleFactorUniformForPlanar(pl, ref scaleFactor))
		{
			_radius *= scaleFactor;
		}
		double[] array = xform.ActOnLeft(start.X, start.Y, start.Z, 1.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		start.X = num * array[0];
		start.Y = num * array[1];
		start.Z = num * array[2];
		array = xform.ActOnLeft(end.X, end.Y, end.Z, 1.0);
		num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		end.X = num * array[0];
		end.Y = num * array[1];
		end.Z = num * array[2];
		if (Triangles != null && xform.HasReflection)
		{
			RegenMode = regenType.RegenAndCompile;
		}
		base.TransformBy(xform);
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
		Circle circle = new Circle(new Plane(StartPoint, new Vector3D(StartPoint, EndPoint)), Point2D.Origin, Radius);
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[1]
		{
			new _0023_003DzZXHZ8r_AKGbCsLnm7EUe1w_00244EG0i1nNAEdrGUvzdztgO(circle._0023_003DzuAMveDQA6vvk()[0], circle.StartPoint + new Vector3D(start, end).AsPoint, ColorMethod == colorMethodType.byEntity, LayerName, Color)
		};
	}

	public Surface ConvertToSurface()
	{
		return new Circle(new Plane(StartPoint, new Vector3D(StartPoint, EndPoint)), Point2D.Origin, Radius).ExtrudeAsSurface(new Vector3D(start, end))[0];
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new BarSurrogate(this);
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (base._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D() && Triangles != null)
		{
			return Triangles.Length != 0;
		}
		return false;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954895), start);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954593), end);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843), _radius);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956086), Slices);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			return new Point3D[2] { start, end };
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}

	internal override bool _0023_003Dz1owWudHkrMNo9ZKfxq18_OA_003D(TraversalParams _0023_003DzELu0Pss_003D, out Point2D[] _0023_003DzrdSL0CI_003D, out bool _0023_003DzD5Gs7jmmc9uK, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D = false)
	{
		_0023_003DzHhJEwwk_003D = 1;
		double num = _radius * 2.0;
		if (_localOB != null && !_localOB._0023_003DziQOhVy0_003D && (RegenMode == regenType.NotNeeded || _0023_003DzjZRgeJk_003D))
		{
			_0023_003DzD5Gs7jmmc9uK = false;
		}
		else
		{
			_0023_003DzD5Gs7jmmc9uK = true;
		}
		Vector3D vector3D = new Vector3D(start, end);
		Plane plane = new Plane(start, vector3D);
		Point3D origin = start - plane.AxisX * _radius;
		origin -= plane.AxisY * _radius;
		_localOB = new OrientedBoundingBox(origin, plane.AxisX, plane.AxisY, num, num, vector3D.Length);
		Point2D[] array = _vertices ?? ((Point3D[])_localOB.GetVertices());
		_0023_003DzrdSL0CI_003D = array;
		return true;
	}

	internal override SilhoWireData _0023_003DzEt1XHB_xc_BLLBoMbJmskWU_003D(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		return HiddenLinesView._0023_003DzeWZNZhCW691ciXKd0w_003D_003D(this, _0023_003DzELu0Pss_003D.Parents, Vertices, Triangles, null, _0023_003DzbErHvVw_003D: true, 0.0);
	}

	public void FlipNormal()
	{
		throw new NotImplementedException();
	}

	public Mesh[] GetTessellation()
	{
		return new Mesh[1]
		{
			new Mesh(_vertices, _triangles)
		};
	}

	public IList<HitTriangle> FindClosestTriangle(Transformation transf, Segment3D seg)
	{
		return Utility.FindClosestTriangle(transf, seg, _vertices, _triangles).Values;
	}

	public ICurve[] Section(Plane pln, double tol)
	{
		return new Mesh(_vertices, _triangles).Section(pln, tol);
	}

	public Mesh ConvertToMesh(double deviation = 0.0, double angle = 0.0, Mesh.natureType nature = Mesh.natureType.Smooth, bool weld = true)
	{
		Mesh mesh = new Mesh(0, 0, nature);
		mesh.Vertices = Utility.DeepCopy(_vertices);
		mesh.Triangles = Utility.DeepCopy(_triangles);
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
}
